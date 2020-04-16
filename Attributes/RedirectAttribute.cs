using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

public class RedirectAttribute : ActionFilterAttribute
{
    public string _headersKey { get; set; }
    
    public string _keyWord { get; set; }

    public string _redirectUrl { get; set; }

    public RedirectAttribute(string headersKey, string keyWord, string redirectUrl)
    {
        _headersKey = headersKey;
        _keyWord = keyWord;
        _redirectUrl = redirectUrl;
    }
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var headers = context.HttpContext.Request.Headers;
        if (headers.ContainsKey(_headersKey)) {
            var values = headers[_headersKey];
            if (values.Count > 0 && values[0].Contains(_keyWord)) {
                context.Result = new RedirectResult(_redirectUrl);
                return;
            }
        }
        base.OnActionExecuting(context);
    }
}
