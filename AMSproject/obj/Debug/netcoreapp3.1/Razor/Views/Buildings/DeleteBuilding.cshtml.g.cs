#pragma checksum "C:\AMSproject\AMSproject\Views\Buildings\DeleteBuilding.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9ec667e2d98fe1c15749b8171af12d3ff35f8950"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Buildings_DeleteBuilding), @"mvc.1.0.view", @"/Views/Buildings/DeleteBuilding.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9ec667e2d98fe1c15749b8171af12d3ff35f8950", @"/Views/Buildings/DeleteBuilding.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e0d06f3f9fda07b3243119db3eda2fe7f055d65c", @"/Views/_ViewImports.cshtml")]
    public class Views_Buildings_DeleteBuilding : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<AMS.Models.ContractDetail>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("NewOrderForm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n\r\n<div>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9ec667e2d98fe1c15749b8171af12d3ff35f89503582", async() => {
                WriteLiteral("\r\n        <div class=\"modal-body\">\r\n");
                WriteLiteral(@"            <h5 style=""color:#ff6347"">Müqavilə</h5>
            <hr />
          
        </div>
        <div class=""modal-footer"">
            <button type=""reset"" class=""btn btn-default"" data-dismiss=""modal"">Ləğv et</button>
            <button id=""saveOrder"" type=""submit"" class=""btn btn-danger"">Yadda saxla</button>
        </div>
    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
</div>



<script type=""text/javascript"">

    $(""#addToList"").click(function (e) {
        e.preventDefault();

        //console.log($(""#supportType"").val());

        //console.log(document.getElementById(""test"").value);
        //console.log($(""#servicePrice"").val());

        if ($.trim($(""#supportTyp"").val()) == """" || $.trim($(""#obj"").val()) == """" || $.trim($(""#servicePrc"").val()) == """") return;

        var SupportTypeId = $(""#supportTyp"").val(),
            ObjectsId = $(""#obj"").val(),
            ServicePrice = $(""#servicePrc"").val(),
            detailsTableBody = $(""#detailsTable tbody"");

        var productItem = '<tr><td>' + SupportTypeId + '</td><td>' + ServicePrice + '</td><td>' + ObjectsId + '</td><td><a data-itemId=""0"" href=""#"" class=""deleteItem"">Sil</a></td></tr>';

        detailsTableBody.append(productItem);
        clearItem();
    });
    //After Add A New Order In The List, Clear Clean The Form For Add More Order.
    function clearItem() {
        $(""#su");
            WriteLiteral(@"pportTyp"").val('');
        $(""#obj"").val('');
        $(""#servicePrc"").val('');
    }
    // After Add A New Order In The List, If You Want, You Can Remove It.
    $(document).on('click', 'a.deleteItem', function (e) {
        e.preventDefault();
        var $self = $(this);
        if ($(this).attr('data-itemId') == ""0"") {
            $(this).parents('tr').css(""background-color"", ""#ff6347"").fadeOut(800, function () {
                $(this).remove();
            });
        }
    });





    function saveOrder(data) {
        return $.ajax({
            method: 'post',
            url: ""/Contracts/SaveContract"",
            data: data,
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            success: function (result) {
                alert(result);
                location.reload();
            },
            error: function () {
                alert(""Error!"")
            }
        });
    }

    $(""#saveOrder"").click(funct");
            WriteLiteral(@"ion (e) {
        e.preventDefault();

        var orderArr = [];
        var variables = [];
        orderArr.length = 0;

        $.each($(""#detailsTable tbody tr""), function () {
            orderArr.push({
                SupportTypeId: parseInt($(this).find('td:eq(0)').html()),
                ServicePrice: parseFloat($(this).find('td:eq(1)').html()),
                ObjectsId: parseInt($(this).find('td:eq(2)').html())
            });
            //variables.push({
            //    customer: parseInt($(""#cust"").val()),
            //    notes: parseInt($(""#note"").val()),
            //    paymentDate: parseInt($(""#payDate"").val())
            //});

        });




        //var data = orderArr + variables;


        var data = JSON.stringify({
            contractDetails: orderArr,
            CustomersId: parseInt($(""#cust"").val()),
            Notes: $(""#note"").val(),
            PaymentDate: $(""#payDate"").val()
        })

        //console.log(data);


        $");
            WriteLiteral(".when(saveOrder(data)).then(function (response) {\r\n            console.log(response);\r\n        }).fail(function (err) {\r\n            console.log(err);\r\n        });\r\n    });\r\n\r\n\r\n</script>\r\n\r\n\r\n\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 166 "C:\AMSproject\AMSproject\Views\Buildings\DeleteBuilding.cshtml"
      await Html.RenderPartialAsync("_ValidationScriptsPartial");

#line default
#line hidden
#nullable disable
            }
            );
            WriteLiteral("\r\n\r\n\r\n\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AMS.Models.ContractDetail> Html { get; private set; }
    }
}
#pragma warning restore 1591
