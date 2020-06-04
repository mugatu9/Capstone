#pragma checksum "C:\Users\sajan\source\repos\Capstone\CSD480Group3Capstone001\Views\Units\_UnitAccordion.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e0b4748cd04462448dc92ce6c47dfbe29da6bb04"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Units__UnitAccordion), @"mvc.1.0.view", @"/Views/Units/_UnitAccordion.cshtml")]
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
#line 1 "C:\Users\sajan\source\repos\Capstone\CSD480Group3Capstone001\Views\Units\_UnitAccordion.cshtml"
using System.Runtime.CompilerServices;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\sajan\source\repos\Capstone\CSD480Group3Capstone001\Views\Units\_UnitAccordion.cshtml"
using System.Text;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\sajan\source\repos\Capstone\CSD480Group3Capstone001\Views\Units\_UnitAccordion.cshtml"
using CSD480Group3Capstone001.Controllers;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e0b4748cd04462448dc92ce6c47dfbe29da6bb04", @"/Views/Units/_UnitAccordion.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b84f6cdf9f28b937e6ee447ec9f2a02f1e99e744", @"/Views/_ViewImports.cshtml")]
    public class Views_Units__UnitAccordion : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<CSD480Group3Capstone001.Models.Unit>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n\r\n<div class=\"row accordion mt-2\" id=\"tenantAccordion\">\r\n");
#nullable restore
#line 9 "C:\Users\sajan\source\repos\Capstone\CSD480Group3Capstone001\Views\Units\_UnitAccordion.cshtml"
          
            int index = 0;
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\sajan\source\repos\Capstone\CSD480Group3Capstone001\Views\Units\_UnitAccordion.cshtml"
         foreach (var unit in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"col-11 ml-auto mr-auto\">\r\n                <div class=\"card-header row border border-dark rounded p-0 mt-2\"");
            BeginWriteAttribute("id", " id=\"", 452, "\"", 488, 1);
#nullable restore
#line 15 "C:\Users\sajan\source\repos\Capstone\CSD480Group3Capstone001\Views\Units\_UnitAccordion.cshtml"
WriteAttributeValue("", 457, GetAccordionId("header",index), 457, 31, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                    <div class=\"col-12 d-flex\">\r\n                        <div class=\"p-2 text-center\">\r\n                            <span class=\"font-weight-bold p-2\">Unit Number</span>\r\n                            <br />#");
#nullable restore
#line 19 "C:\Users\sajan\source\repos\Capstone\CSD480Group3Capstone001\Views\Units\_UnitAccordion.cshtml"
                              Write(unit.UnitNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </div>\r\n                        <div class=\"p-2 text-center\">\r\n                            <span class=\"font-weight-bold\">Building Address</span>\r\n                            <br />#");
#nullable restore
#line 23 "C:\Users\sajan\source\repos\Capstone\CSD480Group3Capstone001\Views\Units\_UnitAccordion.cshtml"
                              Write(unit.Building.Address);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </div>\r\n                        <div class=\"p-2 text-center d-none d-sm-block\">\r\n                            <span class=\"font-weight-bold\">Number of Tenants</span>\r\n                            <br />");
#nullable restore
#line 27 "C:\Users\sajan\source\repos\Capstone\CSD480Group3Capstone001\Views\Units\_UnitAccordion.cshtml"
                             Write(unit.TenantUnits.Count());

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </div>\r\n                        <div class=\"p-2 text-center d-none d-sm-block\">\r\n                            <span class=\"font-weight-bold\">Square Footage</span>\r\n                            <br />");
#nullable restore
#line 31 "C:\Users\sajan\source\repos\Capstone\CSD480Group3Capstone001\Views\Units\_UnitAccordion.cshtml"
                             Write(unit.SqrFootage);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </div>\r\n                        <div class=\"p-2 ml-auto align-self-center\">\r\n                            <button");
            BeginWriteAttribute("id", " id=\"", 1588, "\"", 1624, 1);
#nullable restore
#line 34 "C:\Users\sajan\source\repos\Capstone\CSD480Group3Capstone001\Views\Units\_UnitAccordion.cshtml"
WriteAttributeValue("", 1593, GetAccordionId("expand",index), 1593, 31, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn-sm border border-dark btn-primary d-inline\" type=\"button\" aria-expanded=\"false\" data-toggle=\"collapse\" data-target=\"#");
#nullable restore
#line 34 "C:\Users\sajan\source\repos\Capstone\CSD480Group3Capstone001\Views\Units\_UnitAccordion.cshtml"
                                                                                                                                                                                                    Write(GetAccordionId("body",index));

#line default
#line hidden
#nullable disable
            WriteLiteral(",");
#nullable restore
#line 34 "C:\Users\sajan\source\repos\Capstone\CSD480Group3Capstone001\Views\Units\_UnitAccordion.cshtml"
                                                                                                                                                                                                                                  Write(GetAccordionId("expand",index));

#line default
#line hidden
#nullable disable
            WriteLiteral(",");
#nullable restore
#line 34 "C:\Users\sajan\source\repos\Capstone\CSD480Group3Capstone001\Views\Units\_UnitAccordion.cshtml"
                                                                                                                                                                                                                                                                  Write(GetAccordionId("hide",index));

#line default
#line hidden
#nullable disable
            WriteLiteral("\"");
            BeginWriteAttribute("aria-controls", " aria-controls=\"", 1846, "\"", 1891, 1);
#nullable restore
#line 34 "C:\Users\sajan\source\repos\Capstone\CSD480Group3Capstone001\Views\Units\_UnitAccordion.cshtml"
WriteAttributeValue("", 1862, GetAccordionId("body",index), 1862, 29, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Expand</button>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n                <div");
            BeginWriteAttribute("id", " id=\"", 2014, "\"", 2048, 1);
#nullable restore
#line 38 "C:\Users\sajan\source\repos\Capstone\CSD480Group3Capstone001\Views\Units\_UnitAccordion.cshtml"
WriteAttributeValue("", 2019, GetAccordionId("body",index), 2019, 29, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"collapse\"");
            BeginWriteAttribute("aria-labelledby", " aria-labelledby=\"", 2066, "\"", 2115, 1);
#nullable restore
#line 38 "C:\Users\sajan\source\repos\Capstone\CSD480Group3Capstone001\Views\Units\_UnitAccordion.cshtml"
WriteAttributeValue("", 2084, GetAccordionId("header",index), 2084, 31, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" data-parent=\"#tenantAccordion\">\r\n                    <div class=\"card-body\">\r\n                        ");
#nullable restore
#line 40 "C:\Users\sajan\source\repos\Capstone\CSD480Group3Capstone001\Views\Units\_UnitAccordion.cshtml"
                   Write(await Html.PartialAsync("~/Views/Units/_DisplayUnit.cshtml", unit, new ViewDataDictionary(ViewData)));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 44 "C:\Users\sajan\source\repos\Capstone\CSD480Group3Capstone001\Views\Units\_UnitAccordion.cshtml"
            index++;
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n\r\n\r\n\r\n\r\n\r\n");
        }
        #pragma warning restore 1998
#nullable restore
#line 52 "C:\Users\sajan\source\repos\Capstone\CSD480Group3Capstone001\Views\Units\_UnitAccordion.cshtml"
           
    private string GetAccordionId(string str,int num)
    {
        return str + num.ToString();
    }

    private void DisplaySearchedCat()
    {
        List<string> searchAreas = (List<string>)ViewData["searchAreas"];
        string searchBy = (string)ViewData["searchBy"];

        if (!string.IsNullOrEmpty(searchBy))
        {
            if (!searchBy.Equals(searchAreas[0]))//Do nothing Name is always displayed
            {
                

            }else if (searchBy.Equals(searchAreas[1]))//License Plate
            {

            }
        }
    }

#line default
#line hidden
#nullable disable
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
