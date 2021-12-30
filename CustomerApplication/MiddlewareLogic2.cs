using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerApplication
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class MiddlewareLogic2
    {
        private readonly RequestDelegate _next;

        public MiddlewareLogic2(RequestDelegate next)
        {
            _next = next;
        }

        public  async Task Invoke(HttpContext httpContext)
        {
            await httpContext.Response.WriteAsync("this is the logic 2 \n");

            await _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareLogic2Extensions
    {
        public static IApplicationBuilder UseMiddlewareLogic2(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MiddlewareLogic2>();
        }
    }
}
