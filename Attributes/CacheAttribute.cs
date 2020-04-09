using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;
using System;


public class CacheAttribute : ActionFilterAttribute
{
    private static IMemoryCache cache = new MemoryCache(new MemoryCacheOptions());

    private bool flag;
    
    public int remainTime { get; set; } = 5;
    
    private string key { get; set; }

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        key = $"{context.HttpContext.Request.Scheme}://{context.HttpContext.Request.Host.ToString()}{context.HttpContext.Request.PathBase}{context.HttpContext.Request.Path}{context.HttpContext.Request.QueryString.ToString()}";
        dynamic obj = cache.Get(key);
        if (flag = obj != null) context.Result = obj;
    }

    public override void OnActionExecuted(ActionExecutedContext context)
    {

    }

    public override void OnResultExecuting(ResultExecutingContext context)
    {
        if (!flag) cache.Set<object>(key, context.Result, DateTime.Now.AddSeconds(remainTime));
    }

    public override void OnResultExecuted(ResultExecutedContext context)
    {

    }
}