#pragma checksum "C:\Users\sajan\source\repos\Capstone\CSD480Group3Capstone001\Views\ContractorsPage\_ContractorAccordion.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1c1fac739ecf17ceb2e13787e65726f5d2801979"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ContractorsPage__ContractorAccordion), @"mvc.1.0.view", @"/Views/ContractorsPage/_ContractorAccordion.cshtml")]
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
#line 1 "C:\Users\sajan\source\repos\Capstone\CSD480Group3Capstone001\Views\ContractorsPage\_ContractorAccordion.cshtml"
using System.Runtime.CompilerServices;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\sajan\source\repos\Capstone\CSD480Group3Capstone001\Views\ContractorsPage\_ContractorAccordion.cshtml"
using System.Text;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\sajan\source\repos\Capstone\CSD480Group3Capstone001\Views\ContractorsPage\_ContractorAccordion.cshtml"
using CSD480Group3Capstone001.Controllers;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1c1fac739ecf17ceb2e13787e65726f5d2801979", @"/Views/ContractorsPage/_ContractorAccordion.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b84f6cdf9f28b937e6ee447ec9f2a02f1e99e744", @"/Views/_ViewImports.cshtml")]
    public class Views_ContractorsPage__ContractorAccordion : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<CSD480Group3Capstone001.Models.Contractor>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n\r\n<div class=\"row accordion mt-2\" id=\"contractorAccordion\">\r\n");
#nullable restore
#line 9 "C:\Users\sajan\source\repos\Capstone\CSD480Group3Capstone001\Views\ContractorsPage\_ContractorAccordion.cshtml"
          
            int index = 0;
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\sajan\source\repos\Capstone\CSD480Group3Capstone001\Views\ContractorsPage\_ContractorAccordion.cshtml"
         foreach (var contractor in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"col-11 ml-auto mr-auto\">\r\n                <div class=\"card-header row border border-dark rounded p-0 mt-2\"");
            BeginWriteAttribute("id", " id=\"", 468, "\"", 505, 1);
#nullable restore
#line 15 "C:\Users\sajan\source\repos\Capstone\CSD480Group3Capstone001\Views\ContractorsPage\_ContractorAccordion.cshtml"
WriteAttributeValue("", 473, GetAccordionId("cheader",index), 473, 32, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                    <div class=\"col-12 d-flex\">\r\n                        <div class=\"p-2 text-center\">\r\n                            <span class=\"font-weight-bold p-2\">Id</span>\r\n                            <br />#");
#nullable restore
#line 19 "C:\Users\sajan\source\repos\Capstone\CSD480Group3Capstone001\Views\ContractorsPage\_ContractorAccordion.cshtml"
                              Write(contractor.ContractorID);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </div>\r\n                        <div class=\"p-2 text-center\">\r\n                            <span class=\"font-weight-bold\">Company Name</span>\r\n                            <br />");
#nullable restore
#line 23 "C:\Users\sajan\source\repos\Capstone\CSD480Group3Capstone001\Views\ContractorsPage\_ContractorAccordion.cshtml"
                             Write(contractor.Company);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </div>\r\n                        <div class=\"p-2 ml-auto align-self-center\">\r\n                            <button");
            BeginWriteAttribute("id", " id=\"", 1106, "\"", 1143, 1);
#nullable restore
#line 26 "C:\Users\sajan\source\repos\Capstone\CSD480Group3Capstone001\Views\ContractorsPage\_ContractorAccordion.cshtml"
WriteAttributeValue("", 1111, GetAccordionId("cexpand",index), 1111, 32, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn-sm border border-dark btn-primary d-inline\" type=\"button\" aria-expanded=\"false\" data-toggle=\"collapse\" data-target=\"#");
#nullable restore
#line 26 "C:\Users\sajan\source\repos\Capstone\CSD480Group3Capstone001\Views\ContractorsPage\_ContractorAccordion.cshtml"
                                                                                                                                                                                                     Write(GetAccordionId("cbody",index));

#line default
#line hidden
#nullable disable
            WriteLiteral(",");
#nullable restore
#line 26 "C:\Users\sajan\source\repos\Capstone\CSD480Group3Capstone001\Views\ContractorsPage\_ContractorAccordion.cshtml"
                                                                                                                                                                                                                                    Write(GetAccordionId("cexpand",index));

#line default
#line hidden
#nullable disable
            WriteLiteral(",");
#nullable restore
#line 26 "C:\Users\sajan\source\repos\Capstone\CSD480Group3Capstone001\Views\ContractorsPage\_ContractorAccordion.cshtml"
                                                                                                                                                                                                                                                                     Write(GetAccordionId("chide",index));

#line default
#line hidden
#nullable disable
            WriteLiteral("\"");
            BeginWriteAttribute("aria-controls", " aria-controls=\"", 1368, "\"", 1414, 1);
#nullable restore
#line 26 "C:\Users\sajan\source\repos\Capstone\CSD480Group3Capstone001\Views\ContractorsPage\_ContractorAccordion.cshtml"
WriteAttributeValue("", 1384, GetAccordionId("cbody",index), 1384, 30, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Expand</button>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n                <div");
            BeginWriteAttribute("id", " id=\"", 1537, "\"", 1572, 1);
#nullable restore
#line 30 "C:\Users\sajan\source\repos\Capstone\CSD480Group3Capstone001\Views\ContractorsPage\_ContractorAccordion.cshtml"
WriteAttributeValue("", 1542, GetAccordionId("cbody",index), 1542, 30, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"collapse\"");
            BeginWriteAttribute("aria-labelledby", " aria-labelledby=\"", 1590, "\"", 1640, 1);
#nullable restore
#line 30 "C:\Users\sajan\source\repos\Capstone\CSD480Group3Capstone001\Views\ContractorsPage\_ContractorAccordion.cshtml"
WriteAttributeValue("", 1608, GetAccordionId("cheader",index), 1608, 32, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" data-parent=\"#contractorAccordion\">\r\n                    <div class=\"card-body\">\r\n                        ");
#nullable restore
#line 32 "C:\Users\sajan\source\repos\Capstone\CSD480Group3Capstone001\Views\ContractorsPage\_ContractorAccordion.cshtml"
                   Write(await Html.PartialAsync("~/Views/ContractorsPage/_DisplayContractor.cshtml", contractor,new ViewDataDictionary(ViewData)));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 36 "C:\Users\sajan\source\repos\Capstone\CSD480Group3Capstone001\Views\ContractorsPage\_ContractorAccordion.cshtml"
            index++;
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n\r\n\r\n\r\n\r\n\r\n");
        }
        #pragma warning restore 1998
#nullable restore
#line 44 "C:\Users\sajan\source\repos\Capstone\CSD480Group3Capstone001\Views\ContractorsPage\_ContractorAccordion.cshtml"
           
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<CSD480Group3Capstone001.Models.Contractor>> Html { get; private set; }
    }
}
#pragma warning restore 1591
