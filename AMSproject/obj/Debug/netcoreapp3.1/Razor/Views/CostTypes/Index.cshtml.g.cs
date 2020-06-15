#pragma checksum "C:\AMSproject\AMSproject\Views\CostTypes\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "42a7ea1e382505110f077debde5327c9c8742cfc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_CostTypes_Index), @"mvc.1.0.view", @"/Views/CostTypes/Index.cshtml")]
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
#nullable restore
#line 2 "C:\AMSproject\AMSproject\Views\CostTypes\Index.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"42a7ea1e382505110f077debde5327c9c8742cfc", @"/Views/CostTypes/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e0d06f3f9fda07b3243119db3eda2fe7f055d65c", @"/Views/_ViewImports.cshtml")]
    public class Views_CostTypes_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<AMS.Models.CostType>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 5 "C:\AMSproject\AMSproject\Views\CostTypes\Index.cshtml"
  
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

<!-- start: BREADCRUMB -->
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
                Məxaric növü
            </li>
        </ol>
    </div>
</div>
<!-- end: BREADCRUMB -->
<!-- start: PAGE CONTENT -->



<div class=""panel panel-white"">
    <div class=""panel-heading"">

        <a class=""btn btn-primary"" href=""#"" data-toggle=""modal"" data-target=""#customer1"" onclick=""AddNewCostType()""><i class=""fa fa-plus""></i> Yeni məxaric növü</a>

        <div class=""panel-tools"">
            <div class=""dropdown"">
                <a data-toggle=""dropdown"" class=""btn btn-xs dropdown-toggle btn-transparent-grey"">
                    <i class=""fa fa-cog""></i>
                </a>
               ");
            WriteLiteral(@" <ul class=""dropdown-menu dropdown-light pull-right"" role=""menu"">
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
#line 72 "C:\AMSproject\AMSproject\Views\CostTypes\Index.cshtml"
                     foreach (var item in Model)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n                            <td>");
#nullable restore
#line 75 "C:\AMSproject\AMSproject\Views\CostTypes\Index.cshtml"
                           Write(Html.DisplayFor(modelItem => item.Defenition));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td class=\"center\">\r\n                                <div class=\"visible-md visible-lg hidden-sm hidden-xs\">\r\n");
#nullable restore
#line 78 "C:\AMSproject\AMSproject\Views\CostTypes\Index.cshtml"
                                     if (CheckPermission.CheckRole(HttpContextAccessor.HttpContext.Session.GetString("_User"), "1.2.1.1") || CheckPermission.IsAdmin(HttpContextAccessor.HttpContext.Session.GetString("_User")))
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("<a class=\"btn btn-xs btn-blue tooltips\" data-placement=\"top\" data-original-title=\"Dəyişdir\"");
            BeginWriteAttribute("onclick", " onclick=\"", 2946, "\"", 2978, 3);
            WriteAttributeValue("", 2956, "EditCostType(", 2956, 13, true);
#nullable restore
#line 79 "C:\AMSproject\AMSproject\Views\CostTypes\Index.cshtml"
WriteAttributeValue("", 2969, item.Id, 2969, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2977, ")", 2977, 1, true);
            EndWriteAttribute();
            WriteLiteral("><i class=\"fa fa-edit\"></i></a>");
#nullable restore
#line 79 "C:\AMSproject\AMSproject\Views\CostTypes\Index.cshtml"
                                                                                                                                                                                                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 80 "C:\AMSproject\AMSproject\Views\CostTypes\Index.cshtml"
                                     if (CheckPermission.CheckRole(HttpContextAccessor.HttpContext.Session.GetString("_User"), "1.2.1.2") || CheckPermission.IsAdmin(HttpContextAccessor.HttpContext.Session.GetString("_User")))
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("<a href=\"#\" class=\"btn btn-xs btn-red tooltips\" data-placement=\"top\" data-original-title=\"Sil\"><i class=\"fa fa-times fa fa-white\"></i></a>");
#nullable restore
#line 81 "C:\AMSproject\AMSproject\Views\CostTypes\Index.cshtml"
                                                                                                                                                                               }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                </div>
                                <div class=""visible-xs visible-sm hidden-md hidden-lg"">
                                    <div class=""btn-group"">
                                        <a class=""btn btn-green dropdown-toggle btn-sm"" data-toggle=""dropdown"" href=""#"">
                                            <i class=""fa fa-cog""></i> <span class=""caret""></span>
                                        </a>
                                        <ul role=""menu"" class=""dropdown-menu pull-right dropdown-dark"">
                                            <li>
                                                <a role=""menuitem"" tabindex=""-1""");
            BeginWriteAttribute("onclick", " onclick=\"", 4110, "\"", 4142, 3);
            WriteAttributeValue("", 4120, "EditCostType(", 4120, 13, true);
#nullable restore
#line 90 "C:\AMSproject\AMSproject\Views\CostTypes\Index.cshtml"
WriteAttributeValue("", 4133, item.Id, 4133, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 4141, ")", 4141, 1, true);
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
#line 104 "C:\AMSproject\AMSproject\Views\CostTypes\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                </tbody>
            </table>
        </div>
    </div>
</div>




<div class=""modal fade"" id=""NewCostType"">
    <div class=""modal-dialog"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <a href=""#"" class=""close"" data-dismiss=""modal"">&times;</a>
                <h4><i class=""fa fa-money""></i>&nbsp; Xərc növü</h4>
            </div>
            <div class=""modal-body"" id=""myNewCostType"">

            </div>
        </div>
    </div>
</div>

<div class=""modal fade"" id=""EditCostType"">
    <div class=""modal-dialog"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <a href=""#"" class=""close"" data-dismiss=""modal"">&times;</a>
                <h4><i class=""fa fa-money""></i>&nbsp; Xərc növü (dəyişdir)</h4>
            </div>
            <div class=""modal-body"" id=""myEditCostType"">

            </div>
        </div>
    </div>
</div>


<script>

    function AddNewCostType() {
  ");
            WriteLiteral(@"      var url = ""/CostTypes/NewCostType"";
        $(""#myNewCostType"").load(url, function () {
            $(""#NewCostType"").modal(""show"");
        })
    }
    function EditCostType(id) {
        var url = ""/CostTypes/EditCostType?id="" + id;
        $(""#myEditCostType"").load(url, function () {
            $(""#EditCostType"").modal(""show"");
        })
    }
    //function DeleteBuilding(id) {
    //    var url = ""/Buildings/DeleteBuilding?id="" + id;
    //    $(""#myEditBuilding"").load(url, function () {
    //        $(""#EditBuilding"").modal(""show"");
    //    })
    //}


    //function EditBuildingRecord(id) {
    //    var url = ""/Buildings/GetBuilding?id="" + id;
    //    //$(""#ModalTitle"").html(""Update Student Record"");
    //    $(""#customer1"").modal();
    //    $.ajax({
    //        type: ""GET"",
    //        url: url,
    //        success: function (data) {
    //            var obj = JSON.parse(data);

    //            $(""#id"").val(obj.Id);
    //            $(""#number");
            WriteLiteral(@""").val(obj.Number);
    //            $(""#address"").val(obj.Address);
    //        }
    //    })
    //}

    //var DeleteBuildingRecord = function (id) {
    //    $(""#id"").val(id);
    //    $(""#DeleteConfirmation"").modal(""show"");
    //}
    //var ConfirmDelete = function () {
    //    var BuildId = $(""#id"").val();
    //    $.ajax({
    //        type: ""POST"",
    //        url: ""/Buildings/DeleteBuildingRecord?id="" + BuildId,
    //        success: function (result) {
    //            $(""#DeleteConfirmation"").modal(""hide"");
    //            $("".row_"" + BuildId).remove();
    //            alert(""Əməliyyat uğurla tamamlandı!"");
    //        }
    //    })
    //}

</script>



");
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
        public Microsoft.AspNetCore.Http.IHttpContextAccessor HttpContextAccessor { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<AMS.Models.CostType>> Html { get; private set; }
    }
}
#pragma warning restore 1591
