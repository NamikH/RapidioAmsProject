#pragma checksum "C:\AMSproject\AMSproject\Views\Objects\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bff698ccbd3ce689f19192a6b9d04b338a8e63d8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Objects_Index), @"mvc.1.0.view", @"/Views/Objects/Index.cshtml")]
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
#line 2 "C:\AMSproject\AMSproject\Views\Objects\Index.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bff698ccbd3ce689f19192a6b9d04b338a8e63d8", @"/Views/Objects/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e0d06f3f9fda07b3243119db3eda2fe7f055d65c", @"/Views/_ViewImports.cshtml")]
    public class Views_Objects_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<AMS.Models.Objects>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "1", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "2", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "3", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("text-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "CostCreate", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", new global::Microsoft.AspNetCore.Html.HtmlString("myForm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("onsubmit", new global::Microsoft.AspNetCore.Html.HtmlString("return validateForm()"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 5 "C:\AMSproject\AMSproject\Views\Objects\Index.cshtml"
  
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

<!-- end: TOOLBAR -->
<!-- end: PAGE HEADER -->
<!-- start: BREADCRUMB -->
<div class=""row"">
    <div class=""col-md-12"">
        <ol class=""breadcrumb"">
            <li class=""active"">

                Tənzimləmələr

            </li>
            <li class=""active"">
                Obyekt parametrləri
            </li>
            <li class=""active"">
                Obyektlər
            </li>
        </ol>
    </div>
</div>
<!-- end: BREADCRUMB -->
<!-- start: PAGE CONTENT -->





<div class=""panel panel-white"">
    <div class=""panel-heading"">

        <a class=""btn btn-primary"" href=""#"" data-toggle=""modal"" data-target=""#customer1"" onclick=""AddNewObject()""><i class=""fa fa-plus""></i> Yeni obyekt</a>

        <div class=""panel-tools"">
            <div class=""dropdown"">
                <a data-toggle=""dropdown"" class=""btn btn-xs dropdown-toggle btn-transparent-grey"">
                    <i class=""fa fa-cog");
            WriteLiteral(@"""></i>
                </a>
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
            WriteLiteral(@"                <thead>
                    <tr>
                        <th>Blok</th>
                        <th>Mərtəbə</th>
                        <th>Obyekt №</th>
                        <th>M²</th>
                        <th>Bina</th>
                        <th>Obyekt növü</th>
                        <th></th>
                    </tr>
                </thead>
                <tbody>
");
#nullable restore
#line 80 "C:\AMSproject\AMSproject\Views\Objects\Index.cshtml"
                     foreach (var item in Model)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n                            <td>");
#nullable restore
#line 83 "C:\AMSproject\AMSproject\Views\Objects\Index.cshtml"
                           Write(Html.DisplayFor(modelItem => item.Porch));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 84 "C:\AMSproject\AMSproject\Views\Objects\Index.cshtml"
                           Write(Html.DisplayFor(modelItem => item.Floor));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 85 "C:\AMSproject\AMSproject\Views\Objects\Index.cshtml"
                           Write(Html.DisplayFor(modelItem => item.Number));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 86 "C:\AMSproject\AMSproject\Views\Objects\Index.cshtml"
                           Write(Html.DisplayFor(modelItem => item.Squares));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 87 "C:\AMSproject\AMSproject\Views\Objects\Index.cshtml"
                           Write(Html.DisplayFor(modelItem => item.Building.Address));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 88 "C:\AMSproject\AMSproject\Views\Objects\Index.cshtml"
                           Write(Html.DisplayFor(modelItem => item.ObjectType.Defenition));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td class=\"center\">\r\n                                <div class=\"visible-md visible-lg hidden-sm hidden-xs\">\r\n");
#nullable restore
#line 91 "C:\AMSproject\AMSproject\Views\Objects\Index.cshtml"
                                     if (CheckPermission.CheckRole(HttpContextAccessor.HttpContext.Session.GetString("_User"), "1.3.1.1") || CheckPermission.IsAdmin(HttpContextAccessor.HttpContext.Session.GetString("_User")))
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("<a class=\"btn btn-xs btn-blue tooltips\" data-placement=\"top\" data-original-title=\"Edit\"");
            BeginWriteAttribute("onclick", " onclick=\"", 3614, "\"", 3644, 3);
            WriteAttributeValue("", 3624, "EditObject(", 3624, 11, true);
#nullable restore
#line 92 "C:\AMSproject\AMSproject\Views\Objects\Index.cshtml"
WriteAttributeValue("", 3635, item.Id, 3635, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3643, ")", 3643, 1, true);
            EndWriteAttribute();
            WriteLiteral("><i class=\"fa fa-edit\"></i></a>");
#nullable restore
#line 92 "C:\AMSproject\AMSproject\Views\Objects\Index.cshtml"
                                                                                                                                                                                          }

#line default
#line hidden
#nullable disable
#nullable restore
#line 93 "C:\AMSproject\AMSproject\Views\Objects\Index.cshtml"
                                     if (CheckPermission.CheckRole(HttpContextAccessor.HttpContext.Session.GetString("_User"), "1.3.1.2") || CheckPermission.IsAdmin(HttpContextAccessor.HttpContext.Session.GetString("_User")))
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("<a href=\"#\" class=\"btn btn-xs btn-red tooltips\" data-placement=\"top\" data-original-title=\"Remove\"><i class=\"fa fa-times fa fa-white\"></i></a>");
#nullable restore
#line 94 "C:\AMSproject\AMSproject\Views\Objects\Index.cshtml"
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
            BeginWriteAttribute("onclick", " onclick=\"", 4779, "\"", 4809, 3);
            WriteAttributeValue("", 4789, "EditObject(", 4789, 11, true);
#nullable restore
#line 103 "C:\AMSproject\AMSproject\Views\Objects\Index.cshtml"
WriteAttributeValue("", 4800, item.Id, 4800, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 4808, ")", 4808, 1, true);
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
#line 117 "C:\AMSproject\AMSproject\Views\Objects\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                </tbody>
            </table>
        </div>
    </div>
</div>


<div hidden>
    <!-- end: TOOLBAR -->
    <!-- end: PAGE HEADER -->
    <!-- start: BREADCRUMB -->
    <!-- end: BREADCRUMB -->
    <!-- start: PAGE CONTENT -->
    <div class=""panel-white"" hidden>
        <div class=""panel-body"">


            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bff698ccbd3ce689f19192a6b9d04b338a8e63d815185", async() => {
                WriteLiteral(@"

                <div class=""form-group"">
                    <label class=""control-label"">Əməliyyat növün seçin</label>
                    <select id=""dropdown"" class=""form-control selectpicker"" data-live-search=""true"" name=""dropdown"" onchange=""Check(this)"">
                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bff698ccbd3ce689f19192a6b9d04b338a8e63d815746", async() => {
                    WriteLiteral("Ödənişlər");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bff698ccbd3ce689f19192a6b9d04b338a8e63d816997", async() => {
                    WriteLiteral("Məxaric");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bff698ccbd3ce689f19192a6b9d04b338a8e63d818246", async() => {
                    WriteLiteral("Mədaxil");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                    </select>\r\n                </div>\r\n            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            <!--t-->\r\n");
            WriteLiteral(@"            <!--t-->
        </div>
    </div>

    <div id=""costCreatte"" hidden>
        <div class=""panel-white"">
            <div class=""panel-heading"">
                <h3>Xərclər</h3>
            </div>
            <div class=""panel-body"">
                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bff698ccbd3ce689f19192a6b9d04b338a8e63d820850", async() => {
                WriteLiteral("\r\n                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("div", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bff698ccbd3ce689f19192a6b9d04b338a8e63d821129", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper);
#nullable restore
#line 167 "C:\AMSproject\AMSproject\Views\Objects\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper.ValidationSummary = global::Microsoft.AspNetCore.Mvc.Rendering.ValidationSummary.ModelOnly;

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-validation-summary", __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper.ValidationSummary, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                    <div class=""form-group"">
                        <label class=""control-label"" required>Məbləğ</label>
                        <input class=""form-control"" autocomplete=""off"" type=""number"" step=""0.01"" />
                        <span class=""text-danger""></span>
                    </div>
                    <div class=""form-group"">
                        <label class=""control-label"">Kimə</label>
                        <input value="" "" class=""form-control"" autocomplete=""off"" />
                        <span class=""text-danger""></span>
                    </div>
                    <div class=""form-group"">
                        <label class=""control-label"">Nə üçün</label>
                        <input value="" "" class=""form-control"" autocomplete=""off"" />
                        <span class=""text-danger""></span>
                    </div>
                    <div class=""form-group"">
                        <label class=""control-label"">Sənəd №</label>
                     ");
                WriteLiteral(@"   <input value="" "" class=""form-control"" autocomplete=""off"" />
                        <span class=""text-danger""></span>
                    </div>

                    <div class=""form-group mb-0"">
                        <div><button type=""submit"" class=""btn btn-primary waves-effect waves-light mr-1 "">Yadda saxla</button> </div>
                    </div>
                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
            </div>
        </div>
    </div>
</div>


<div class=""modal fade"" id=""NewObject"">
    <div class=""modal-dialog modal-lg"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <a href=""#"" class=""close"" data-dismiss=""modal"">&times;</a>
                <h4><i class=""fa fa-home""></i>&nbsp; Yeni obyekt</h4>
            </div>
            <div class=""modal-body"" id=""myNewObject"">

            </div>
        </div>
    </div>
</div>

<div class=""modal fade"" id=""EditObject"">
    <div class=""modal-dialog modal-lg"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <a href=""#"" class=""close"" data-dismiss=""modal"">&times;</a>
                <h4><i class=""fa fa-home""></i>&nbsp; Obyekt (dəyişdir)</h4>
            </div>
            <div class=""modal-body"" id=""myEditObject"">

            </div>
        </div>
    </div>
</div>


<script>
    function AddNewObject() {
        var url = ""/Objects/N");
            WriteLiteral(@"ewObject"";
        $(""#myNewObject"").load(url, function () {
            $(""#NewObject"").modal(""show"");
            $('.selectpicker').selectpicker();
        })
         
    }
    function EditObject(id) {
        var url = ""/Objects/EditObject?id="" + id;
        $(""#myEditObject"").load(url, function () {
            $(""#EditObject"").modal(""show"");
            $('.selectpicker').selectpicker();
        })
    }

</script>


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
         ");
            WriteLiteral("               .draw();\r\n                }\r\n            });\r\n        });\r\n\r\n        var table = $(\'#example\').DataTable({\r\n            orderCellsTop: true,\r\n            fixedHeader: true\r\n        });\r\n    });\r\n</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<AMS.Models.Objects>> Html { get; private set; }
    }
}
#pragma warning restore 1591
