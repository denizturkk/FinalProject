using Core.Utilities.Interceptors;
using Core.Utilities.Ioc;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;
using Core.Extensions;
using Business.Constants;

//SecuredOperation is FOR JWT
//authorisation aspects is generally written in business layer because
//authorisation algortihms can be changed this is why it is written in business
//not the core layer
namespace Business.BusinessAspects.Autofac
{
    public class SecuredOperation : MethodInterception
    {
        private string[] _roles;
       //for everyone who sent requests with jwt we create an instance of httpContextAccessor
       //because a lot of people can send requests simultaneously
        private IHttpContextAccessor _httpContextAccessor;

        //roles coming as a string form with ','s 
        public SecuredOperation(string roles)
        {
            _roles = roles.Split(',');
            //IHttpContextAccessor from asp.net core .Needed to be ınjected like IConfiguration
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();

        }

        protected override void OnBefore(IInvocation invocation)
        {
            ///find the uer's claim roles if there is any or more
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
            foreach (var role in _roles)
            {//if user has any claimRoles returns these claimroles.
                if (roleClaims.Contains(role))
                {
                    return;
                }
            }
            //if user has not any claimRoles throw exceptions
            throw new Exception(Messages.AuthorizationDenied);
        }
    }
}
