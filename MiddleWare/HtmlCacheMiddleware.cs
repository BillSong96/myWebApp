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

        private IWhiteList _whiteList;

        public HtmlCacheMiddleware(RequestDelegate next, IMySingletonCache MySingletonCache, IWhiteList whiteList)
        {
            _next = next;
            _mySingletonCache = MySingletonCache;
            _whiteList = whiteList;
        }
        public async Task Invoke(HttpContext context)
        {
            var key = UrlPathRefractor(context.Request.Path.ToString().ToLower());
            if (_whiteList.contains(key))
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
                    _mySingletonCache.SetNX<string>(key, html, DateTime.Now.AddSeconds(5));
                    return Task.CompletedTask;
                });
            }
            else
            {
                await _next(context);
            }
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
            if (urlPath.LastIndexOf("/") <= 0)
            {
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