
using BookRate.DAL.Models;
using BookRate.DAL.Repositories.EntityImplementations;
using BookRate.DAL.Repositories.IRepository;
using BookRate.DAL.UoW;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Newtonsoft.Json;
using System.Net;
using System.Security.Claims;

namespace BookRate.Middlware
{
    public class BanMiddlware
    {
        private RequestDelegate _next;
        private readonly ProblemDetailsFactory _problemDetailsFactory;
    
        public BanMiddlware(RequestDelegate next,
            ProblemDetailsFactory problemDetailsFactory)
       
        {
            _next = next;
            _problemDetailsFactory = problemDetailsFactory;
        
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            var user = httpContext.User;
            if (user.Identity.IsAuthenticated)
            {
                var banClaim = user.FindFirstValue("IsGetBan");
                var userId = Convert.ToInt32(user.FindFirstValue(ClaimTypes.NameIdentifier));
                if (banClaim != null && bool.TryParse(banClaim, out bool isBanned) && isBanned)
                {
        
                    var problemDetails = new ProblemDetails
                    {
                        Instance = httpContext.Request.Path,
                        Detail = $"You can`t make a review because of you have a ban",
                        Status = (int)HttpStatusCode.Conflict,
                    };

                    if (_problemDetailsFactory != null)
                    {
                        var problem = _problemDetailsFactory.CreateProblemDetails(httpContext, problemDetails.Status);

                        problemDetails.Title = problem.Title;
                        problemDetails.Type = problem.Type;
                    }


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
