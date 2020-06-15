#pragma checksum "C:\AMSproject\AMSproject\Views\IncomeTypes\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "01752eccf958bb9c62ebcaaa9d0cf9853b94d63a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_IncomeTypes_Index), @"mvc.1.0.view", @"/Views/IncomeTypes/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"01752eccf958bb9c62ebcaaa9d0cf9853b94d63a", @"/Views/IncomeTypes/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e0d06f3f9fda07b3243119db3eda2fe7f055d65c", @"/Views/_ViewImports.cshtml")]
    public class Views_IncomeTypes_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ICollection<AMS.Models.IncomeType>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\AMSproject\AMSproject\Views\IncomeTypes\Index.cshtml"
  
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
                
                    Tənzimləmələr
                
            </li>
            <li class=""active"">
                Mədaxil/Məxaric
            </li>
            <li class=""active"">
                Mədaxil növü
            </li>
        </ol>
    </div>
</div>
<!-- end: BREADCRUMB -->
<!-- start: PAGE CONTENT -->




<div class=""panel panel-white"">
    <div class=""panel-heading"">

        <a class=""btn btn-primary"" href=""#"" data-toggle=""modal"" data-target=""#customer1"" onclick=""AddNewIncomeType()""><i class=""fa fa-plus""></i> Yeni mədaxil növü</a>

        <div class=""panel-tools"">
            <div class=""dropdown"">
                <a data-toggle=""dropdown"" class=""btn btn-xs dropdown-toggle btn-transparent-grey"">
                    <i class=""fa fa-cog""></i>
       ");
            WriteLiteral(@"         </a>
                <ul class=""dropdown-menu dropdown-light pull-right"" role=""menu"">
                    <li>
                        <a class=""panel-expand"" href=""#"">
                            <i class=""fa fa-expand""></i> <span>Fullscreen</span>
                        </a>
                    </li>
                </ul>
            </div>
        </div>
    </div>


    <div class=""panel-body"">
        <div class=""table-responsive table-responsive-lg table-responsive-md table-responsive-sm table-responsive-xl"" style=""margin-bottom:0%"" ;>
            <table class=""table table-bordered table-hover display"" id=""example"" style=""width:99.8%"">
");
            WriteLiteral("                <thead>\r\n                    <tr>\r\n                        <th>Açıqlama</th>\r\n                        <th></th>\r\n                    </tr>\r\n                </thead>\r\n                <tbody>\r\n");
#nullable restore
#line 69 "C:\AMSproject\AMSproject\Views\IncomeTypes\Index.cshtml"
                     foreach (var item in Model)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n                            <td>");
#nullable restore
#line 72 "C:\AMSproject\AMSproject\Views\IncomeTypes\Index.cshtml"
                           Write(Html.DisplayFor(modelItem => item.Defenition));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</td>
                            <td class=""center"">
                                <div class=""visible-md visible-lg hidden-sm hidden-xs"">
                                    <a class=""btn btn-xs btn-blue tooltips"" data-placement=""top"" data-original-title=""Dəyişdir""");
            BeginWriteAttribute("onclick", " onclick=\"", 2640, "\"", 2674, 3);
            WriteAttributeValue("", 2650, "EditIncomeType(", 2650, 15, true);
#nullable restore
#line 75 "C:\AMSproject\AMSproject\Views\IncomeTypes\Index.cshtml"
WriteAttributeValue("", 2665, item.Id, 2665, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2673, ")", 2673, 1, true);
            EndWriteAttribute();
            WriteLiteral(@"><i class=""fa fa-edit""></i></a>
                                    <a href=""#"" class=""btn btn-xs btn-red tooltips"" data-placement=""top"" data-original-title=""Sil""><i class=""fa fa-times fa fa-white""></i></a>
                                </div>
                                <div class=""visible-xs visible-sm hidden-md hidden-lg"">
                                    <div class=""btn-group"">
                                        <a class=""btn btn-green dropdown-toggle btn-sm"" data-toggle=""dropdown"" href=""#"">
                                            <i class=""fa fa-cog""></i> <span class=""caret""></span>
                                        </a>
                                        <ul role=""menu"" class=""dropdown-menu pull-right dropdown-dark"">
                                            <li>
                                                <a role=""menuitem"" tabindex=""-1""");
            BeginWriteAttribute("onclick", " onclick=\"", 3576, "\"", 3610, 3);
            WriteAttributeValue("", 3586, "EditIncomeType(", 3586, 15, true);
#nullable restore
#line 85 "C:\AMSproject\AMSproject\Views\IncomeTypes\Index.cshtml"
WriteAttributeValue("", 3601, item.Id, 3601, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3609, ")", 3609, 1, true);
            EndWriteAttribute();
            WriteLiteral(@">
                                                    <i class=""fa fa-edit""></i> Dəyişdir
                                                </a>
                                            </li>
                                            <li>
                                                <a role=""menuitem"" tabindex=""-1"" href=""#"">
                                                    <i class=""fa fa-times""></i> Sil
                                                </a>
                                            </li>
                                        </ul>
                                    </div>
                                </div>
                            </td>
                        </tr>
");
#nullable restore
#line 99 "C:\AMSproject\AMSproject\Views\IncomeTypes\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                </tbody>
            </table>
        </div>
    </div>
</div>




<div class=""modal fade"" id=""NewIncomeType"">
    <div class=""modal-dialog"" >
        <div class=""modal-content"">
            <div class=""modal-header"">
                <a href=""#"" class=""close"" data-dismiss=""modal"">&times;</a>
                <h4><i class=""fa fa-money""></i>&nbsp; Yeni mədaxil növü</h4>
            </div>
            <div class=""modal-body"" id=""myNewIncomeType"">

            </div>
        </div>
    </div>
</div>

<div class=""modal fade"" id=""EditIncomeType"">
    <div class=""modal-dialog"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <a href=""#"" class=""close"" data-dismiss=""modal"">&times;</a>
                <h4><i class=""fa fa-money""></i>&nbsp; Mədaxil növü (dəyişdir)</h4>
            </div>
            <div class=""modal-body"" id=""myEditIncomeType"">

            </div>
        </div>
    </div>
</div>


<script>

    function Ad");
            WriteLiteral(@"dNewIncomeType() {
        var url = ""/IncomeTypes/NewIncomeType"";
        $(""#myNewIncomeType"").load(url, function () {
            $(""#NewIncomeType"").modal(""show"");
        })
    }
    function EditIncomeType(id) {
        var url = ""/IncomeTypes/EditIncomeType?id="" + id;
        $(""#myEditIncomeType"").load(url, function () {
            $(""#EditIncomeType"").modal(""show"");
        })
    }


</script>





<!-- end: PAGE CONTENT-->
<!--Modal add new building-->
<!--New building end-->
<!--New building end-->
");
            WriteLiteral("\r\n\r\n");
            WriteLiteral(@"

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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ICollection<AMS.Models.IncomeType>> Html { get; private set; }
    }
}
#pragma warning restore 1591