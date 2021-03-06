using Business.Constants;
using Castle.DynamicProxy;
using Core.Extension;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;

namespace Business.BusinessAspect.Autofac
{
    public class SecuredOperations:MethodInterception
    {
        private string[] _roles;
        IHttpContextAccessor _httpContextAccessor;

        public SecuredOperations(string roles)
        {
            _roles = roles.Split(',');
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();

            foreach (var role in _roles)
            {
                if (roleClaims.Contains(role))
                {
                    return;
                }
            }
            throw new Exception(Messages.AuthorizationDenied);
        }
    }
}
