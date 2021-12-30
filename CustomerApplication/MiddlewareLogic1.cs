using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerApplication
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class MiddlewareLogic1
    {
        private readonly RequestDelegate _next;

        public MiddlewareLogic1(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            await httpContext.Response.WriteAsync("This is the logic 1  \n");
            await _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareLogic1Extensions
    {
        public static IApplicationBuilder UseMiddlewareLogic1(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MiddlewareLogic1>();
        }
    }
}
