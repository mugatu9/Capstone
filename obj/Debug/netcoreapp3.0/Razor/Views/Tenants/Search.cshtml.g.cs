#pragma checksum "C:\GitHub\May 14 ARTHUR\CSD480Group3Capstone001\Views\Tenants\Search.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8b114911383ddbe3c33c5fc4090018e8db89db9b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Tenants_Search), @"mvc.1.0.view", @"/Views/Tenants/Search.cshtml")]
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
#line 1 "C:\GitHub\May 14 ARTHUR\CSD480Group3Capstone001\Views\_ViewImports.cshtml"
using CSD480Group3Capstone001;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\GitHub\May 14 ARTHUR\CSD480Group3Capstone001\Views\_ViewImports.cshtml"
using CSD480Group3Capstone001.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\GitHub\May 14 ARTHUR\CSD480Group3Capstone001\Views\Tenants\Search.cshtml"
using CSD480Group3Capstone001.Controllers;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8b114911383ddbe3c33c5fc4090018e8db89db9b", @"/Views/Tenants/Search.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"aaa63d68d288c22042961e0f88ec427923ad4374", @"/Views/_ViewImports.cshtml")]
    public class Views_Tenants_Search : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<CSD480Group3Capstone001.Models.Tenant>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("row col-12 ml-auto mr-auto p-0"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Tenants", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Search", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 5 "C:\GitHub\May 14 ARTHUR\CSD480Group3Capstone001\Views\Tenants\Search.cshtml"
  

    ViewData["Title"] = "Tenants";
    Layout = "~/Views/Shared/_Layout.cshtml";

    /*
     *
     *
     */


#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n<div class=\"border border-dark rounded p-2\">\r\n    <h2>Tenant Search</h2>\r\n    <hr class=\"border-dark\" />\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8b114911383ddbe3c33c5fc4090018e8db89db9b5071", async() => {
                WriteLiteral("\r\n        <div class=\"col-12 d-flex p-0 flex-wrap\">\r\n            <button type=\"submit\" class=\"btn-sm border border-dark btn-primary ml-1 mr-1 mb-1\">Search</button>\r\n");
#nullable restore
#line 25 "C:\GitHub\May 14 ARTHUR\CSD480Group3Capstone001\Views\Tenants\Search.cshtml"
              
                if (!string.IsNullOrEmpty((string)ViewData["searchString"]))
                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <input type=\"search\" name=\"searchString\" class=\"pl-2 rounded border border-dark flex-grow-1 ml-1 mr-1 mb-1\"");
                BeginWriteAttribute("value", " value=\"", 847, "\"", 880, 1);
#nullable restore
#line 28 "C:\GitHub\May 14 ARTHUR\CSD480Group3Capstone001\Views\Tenants\Search.cshtml"
WriteAttributeValue("", 855, ViewData["searchString"], 855, 25, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n");
#nullable restore
#line 29 "C:\GitHub\May 14 ARTHUR\CSD480Group3Capstone001\Views\Tenants\Search.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <input type=\"search\" name=\"searchString\" class=\"pl-2 rounded border border-dark flex-grow-1 ml-1 mr-1 mb-1\"");
                BeginWriteAttribute("value", " value=\"", 1073, "\"", 1081, 0);
                EndWriteAttribute();
                WriteLiteral(" />\r\n");
#nullable restore
#line 33 "C:\GitHub\May 14 ARTHUR\CSD480Group3Capstone001\Views\Tenants\Search.cshtml"
                }
            

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            <div class=\"flex-grow-1 ml-1 mr-1 mb-1\">\r\n                <select class=\"custom-select border-dark\" name=\"searchBy\" id=\"searchForSelect\">\r\n");
#nullable restore
#line 38 "C:\GitHub\May 14 ARTHUR\CSD480Group3Capstone001\Views\Tenants\Search.cshtml"
                      

                        List<string> searchAreas = TenantsController.GetSearchAreas();

                        string searchBy = (string)ViewData["searchBy"];
                        if (!string.IsNullOrEmpty(searchBy))
                        {
                            if (searchAreas.Contains(searchBy))
                            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8b114911383ddbe3c33c5fc4090018e8db89db9b7865", async() => {
#nullable restore
#line 47 "C:\GitHub\May 14 ARTHUR\CSD480Group3Capstone001\Views\Tenants\Search.cshtml"
                                                              Write(searchBy);

#line default
#line hidden
#nullable disable
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("selected", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 47 "C:\GitHub\May 14 ARTHUR\CSD480Group3Capstone001\Views\Tenants\Search.cshtml"
                                            WriteLiteral(searchBy);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 48 "C:\GitHub\May 14 ARTHUR\CSD480Group3Capstone001\Views\Tenants\Search.cshtml"
                                searchAreas.Remove(searchBy);
                            }
                        }

                        foreach (string str in searchAreas)
                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8b114911383ddbe3c33c5fc4090018e8db89db9b10509", async() => {
#nullable restore
#line 54 "C:\GitHub\May 14 ARTHUR\CSD480Group3Capstone001\Views\Tenants\Search.cshtml"
                                            Write(str);

#line default
#line hidden
#nullable disable
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 54 "C:\GitHub\May 14 ARTHUR\CSD480Group3Capstone001\Views\Tenants\Search.cshtml"
                               WriteLiteral(str);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 55 "C:\GitHub\May 14 ARTHUR\CSD480Group3Capstone001\Views\Tenants\Search.cshtml"
                        }
                    

#line default
#line hidden
#nullable disable
                WriteLiteral("                </select>\r\n            </div>\r\n        </div>\r\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    <hr class=\"border-dark\" />\r\n");
#nullable restore
#line 62 "C:\GitHub\May 14 ARTHUR\CSD480Group3Capstone001\Views\Tenants\Search.cshtml"
      
        if (Model.Any())
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 65 "C:\GitHub\May 14 ARTHUR\CSD480Group3Capstone001\Views\Tenants\Search.cshtml"
       Write(await Html.PartialAsync("~/Views/Tenants/_TenantAccordion.cshtml", Model, new ViewDataDictionary(ViewData)));

#line default
#line hidden
#nullable disable
#nullable restore
#line 65 "C:\GitHub\May 14 ARTHUR\CSD480Group3Capstone001\Views\Tenants\Search.cshtml"
                                                                                                                        ;
        }
        else
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <p>No Tenants match the search parameters</p>\r\n");
#nullable restore
#line 70 "C:\GitHub\May 14 ARTHUR\CSD480Group3Capstone001\Views\Tenants\Search.cshtml"
        }
    

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n\r\n\r\n\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<CSD480Group3Capstone001.Models.Tenant>> Html { get; private set; }
    }
}
#pragma warning restore 1591
