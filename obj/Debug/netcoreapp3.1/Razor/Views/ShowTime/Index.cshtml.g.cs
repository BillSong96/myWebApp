#pragma checksum "C:\Users\songz\myWebApp\Views\ShowTime\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "eb684bbfaecb245c4ba3506317a6611abb3d81cc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ShowTime_Index), @"mvc.1.0.view", @"/Views/ShowTime/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\songz\myWebApp\Views\_ViewImports.cshtml"
using myWebApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\songz\myWebApp\Views\_ViewImports.cshtml"
using myWebApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eb684bbfaecb245c4ba3506317a6611abb3d81cc", @"/Views/ShowTime/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"79c56adf42a17891524f77e501a492e0988687ef", @"/Views/_ViewImports.cshtml")]
    public class Views_ShowTime_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\songz\myWebApp\Views\ShowTime\Index.cshtml"
  
    ViewData["Title"] = "Current Time";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>CURRENT TIME IS:</h2>\r\n\r\n<p>");
#nullable restore
#line 7 "C:\Users\songz\myWebApp\Views\ShowTime\Index.cshtml"
Write(ViewData["time"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
