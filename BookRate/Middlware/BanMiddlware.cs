using BookRate.DAL.Migrations;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.Security.Claims;

namespace BookRate.Middlware
{
    public class BanMiddlware
    {
        private RequestDelegate _next;
        public BanMiddlware(RequestDelegate next)
        {
            _next = next;
        }
        
        public async Task InvokeAsync(HttpContext httpContext)
        {
            var user = httpContext.User;
            if (user.Identity.IsAuthenticated)
            {
                var banClaim = user.FindFirstValue("IsGetBan");
                if (banClaim != null && bool.TryParse(banClaim, out bool isBanned) && isBanned)
                {
                    var problemDetails = new ProblemDetails
                    {
                        Instance = httpContext.Request.Path,
                        Detail = "You have a ban",
                        Status = (int)HttpStatusCode.Conflict,
                    };

                    var result = new ObjectResult(problemDetails)
                    {
                        StatusCode = problemDetails.Status
                    };

                    var response = JsonConvert.SerializeObject(result.Value);
                    httpContext.Response.ContentType = "application/problem+json";
                    await httpContext.Response.WriteAsync(response);
                    return;
                }
            }
            await _next(httpContext);
        }
    }
}
