using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Core.Extension
{
    public static class ClaimExtensions
    {
        public static void AddEmail(this ICollection<Claim> claim, string email)
        {
            claim.Add(new Claim(ClaimTypes.Email, email));        
        }
        public static void AddNameIdentifier(this ICollection<Claim> claim, string nameIdentifier)
        {
            claim.Add(new Claim(ClaimTypes.NameIdentifier, nameIdentifier));
        }
        public static void AddName(this ICollection<Claim> claim, string name)
        {
            claim.Add(new Claim(ClaimTypes.Name, name));
        }
        public static void AddRoles(this ICollection<Claim> claim,string[] roles)
        {
            roles.ToList().ForEach(role => claim.Add(new Claim(ClaimTypes.Role, role)));
        }
    }
}
