using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.IO;

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
            Microsoft.Extensions.Primitives.StringValues paramFileName = new Microsoft.Extensions.Primitives.StringValues();
            context.Request.Query.TryGetValue("filename", out paramFileName);
            string FileName = paramFileName.ToString();
            if (FileName != "")
            {
                try
                {
                    byte[] FileBytes = File.ReadAllBytes(FileName);

                    context.Response.StatusCode = StatusCodes.Status200OK;
                    context.Response.ContentType = "application/pdf";
                    await context.Response.Body.WriteAsync(FileBytes, 0, FileBytes.Length);
                }
                catch(Exception ex)
                {
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    await context.Response.WriteAsync(ex.Message);
                }
            }
            else
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await context.Response.WriteAsync("URL requires a filename parameter.");
            }

        }
    }
}
