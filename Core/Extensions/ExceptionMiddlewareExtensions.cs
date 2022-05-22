using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            //useMiddleware function is written by .net team in case that we want
            //to create add middleware's to lifecycle.
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
