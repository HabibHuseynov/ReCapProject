using Core.Entities.Concrete;
using Core.Extension;
using Core.Utilities.Security.Encryption;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Core.Utilities.Security.JWT
{
    public class JwtHelper : ITokenHelper
    {
        public IConfiguration _configuration;
        DateTime _accessTokenExpiration;
        TokenOptions _tokenOptions;

        public JwtHelper(IConfiguration configuration)
        {
            _configuration = configuration;
            _tokenOptions = _configuration.GetSection("TokenOptions").Get<TokenOptions>();
        }

        public AccessToken CreateToken(User user, List<OperationClaim> operationClaims)
        {
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
            var jwt = CreateJwtSecurityToken(_tokenOptions, user, signingCredentials, operationClaims);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);
            return new AccessToken
            {
                Token = token,
                Expiration = _accessTokenExpiration
            };
        }
        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions,User user,
                                                        SigningCredentials signingCredentials,List<OperationClaim> claims)
        {
            var jwt = new JwtSecurityToken
                (
                     issuer: tokenOptions.Issuer,
                     audience: tokenOptions.Audience,
                     expires: _accessTokenExpiration,
                     notBefore: DateTime.Now,
                     claims: SetClaims(user, claims),
                     signingCredentials: signingCredentials

                );
            return jwt;
        }
        public IEnumerable<Claim> SetClaims(User user,List<OperationClaim> claims)
        {
            var claim = new List<Claim>();
            claim.AddNameIdentifier(user.Id.ToString());
            claim.AddEmail(user.Email);
            claim.AddName($"{user.FirstName} {user.LastName}");
            claim.AddRoles(claims.Select(c => c.Name).ToArray());

            return claim;
        }
    }
}
