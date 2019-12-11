using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Middleware
{
    public class MyMiddleware
    {
        private RequestDelegate _next;

        public MyMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            // Do something here
            //context.Response.ContentType = "application/pdf";
            //await context.Response.Body.WriteAsync
            context.Response.StatusCode = StatusCodes.Status200OK;
            await context.Response.WriteAsync("Hello World");
            //await _next.Invoke(context);

            // Cleanup
        }
    }
}
