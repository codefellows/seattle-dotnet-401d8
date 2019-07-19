using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Cohort8CMSProject.Models.Handlers
{
    public class CodefellowsEmailHandler : AuthorizationHandler<RequiredEmailRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, RequiredEmailRequirement requirement)
        {
            if(!context.User.HasClaim(c => c.Type == ClaimTypes.Email))
            {
                return Task.CompletedTask;
            }

            // have the user's current email.
            var email = context.User.FindFirst(c => c.Type == ClaimTypes.Email).Value;

            // could do some regex logic here to valudate...
            // but...we don't want to right now. 
            if (email.Contains("@codefellows.com"))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;

        }
    }
}
