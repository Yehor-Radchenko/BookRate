using BookRate.BLL.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Newtonsoft.Json;
using System.Net;
using Exception = System.Exception;

namespace BookRate.Middlware
{
    public class GlobalExceptionHandler
    {
        private readonly RequestDelegate _next;
        public ProblemDetailsFactory _problemDetailsFactory;

        public GlobalExceptionHandler(RequestDelegate next, 
            ProblemDetailsFactory problemDetailsFactory)
        {
            _next = next;
            _problemDetailsFactory = problemDetailsFactory;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {

            try
            {
                await _next(httpContext);
            }
            catch (Exception e)
            {
                await HandleAsync(httpContext, e);
            }
        }

        public async Task HandleAsync(HttpContext httpContext, Exception exception)
        {
            var problem = new ProblemDetails
            {
                Instance = httpContext.Request.Path,
                Status = (int)HttpStatusCode.InternalServerError,
                Detail = exception.Message
            };

            switch (exception)
            {
                case BadRequestException badRequestException:
                    foreach (var excep in badRequestException.Errors)
                    {
                        problem.Extensions.Add(excep.Key, excep.Value);
                    }
                    problem.Status = (int)HttpStatusCode.BadRequest;
                    break;
                case NotFoundException notFoundException:
                    problem.Status = (int)HttpStatusCode.NotFound;
                    break;
                case ConflictException conflictException:
                    problem.Status = (int)HttpStatusCode.Conflict;
                    break;
            }

            var problemDetails = new ProblemDetails();

            if (_problemDetailsFactory != null)
            {
                problemDetails = _problemDetailsFactory.CreateProblemDetails(httpContext, problem.Status);

                problem.Title = problemDetails.Title;
                problem.Type = problemDetails.Type;
            }


            var result = new ObjectResult(problem)
            {
                StatusCode = problem.Status
            };

            var response = JsonConvert.SerializeObject(result.Value);
            httpContext.Response.ContentType = "application/problem+json";
            await httpContext.Response.WriteAsync(response);
            
        }

    }
}
