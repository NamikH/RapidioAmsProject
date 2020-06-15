#pragma checksum "C:\AMSproject\AMSproject\Views\PaymentTransactions\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8aa00f78a334885d72bf2b7ae3eb3513edab8bbf"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_PaymentTransactions_Index), @"mvc.1.0.view", @"/Views/PaymentTransactions/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8aa00f78a334885d72bf2b7ae3eb3513edab8bbf", @"/Views/PaymentTransactions/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e0d06f3f9fda07b3243119db3eda2fe7f055d65c", @"/Views/_ViewImports.cshtml")]
    public class Views_PaymentTransactions_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<AMS.Models.PaymentTransactions>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\AMSproject\AMSproject\Views\PaymentTransactions\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"


<style>
    thead input {
        width: 100%;
    }
</style>

<div class=""row"">
    <div class=""col-md-12"">
        <ol class=""breadcrumb"">
            <li class=""active"">
                Hesabatlar
            </li>
            <li class=""active"">
                Kassa hərəkətləri
            </li>
        </ol>
    </div>
</div>



<div class=""panel panel-white"">
    <div class=""panel-heading"">


        <div class=""panel-tools"">
            <div class=""dropdown"">
                <a data-toggle=""dropdown"" class=""btn btn-xs dropdown-toggle btn-transparent-grey"">
                    <i class=""fa fa-cog""></i>
                </a>
                <ul class=""dropdown-menu dropdown-light pull-right"" role=""menu"">
                    <li>
                        <a class=""panel-expand"" href=""#"">
                            <i class=""fa fa-expand""></i> <span>Fullscreen</span>
                        </a>
                    </li>
                </ul>
            </div>
 ");
            WriteLiteral(@"       </div>
    </div>


    <div class=""panel-body"">
        <div class=""table-responsive table-responsive-lg table-responsive-md table-responsive-sm table-responsive-xl"" style=""margin-bottom:0%"" ;>
            <table class=""table table-bordered table-hover display"" id=""example"" style=""width:99.8%"">
");
            WriteLiteral(@"                <thead>
                    <tr>
                        <td>
                            Əməliyyat növü
                        </td>
                        <td>
                            Məbləğ
                        </td>
                        <td>
                            Qaimə №
                        </td>
                        <td>
                            Hərəkət tipi
                        </td>
                        <td>
                            Açıqlama
                        </td>
                        <td>
                            Müştəri
                        </td>
                        <td>
                            Kassa
                        </td>
                        <td>
                            Xərc tipi
                        </td>

                        <td>
                            Xidmət növü
                        </td>
                        <td>
                            Obyekt №
     ");
            WriteLiteral("                   </td>\r\n                        <td>\r\n                            Tarix\r\n                        </td>\r\n                    </tr>\r\n                </thead>\r\n                <tbody>\r\n");
#nullable restore
#line 94 "C:\AMSproject\AMSproject\Views\PaymentTransactions\Index.cshtml"
                     foreach (var item in Model)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>\r\n                            ");
#nullable restore
#line 98 "C:\AMSproject\AMSproject\Views\PaymentTransactions\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.SignTypeDefenition));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 101 "C:\AMSproject\AMSproject\Views\PaymentTransactions\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.Amount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 104 "C:\AMSproject\AMSproject\Views\PaymentTransactions\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.PaymentsId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 107 "C:\AMSproject\AMSproject\Views\PaymentTransactions\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.TransactionTypDefenition));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 110 "C:\AMSproject\AMSproject\Views\PaymentTransactions\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.Explanation));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n\r\n                        <td>\r\n                            ");
#nullable restore
#line 114 "C:\AMSproject\AMSproject\Views\PaymentTransactions\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.Customer));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 117 "C:\AMSproject\AMSproject\Views\PaymentTransactions\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.Cash));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 120 "C:\AMSproject\AMSproject\Views\PaymentTransactions\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.CostTypDefenition));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 123 "C:\AMSproject\AMSproject\Views\PaymentTransactions\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.SupportTypDefenition));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 126 "C:\AMSproject\AMSproject\Views\PaymentTransactions\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.Number));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 129 "C:\AMSproject\AMSproject\Views\PaymentTransactions\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.PaymentDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 132 "C:\AMSproject\AMSproject\Views\PaymentTransactions\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                </tbody>
            </table>
        </div>
    </div>
</div>


<script>
    $(document).ready(function () {
        // Setup - add a text input to each footer cell
        $('#example thead tr').clone(true).appendTo('#example thead');
        $('#example thead tr:eq(1) th').each(function (i) {
            var title = $(this).text();
            $(this).html('<input type=""text"" />');

            $('input', this).on('keyup change', function () {
                if (table.column(i).search() !== this.value) {
                    table
                        .column(i)
                        .search(this.value)
                        .draw();
                }
            });
        });

        var table = $('#example').DataTable({
            orderCellsTop: true,
            fixedHeader: true
        });
    });
</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<AMS.Models.PaymentTransactions>> Html { get; private set; }
    }
}
#pragma warning restore 1591
