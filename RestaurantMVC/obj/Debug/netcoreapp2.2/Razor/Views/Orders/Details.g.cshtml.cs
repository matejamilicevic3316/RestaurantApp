#pragma checksum "C:\Users\Mateja\source\repos\RestaurantApplication\RestaurantMVC\Views\Orders\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9df5a14b58a88f9e8f5ac926d3040ed253b20e84"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Orders_Details), @"mvc.1.0.view", @"/Views/Orders/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Orders/Details.cshtml", typeof(AspNetCore.Views_Orders_Details))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9df5a14b58a88f9e8f5ac926d3040ed253b20e84", @"/Views/Orders/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7a40c530a10d545b65b02432c236327059aeb3bd", @"/Views/_ViewImports.cshtml")]
    public class Views_Orders_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<RAApplication.DTO.OrderDTO>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(35, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\Mateja\source\repos\RestaurantApplication\RestaurantMVC\Views\Orders\Details.cshtml"
  
    ViewData["Title"] = "Details";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(127, 20, true);
            WriteLiteral("\r\n<h1>Details</h1>\r\n");
            EndContext();
#line 9 "C:\Users\Mateja\source\repos\RestaurantApplication\RestaurantMVC\Views\Orders\Details.cshtml"
 if (TempData["error"] != null)
{

#line default
#line hidden
            BeginContext(183, 27, true);
            WriteLiteral("    <p class=\"text-danger\">");
            EndContext();
            BeginContext(211, 17, false);
#line 11 "C:\Users\Mateja\source\repos\RestaurantApplication\RestaurantMVC\Views\Orders\Details.cshtml"
                      Write(TempData["error"]);

#line default
#line hidden
            EndContext();
            BeginContext(228, 6, true);
            WriteLiteral("</p>\r\n");
            EndContext();
#line 12 "C:\Users\Mateja\source\repos\RestaurantApplication\RestaurantMVC\Views\Orders\Details.cshtml"
}

#line default
#line hidden
            BeginContext(237, 107, true);
            WriteLiteral("<div>\r\n    <h4>OrderDTO</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class=\"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(345, 38, false);
#line 18 "C:\Users\Mateja\source\repos\RestaurantApplication\RestaurantMVC\Views\Orders\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Id));

#line default
#line hidden
            EndContext();
            BeginContext(383, 61, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(445, 34, false);
#line 21 "C:\Users\Mateja\source\repos\RestaurantApplication\RestaurantMVC\Views\Orders\Details.cshtml"
       Write(Html.DisplayFor(model => model.Id));

#line default
#line hidden
            EndContext();
            BeginContext(479, 60, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(540, 41, false);
#line 24 "C:\Users\Mateja\source\repos\RestaurantApplication\RestaurantMVC\Views\Orders\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Table));

#line default
#line hidden
            EndContext();
            BeginContext(581, 61, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(643, 37, false);
#line 27 "C:\Users\Mateja\source\repos\RestaurantApplication\RestaurantMVC\Views\Orders\Details.cshtml"
       Write(Html.DisplayFor(model => model.Table));

#line default
#line hidden
            EndContext();
            BeginContext(680, 60, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(741, 44, false);
#line 30 "C:\Users\Mateja\source\repos\RestaurantApplication\RestaurantMVC\Views\Orders\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.FullName));

#line default
#line hidden
            EndContext();
            BeginContext(785, 61, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(847, 40, false);
#line 33 "C:\Users\Mateja\source\repos\RestaurantApplication\RestaurantMVC\Views\Orders\Details.cshtml"
       Write(Html.DisplayFor(model => model.FullName));

#line default
#line hidden
            EndContext();
            BeginContext(887, 60, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(948, 46, false);
#line 36 "C:\Users\Mateja\source\repos\RestaurantApplication\RestaurantMVC\Views\Orders\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.TotalPrice));

#line default
#line hidden
            EndContext();
            BeginContext(994, 61, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1056, 42, false);
#line 39 "C:\Users\Mateja\source\repos\RestaurantApplication\RestaurantMVC\Views\Orders\Details.cshtml"
       Write(Html.DisplayFor(model => model.TotalPrice));

#line default
#line hidden
            EndContext();
            BeginContext(1098, 60, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1159, 44, false);
#line 42 "C:\Users\Mateja\source\repos\RestaurantApplication\RestaurantMVC\Views\Orders\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Articles));

#line default
#line hidden
            EndContext();
            BeginContext(1203, 67, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            <ul>\r\n");
            EndContext();
#line 46 "C:\Users\Mateja\source\repos\RestaurantApplication\RestaurantMVC\Views\Orders\Details.cshtml"
                 foreach (var article in Model.Articles)
                {

#line default
#line hidden
            BeginContext(1347, 24, true);
            WriteLiteral("                    <li>");
            EndContext();
            BeginContext(1372, 19, false);
#line 48 "C:\Users\Mateja\source\repos\RestaurantApplication\RestaurantMVC\Views\Orders\Details.cshtml"
                   Write(article.ArticleName);

#line default
#line hidden
            EndContext();
            BeginContext(1391, 3, true);
            WriteLiteral(" - ");
            EndContext();
            BeginContext(1395, 21, false);
#line 48 "C:\Users\Mateja\source\repos\RestaurantApplication\RestaurantMVC\Views\Orders\Details.cshtml"
                                          Write(article.ArticleNumber);

#line default
#line hidden
            EndContext();
            BeginContext(1416, 9, true);
            WriteLiteral(" -price: ");
            EndContext();
            BeginContext(1426, 26, false);
#line 48 "C:\Users\Mateja\source\repos\RestaurantApplication\RestaurantMVC\Views\Orders\Details.cshtml"
                                                                         Write(article.TotalArticlesPrice);

#line default
#line hidden
            EndContext();
            BeginContext(1452, 7, true);
            WriteLiteral("</li>\r\n");
            EndContext();
#line 49 "C:\Users\Mateja\source\repos\RestaurantApplication\RestaurantMVC\Views\Orders\Details.cshtml"
                }

#line default
#line hidden
            BeginContext(1478, 64, true);
            WriteLiteral("            </ul>\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n    ");
            EndContext();
            BeginContext(1543, 68, false);
#line 55 "C:\Users\Mateja\source\repos\RestaurantApplication\RestaurantMVC\Views\Orders\Details.cshtml"
Write(Html.ActionLink("Edit", "Edit", new { /* id = Model.PrimaryKey */ }));

#line default
#line hidden
            EndContext();
            BeginContext(1611, 8, true);
            WriteLiteral(" |\r\n    ");
            EndContext();
            BeginContext(1619, 38, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9df5a14b58a88f9e8f5ac926d3040ed253b20e8411060", async() => {
                BeginContext(1641, 12, true);
                WriteLiteral("Back to List");
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
            BeginContext(1657, 10, true);
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<RAApplication.DTO.OrderDTO> Html { get; private set; }
    }
}
#pragma warning restore 1591
