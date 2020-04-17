using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;
using myWebApp.Interfaces;

namespace myWebApp.MiddleWare
{
    public class HtmlCacheMiddleware
    {
        private readonly RequestDelegate _next;

        private IMySingletonCache _mySingletonCache;

        public HtmlCacheMiddleware(RequestDelegate next, IMySingletonCache MySingletonCache)
        {
            _next = next;
            _mySingletonCache = MySingletonCache;
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
                _mySingletonCache.SetNX<string>(context.Request.Path.ToString().ToLower(), html, DateTime.Now.AddSeconds(5));
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

        private string UrlPathRefractor(string urlPath)
        {
            if (urlPath.LastIndexOf("/") <= 0) {
                if (urlPath.Equals("") || urlPath.Equals("/")) return "/home/index";
                return $"{urlPath}/index";
            }
            return urlPath;
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