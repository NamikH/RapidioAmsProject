#pragma checksum "C:\AMSproject\AMSproject\Views\PaymentTransactions\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ea238ec6e5e6999e2383bb0717480ec584cfcf46"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_PaymentTransactions_Details), @"mvc.1.0.view", @"/Views/PaymentTransactions/Details.cshtml")]
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
#line 1 "C:\AMSproject\AMSproject\Views\_ViewImports.cshtml"
using AMSproject;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\AMSproject\AMSproject\Views\_ViewImports.cshtml"
using AMSproject.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ea238ec6e5e6999e2383bb0717480ec584cfcf46", @"/Views/PaymentTransactions/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e0d06f3f9fda07b3243119db3eda2fe7f055d65c", @"/Views/_ViewImports.cshtml")]
    public class Views_PaymentTransactions_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<AMS.Models.PaymentTransactions>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\AMSproject\AMSproject\Views\PaymentTransactions\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>Details</h2>\r\n\r\n<div>\r\n    <h4>PaymentTransactions</h4>\r\n    <hr />\r\n    <dl class=\"dl-horizontal\">\r\n        <dt>\r\n            ");
#nullable restore
#line 14 "C:\AMSproject\AMSproject\Views\PaymentTransactions\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Amount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
#nullable restore
#line 17 "C:\AMSproject\AMSproject\Views\PaymentTransactions\Details.cshtml"
       Write(Html.DisplayFor(model => model.Amount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
#nullable restore
#line 20 "C:\AMSproject\AMSproject\Views\PaymentTransactions\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.CreatedDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
#nullable restore
#line 23 "C:\AMSproject\AMSproject\Views\PaymentTransactions\Details.cshtml"
       Write(Html.DisplayFor(model => model.CreatedDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
#nullable restore
#line 26 "C:\AMSproject\AMSproject\Views\PaymentTransactions\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.PaymentDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
#nullable restore
#line 29 "C:\AMSproject\AMSproject\Views\PaymentTransactions\Details.cshtml"
       Write(Html.DisplayFor(model => model.PaymentDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
#nullable restore
#line 32 "C:\AMSproject\AMSproject\Views\PaymentTransactions\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Explanation));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
#nullable restore
#line 35 "C:\AMSproject\AMSproject\Views\PaymentTransactions\Details.cshtml"
       Write(Html.DisplayFor(model => model.Explanation));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
#nullable restore
#line 38 "C:\AMSproject\AMSproject\Views\PaymentTransactions\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Explanation2));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
#nullable restore
#line 41 "C:\AMSproject\AMSproject\Views\PaymentTransactions\Details.cshtml"
       Write(Html.DisplayFor(model => model.Explanation2));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
#nullable restore
#line 44 "C:\AMSproject\AMSproject\Views\PaymentTransactions\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Explanation3));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
#nullable restore
#line 47 "C:\AMSproject\AMSproject\Views\PaymentTransactions\Details.cshtml"
       Write(Html.DisplayFor(model => model.Explanation3));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
#nullable restore
#line 50 "C:\AMSproject\AMSproject\Views\PaymentTransactions\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.ContractId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
#nullable restore
#line 53 "C:\AMSproject\AMSproject\Views\PaymentTransactions\Details.cshtml"
       Write(Html.DisplayFor(model => model.ContractId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
#nullable restore
#line 56 "C:\AMSproject\AMSproject\Views\PaymentTransactions\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Customer));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
#nullable restore
#line 59 "C:\AMSproject\AMSproject\Views\PaymentTransactions\Details.cshtml"
       Write(Html.DisplayFor(model => model.Customer));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
#nullable restore
#line 62 "C:\AMSproject\AMSproject\Views\PaymentTransactions\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Cash));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
#nullable restore
#line 65 "C:\AMSproject\AMSproject\Views\PaymentTransactions\Details.cshtml"
       Write(Html.DisplayFor(model => model.Cash));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
#nullable restore
#line 68 "C:\AMSproject\AMSproject\Views\PaymentTransactions\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.CostTypDefenition));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
#nullable restore
#line 71 "C:\AMSproject\AMSproject\Views\PaymentTransactions\Details.cshtml"
       Write(Html.DisplayFor(model => model.CostTypDefenition));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
#nullable restore
#line 74 "C:\AMSproject\AMSproject\Views\PaymentTransactions\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.IncomeTypeDefenition));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
#nullable restore
#line 77 "C:\AMSproject\AMSproject\Views\PaymentTransactions\Details.cshtml"
       Write(Html.DisplayFor(model => model.IncomeTypeDefenition));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
#nullable restore
#line 80 "C:\AMSproject\AMSproject\Views\PaymentTransactions\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.TransactionTypDefenition));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
#nullable restore
#line 83 "C:\AMSproject\AMSproject\Views\PaymentTransactions\Details.cshtml"
       Write(Html.DisplayFor(model => model.TransactionTypDefenition));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
#nullable restore
#line 86 "C:\AMSproject\AMSproject\Views\PaymentTransactions\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.SupportTypDefenition));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
#nullable restore
#line 89 "C:\AMSproject\AMSproject\Views\PaymentTransactions\Details.cshtml"
       Write(Html.DisplayFor(model => model.SupportTypDefenition));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
#nullable restore
#line 92 "C:\AMSproject\AMSproject\Views\PaymentTransactions\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Number));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
#nullable restore
#line 95 "C:\AMSproject\AMSproject\Views\PaymentTransactions\Details.cshtml"
       Write(Html.DisplayFor(model => model.Number));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
#nullable restore
#line 98 "C:\AMSproject\AMSproject\Views\PaymentTransactions\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.CustDocno));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
#nullable restore
#line 101 "C:\AMSproject\AMSproject\Views\PaymentTransactions\Details.cshtml"
       Write(Html.DisplayFor(model => model.CustDocno));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
#nullable restore
#line 104 "C:\AMSproject\AMSproject\Views\PaymentTransactions\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.SignTypeId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
#nullable restore
#line 107 "C:\AMSproject\AMSproject\Views\PaymentTransactions\Details.cshtml"
       Write(Html.DisplayFor(model => model.SignTypeId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
#nullable restore
#line 110 "C:\AMSproject\AMSproject\Views\PaymentTransactions\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.SignTypeDefenition));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
#nullable restore
#line 113 "C:\AMSproject\AMSproject\Views\PaymentTransactions\Details.cshtml"
       Write(Html.DisplayFor(model => model.SignTypeDefenition));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
#nullable restore
#line 116 "C:\AMSproject\AMSproject\Views\PaymentTransactions\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.CashId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
#nullable restore
#line 119 "C:\AMSproject\AMSproject\Views\PaymentTransactions\Details.cshtml"
       Write(Html.DisplayFor(model => model.CashId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
#nullable restore
#line 122 "C:\AMSproject\AMSproject\Views\PaymentTransactions\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.TransactionTypeId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
#nullable restore
#line 125 "C:\AMSproject\AMSproject\Views\PaymentTransactions\Details.cshtml"
       Write(Html.DisplayFor(model => model.TransactionTypeId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
#nullable restore
#line 128 "C:\AMSproject\AMSproject\Views\PaymentTransactions\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.CustomersId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
#nullable restore
#line 131 "C:\AMSproject\AMSproject\Views\PaymentTransactions\Details.cshtml"
       Write(Html.DisplayFor(model => model.CustomersId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
#nullable restore
#line 134 "C:\AMSproject\AMSproject\Views\PaymentTransactions\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.CostTypeId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
#nullable restore
#line 137 "C:\AMSproject\AMSproject\Views\PaymentTransactions\Details.cshtml"
       Write(Html.DisplayFor(model => model.CostTypeId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
#nullable restore
#line 140 "C:\AMSproject\AMSproject\Views\PaymentTransactions\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.SupportTypeId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
#nullable restore
#line 143 "C:\AMSproject\AMSproject\Views\PaymentTransactions\Details.cshtml"
       Write(Html.DisplayFor(model => model.SupportTypeId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
#nullable restore
#line 146 "C:\AMSproject\AMSproject\Views\PaymentTransactions\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.ObjectsId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
#nullable restore
#line 149 "C:\AMSproject\AMSproject\Views\PaymentTransactions\Details.cshtml"
       Write(Html.DisplayFor(model => model.ObjectsId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
#nullable restore
#line 152 "C:\AMSproject\AMSproject\Views\PaymentTransactions\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.PaymentsId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
#nullable restore
#line 155 "C:\AMSproject\AMSproject\Views\PaymentTransactions\Details.cshtml"
       Write(Html.DisplayFor(model => model.PaymentsId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
#nullable restore
#line 158 "C:\AMSproject\AMSproject\Views\PaymentTransactions\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.IncomeTypeId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
#nullable restore
#line 161 "C:\AMSproject\AMSproject\Views\PaymentTransactions\Details.cshtml"
       Write(Html.DisplayFor(model => model.IncomeTypeId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ea238ec6e5e6999e2383bb0717480ec584cfcf4618572", async() => {
                WriteLiteral("Edit");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 166 "C:\AMSproject\AMSproject\Views\PaymentTransactions\Details.cshtml"
                           WriteLiteral(Model.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(" |\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ea238ec6e5e6999e2383bb0717480ec584cfcf4620702", async() => {
                WriteLiteral("Back to List");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AMS.Models.PaymentTransactions> Html { get; private set; }
    }
}
#pragma warning restore 1591
