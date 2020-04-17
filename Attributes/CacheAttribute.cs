using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using myWebApp.Interfaces;

public class CacheAttribute : ActionFilterAttribute
{
    private string _contentType;

    private string _key;

    public CacheAttribute(string contentType, string key)
    {
        _contentType = contentType;
        _key = key;
    }

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        IMySingletonCache mySingletonCache = (IMySingletonCache) context.HttpContext.RequestServices.GetService(typeof(IMySingletonCache));
        IWhiteList whiteList = (IWhiteList) context.HttpContext.RequestServices.GetService(typeof(IWhiteList));
        if (whiteList.contains(_key) && mySingletonCache.TryGetValue<string>(_key, out string htmlCache))
        {
            context.Result = new ContentResult() { Content = htmlCache, ContentType = _contentType };
            return;
        }
        base.OnActionExecuting(context);
    }

    public override void OnActionExecuted(ActionExecutedContext context)
    {
        
    }
}
