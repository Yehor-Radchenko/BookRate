using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using System.Security.Claims;

namespace BookRate.Filters
{

    public class CheckApproachFilter : IAsyncAuthorizationFilter
    {

        private string? _claimValue;

        public CheckApproachFilter(string? claimValue)
        {
            _claimValue = claimValue;
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User;

            if (!user.Identity.IsAuthenticated)
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            var claimValue = user.FindFirstValue("IsGetBan");

            if (claimValue != null && bool.TryParse(claimValue, out bool isBanned) && isBanned)
            {
                var problemDetailts = new ProblemDetails
                {
                    Instance = context.HttpContext.Request.Path,
                    Title = "Access Denied",
                    Detail = $"You can`t do because of you have a ban",
                    Status = (int)HttpStatusCode.Forbidden,
                };

                context.Result = new ObjectResult(problemDetailts)
                {
                   StatusCode = (int)HttpStatusCode.Forbidden,
                };

                return;

            }

            await Task.CompletedTask;

        }
    }
}
