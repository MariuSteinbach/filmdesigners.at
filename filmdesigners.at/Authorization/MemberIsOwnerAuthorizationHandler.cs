using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using filmdesigners.at.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Identity;

namespace filmdesigners.at.Authorization
{
    public class MemberIsOwnerAuthorizationHandler : AuthorizationHandler<OperationAuthorizationRequirement, Member>
    {
        UserManager<ApplicationUser> _userManager;

        public MemberIsOwnerAuthorizationHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, OperationAuthorizationRequirement requirement, Member resource)
        {
            if(context.User == null || resource == null)
            {
                return Task.FromResult(0);
            }

            // If we're not askinf for CRUD permission, return.

            if(requirement.Name != Constants.CreateOperationName &&
                requirement.Name != Constants.ReadOperationName &&
                requirement.Name != Constants.UpdateOperationName &&
                requirement.Name != Constants.DeleteOperationName)
            {
                return Task.FromResult(0);
            }

            if(resource.OwnerID == _userManager.GetUserId(context.User))
            {
                context.Succeed(requirement);
            }

            return Task.FromResult(0);
        }
    }
}
