using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Routing;
using System;
using System.IO;
using System.Threading.Tasks;
using myWebApp.Interfaces;
using System.Diagnostics;



namespace myWebApp.MiddleWare
{
    public class HtmlCacheMiddleware
    {
        private readonly RequestDelegate _next;

        private IMySingletonCache _IMySingletonCache;

        public HtmlCacheMiddleware(RequestDelegate next, IMySingletonCache IMySingletonCache)
        {
            _next = next;
            _IMySingletonCache = IMySingletonCache;
        }
        public async Task Invoke(HttpContext context)
        {
            var originalBodyStream = context.Response.Body;
            string html;
            using (var responseBody = new MemoryStream())
            {
                context.Response.Body = responseBody;
                await _next(context);
                html = await GetResponse(context.Response);
                await responseBody.CopyToAsync(originalBodyStream);
            }
            context.Response.OnCompleted(() =>
            {
                _IMySingletonCache.SetNX<string>(context.Request.Path, html, DateTime.Now.AddSeconds(5));
                return Task.CompletedTask;
            });
        }

        public async Task<string> GetResponse(HttpResponse response)
        {
            response.Body.Seek(0, SeekOrigin.Begin);
            var text = await new StreamReader(response.Body).ReadToEndAsync();
            response.Body.Seek(0, SeekOrigin.Begin);
            return text;
        }
    }

    public static class HtmlCacheMiddlewareExtensions
    {
        public static IApplicationBuilder UseHtmlCache(this IApplicationBuilder app)
        {
            return app.UseMiddleware<HtmlCacheMiddleware>();
        }
    }
}