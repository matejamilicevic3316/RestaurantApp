#pragma checksum "C:\Users\Mateja\source\repos\RestaurantApplication\RestaurantMVC\Views\Articles\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c81f0ad79f694b2680fcee98a7f51b8e69015d7c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Articles_Index), @"mvc.1.0.view", @"/Views/Articles/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Articles/Index.cshtml", typeof(AspNetCore.Views_Articles_Index))]
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
#line 1 "C:\Users\Mateja\source\repos\RestaurantApplication\RestaurantMVC\Views\_ViewImports.cshtml"
using RestaurantMVC;

#line default
#line hidden
#line 2 "C:\Users\Mateja\source\repos\RestaurantApplication\RestaurantMVC\Views\_ViewImports.cshtml"
using RestaurantMVC.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c81f0ad79f694b2680fcee98a7f51b8e69015d7c", @"/Views/Articles/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7a40c530a10d545b65b02432c236327059aeb3bd", @"/Views/_ViewImports.cshtml")]
    public class Views_Articles_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<RAApplication.DTO.ArticleDTO>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(50, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\Mateja\source\repos\RestaurantApplication\RestaurantMVC\Views\Articles\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(140, 18, true);
            WriteLiteral("\r\n<h1>Index</h1>\r\n");
            EndContext();
#line 9 "C:\Users\Mateja\source\repos\RestaurantApplication\RestaurantMVC\Views\Articles\Index.cshtml"
 if (TempData["error"] != null)
{

#line default
#line hidden
            BeginContext(194, 27, true);
            WriteLiteral("    <p class=\"text-danger\">");
            EndContext();
            BeginContext(222, 17, false);
#line 11 "C:\Users\Mateja\source\repos\RestaurantApplication\RestaurantMVC\Views\Articles\Index.cshtml"
                      Write(TempData["error"]);

#line default
#line hidden
            EndContext();
            BeginContext(239, 6, true);
            WriteLiteral("</p>\r\n");
            EndContext();
#line 12 "C:\Users\Mateja\source\repos\RestaurantApplication\RestaurantMVC\Views\Articles\Index.cshtml"
}

#line default
#line hidden
            BeginContext(248, 9, true);
            WriteLiteral("<p>\r\n    ");
            EndContext();
            BeginContext(257, 37, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c81f0ad79f694b2680fcee98a7f51b8e69015d7c4822", async() => {
                BeginContext(280, 10, true);
                WriteLiteral("Create New");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(294, 92, true);
            WriteLiteral("\r\n</p>\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(387, 38, false);
#line 20 "C:\Users\Mateja\source\repos\RestaurantApplication\RestaurantMVC\Views\Articles\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Id));

#line default
#line hidden
            EndContext();
            BeginContext(425, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(481, 40, false);
#line 23 "C:\Users\Mateja\source\repos\RestaurantApplication\RestaurantMVC\Views\Articles\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Name));

#line default
#line hidden
            EndContext();
            BeginContext(521, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(577, 47, false);
#line 26 "C:\Users\Mateja\source\repos\RestaurantApplication\RestaurantMVC\Views\Articles\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.ArticleType));

#line default
#line hidden
            EndContext();
            BeginContext(624, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(680, 41, false);
#line 29 "C:\Users\Mateja\source\repos\RestaurantApplication\RestaurantMVC\Views\Articles\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Price));

#line default
#line hidden
            EndContext();
            BeginContext(721, 86, true);
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
            EndContext();
#line 35 "C:\Users\Mateja\source\repos\RestaurantApplication\RestaurantMVC\Views\Articles\Index.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
            BeginContext(856, 60, true);
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(917, 37, false);
#line 39 "C:\Users\Mateja\source\repos\RestaurantApplication\RestaurantMVC\Views\Articles\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Id));

#line default
#line hidden
            EndContext();
            BeginContext(954, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1022, 39, false);
#line 42 "C:\Users\Mateja\source\repos\RestaurantApplication\RestaurantMVC\Views\Articles\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Name));

#line default
#line hidden
            EndContext();
            BeginContext(1061, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1129, 46, false);
#line 45 "C:\Users\Mateja\source\repos\RestaurantApplication\RestaurantMVC\Views\Articles\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.ArticleType));

#line default
#line hidden
            EndContext();
            BeginContext(1175, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1243, 40, false);
#line 48 "C:\Users\Mateja\source\repos\RestaurantApplication\RestaurantMVC\Views\Articles\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Price));

#line default
#line hidden
            EndContext();
            BeginContext(1283, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1351, 53, false);
#line 51 "C:\Users\Mateja\source\repos\RestaurantApplication\RestaurantMVC\Views\Articles\Index.cshtml"
               Write(Html.ActionLink("Edit", "Edit", new { id = item.Id }));

#line default
#line hidden
            EndContext();
            BeginContext(1404, 24, true);
            WriteLiteral(" |\r\n                    ");
            EndContext();
            BeginContext(1429, 59, false);
#line 52 "C:\Users\Mateja\source\repos\RestaurantApplication\RestaurantMVC\Views\Articles\Index.cshtml"
               Write(Html.ActionLink("Details", "Details", new { id = item.Id }));

#line default
#line hidden
            EndContext();
            BeginContext(1488, 24, true);
            WriteLiteral(" |\r\n                    ");
            EndContext();
            BeginContext(1513, 57, false);
#line 53 "C:\Users\Mateja\source\repos\RestaurantApplication\RestaurantMVC\Views\Articles\Index.cshtml"
               Write(Html.ActionLink("Delete", "Delete", new { id = item.Id }));

#line default
#line hidden
            EndContext();
            BeginContext(1570, 46, true);
            WriteLiteral(" |\r\n                </td>\r\n            </tr>\r\n");
            EndContext();
#line 56 "C:\Users\Mateja\source\repos\RestaurantApplication\RestaurantMVC\Views\Articles\Index.cshtml"
        }

#line default
#line hidden
            BeginContext(1627, 24, true);
            WriteLiteral("    </tbody>\r\n</table>\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<RAApplication.DTO.ArticleDTO>> Html { get; private set; }
    }
}
#pragma warning restore 1591
