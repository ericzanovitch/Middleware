using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

namespace Middleware
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            
        }

        public IConfiguration Configuration { get; }

        public void Configure(IApplicationBuilder app)
        {
            app.UseMiddleware<MyMiddleware>();
            /*
            app.Use(async delegate (HttpContext context, Func<Task> next)
            {
                await next.Invoke();
            });
            */
        }
    }
}
