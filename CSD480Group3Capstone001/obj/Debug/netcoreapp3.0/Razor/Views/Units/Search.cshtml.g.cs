#pragma checksum "C:\Users\sajan\source\repos\Capstone\CSD480Group3Capstone001\Views\Units\Search.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bbedb039951665ae06918bea6d753ef37dd3cd2d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Units_Search), @"mvc.1.0.view", @"/Views/Units/Search.cshtml")]
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
#line 1 "C:\Users\sajan\source\repos\Capstone\CSD480Group3Capstone001\Views\_ViewImports.cshtml"
using CSD480Group3Capstone001;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\sajan\source\repos\Capstone\CSD480Group3Capstone001\Views\_ViewImports.cshtml"
using CSD480Group3Capstone001.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\sajan\source\repos\Capstone\CSD480Group3Capstone001\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\sajan\source\repos\Capstone\CSD480Group3Capstone001\Views\Units\Search.cshtml"
using CSD480Group3Capstone001.Controllers;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bbedb039951665ae06918bea6d753ef37dd3cd2d", @"/Views/Units/Search.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b84f6cdf9f28b937e6ee447ec9f2a02f1e99e744", @"/Views/_ViewImports.cshtml")]
    public class Views_Units_Search : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<CSD480Group3Capstone001.Models.Unit>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("row col-12 ml-auto mr-auto p-0"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Units", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 5 "C:\Users\sajan\source\repos\Capstone\CSD480Group3Capstone001\Views\Units\Search.cshtml"
  
    ViewData["Title"] = "Units";
    Layout = "~/Views/Shared/_LayoutUser.cshtml";

    /*
     *
     *
     */


#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n<div class=\"border border-dark rounded p-2 pt-3\">\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bbedb039951665ae06918bea6d753ef37dd3cd2d5262", async() => {
                WriteLiteral("\r\n        <div class=\"col-12 d-flex p-0 flex-wrap\">\r\n            <button type=\"submit\" class=\"btn-sm border border-dark btn-primary ml-1 mr-1 mb-1\">Search</button>\r\n");
#nullable restore
#line 22 "C:\Users\sajan\source\repos\Capstone\CSD480Group3Capstone001\Views\Units\Search.cshtml"
              
                if (!string.IsNullOrEmpty((string)ViewData["searchString"]))
                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <input type=\"search\" name=\"searchString\" class=\"pl-2 rounded border border-dark flex-grow-1 ml-1 mr-1 mb-1\"");
                BeginWriteAttribute("value", " value=\"", 788, "\"", 821, 1);
#nullable restore
#line 25 "C:\Users\sajan\source\repos\Capstone\CSD480Group3Capstone001\Views\Units\Search.cshtml"
WriteAttributeValue("", 796, ViewData["searchString"], 796, 25, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n");
#nullable restore
#line 26 "C:\Users\sajan\source\repos\Capstone\CSD480Group3Capstone001\Views\Units\Search.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <input type=\"search\" name=\"searchString\" class=\"pl-2 rounded border border-dark flex-grow-1 ml-1 mr-1 mb-1\"");
                BeginWriteAttribute("value", " value=\"", 1014, "\"", 1022, 0);
                EndWriteAttribute();
                WriteLiteral(" />\r\n");
#nullable restore
#line 30 "C:\Users\sajan\source\repos\Capstone\CSD480Group3Capstone001\Views\Units\Search.cshtml"
                }
            

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            <div class=\"flex-grow-1 ml-1 mr-1 mb-1\">\r\n                <select class=\"custom-select border-dark\" name=\"searchBy\" id=\"searchForSelect\">\r\n");
#nullable restore
#line 35 "C:\Users\sajan\source\repos\Capstone\CSD480Group3Capstone001\Views\Units\Search.cshtml"
                      

                        List<string> searchAreas = UnitsController.GetSearchAreas();

                        string searchBy = (string)ViewData["searchBy"];
                        if (!string.IsNullOrEmpty(searchBy))
                        {
                            if (searchAreas.Contains(searchBy))
                            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bbedb039951665ae06918bea6d753ef37dd3cd2d8109", async() => {
#nullable restore
#line 44 "C:\Users\sajan\source\repos\Capstone\CSD480Group3Capstone001\Views\Units\Search.cshtml"
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
#line 44 "C:\Users\sajan\source\repos\Capstone\CSD480Group3Capstone001\Views\Units\Search.cshtml"
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
#line 45 "C:\Users\sajan\source\repos\Capstone\CSD480Group3Capstone001\Views\Units\Search.cshtml"
                                searchAreas.Remove(searchBy);
                            }
                        }

                        foreach (string str in searchAreas)
                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bbedb039951665ae06918bea6d753ef37dd3cd2d10786", async() => {
#nullable restore
#line 51 "C:\Users\sajan\source\repos\Capstone\CSD480Group3Capstone001\Views\Units\Search.cshtml"
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
#line 51 "C:\Users\sajan\source\repos\Capstone\CSD480Group3Capstone001\Views\Units\Search.cshtml"
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
#line 52 "C:\Users\sajan\source\repos\Capstone\CSD480Group3Capstone001\Views\Units\Search.cshtml"
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
#line 59 "C:\Users\sajan\source\repos\Capstone\CSD480Group3Capstone001\Views\Units\Search.cshtml"
      
        if (Model.Any())
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 62 "C:\Users\sajan\source\repos\Capstone\CSD480Group3Capstone001\Views\Units\Search.cshtml"
       Write(await Html.PartialAsync("~/Views/Units/_UnitAccordion.cshtml", Model, new ViewDataDictionary(ViewData)));

#line default
#line hidden
#nullable disable
#nullable restore
#line 62 "C:\Users\sajan\source\repos\Capstone\CSD480Group3Capstone001\Views\Units\Search.cshtml"
                                                                                                                    ;
        }
        else
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <p>No Tenants match the search parameters</p>\r\n");
#nullable restore
#line 67 "C:\Users\sajan\source\repos\Capstone\CSD480Group3Capstone001\Views\Units\Search.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<CSD480Group3Capstone001.Models.Unit>> Html { get; private set; }
    }
}
#pragma warning restore 1591
