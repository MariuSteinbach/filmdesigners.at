using filmdesigners.at.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace filmdesigners.at.Authorization
{
    public class ChapterAdministratorAuthorizationHandler : AuthorizationHandler<OperationAuthorizationRequirement, Chapter>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, OperationAuthorizationRequirement requirement, Chapter resource)
        {
            if (context.User == null)
            {
                return Task.FromResult(0);
            }

            // Administrators can do anything.
            if (context.User.IsInRole(Constants.ChapterAdministratorsRole))
            {
                context.Succeed(requirement);
            }

            return Task.FromResult(0);
        }
    }
}
