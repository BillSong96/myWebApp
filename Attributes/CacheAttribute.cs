using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using myWebApp.Interfaces;
using myWebApp.Services;
using System;

public class CacheAttribute : ActionFilterAttribute
{
    private IMySingletonCache _MySingletonCache = new MySingletonCache(new MemoryCache(new MemoryCacheOptions()));

    private string _ContentType;

    private string _Key;

    public CacheAttribute(string ContentType, string Key)
    {
        _ContentType = ContentType;
        _Key = Key;
    }

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (_MySingletonCache.TryGetValue<string>(_Key, out string htmlCache))
        {
            context.Result = new ContentResult() { Content = htmlCache, ContentType = _ContentType };
            return;
        }
        base.OnActionExecuting(context);
    }

    public override void OnActionExecuted(ActionExecutedContext context)
    {
        
    }
}
