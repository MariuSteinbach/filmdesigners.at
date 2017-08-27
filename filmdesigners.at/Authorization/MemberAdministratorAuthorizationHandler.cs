using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using filmdesigners.at.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
namespace filmdesigners.at.Authorization
{
    public class MemberAdministratorAuthorizationHandler : AuthorizationHandler<OperationAuthorizationRequirement, Member>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, OperationAuthorizationRequirement requirement, Member resource)
        {
            if(context.User == null)
            {
                return Task.FromResult(0);
            }

            //Administrators can do anything
            if(context.User.IsInRole(Constants.MembersAdministratorsRole))
            {
                context.Succeed(requirement);
            }

            return Task.FromResult(0);
        }
    }
}
