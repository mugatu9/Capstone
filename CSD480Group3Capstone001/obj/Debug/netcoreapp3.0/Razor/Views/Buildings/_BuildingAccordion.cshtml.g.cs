#pragma checksum "C:\Users\sajan\source\repos\Capstone\CSD480Group3Capstone001\Views\Buildings\_BuildingAccordion.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "88309bcfc86699d5b337a6dbd4d877e291bbe14f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Buildings__BuildingAccordion), @"mvc.1.0.view", @"/Views/Buildings/_BuildingAccordion.cshtml")]
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
#line 1 "C:\Users\sajan\source\repos\Capstone\CSD480Group3Capstone001\Views\Buildings\_BuildingAccordion.cshtml"
using System.Runtime.CompilerServices;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\sajan\source\repos\Capstone\CSD480Group3Capstone001\Views\Buildings\_BuildingAccordion.cshtml"
using System.Text;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\sajan\source\repos\Capstone\CSD480Group3Capstone001\Views\Buildings\_BuildingAccordion.cshtml"
using CSD480Group3Capstone001.Controllers;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"88309bcfc86699d5b337a6dbd4d877e291bbe14f", @"/Views/Buildings/_BuildingAccordion.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"709983a7153eab3563b50021aa9fef6ab9036835", @"/Views/_ViewImports.cshtml")]
    public class Views_Buildings__BuildingAccordion : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<CSD480Group3Capstone001.Models.Building>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n\r\n<div class=\"row accordion mt-2\" id=\"tenantAccordion\">\r\n");
#nullable restore
#line 9 "C:\Users\sajan\source\repos\Capstone\CSD480Group3Capstone001\Views\Buildings\_BuildingAccordion.cshtml"
          
            int index = 0;
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\sajan\source\repos\Capstone\CSD480Group3Capstone001\Views\Buildings\_BuildingAccordion.cshtml"
         foreach (var building in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"col-11 ml-auto mr-auto\">\r\n                <div class=\"card-header row border border-dark rounded p-0 mt-2\"");
            BeginWriteAttribute("id", " id=\"", 460, "\"", 496, 1);
#nullable restore
#line 15 "C:\Users\sajan\source\repos\Capstone\CSD480Group3Capstone001\Views\Buildings\_BuildingAccordion.cshtml"
WriteAttributeValue("", 465, GetAccordionId("header",index), 465, 31, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                    <div class=\"col-12 d-flex\">\r\n                        <div class=\"p-2 text-center\">\r\n                            <span class=\"font-weight-bold p-2\">Building Id</span>\r\n                            <br />#");
#nullable restore
#line 19 "C:\Users\sajan\source\repos\Capstone\CSD480Group3Capstone001\Views\Buildings\_BuildingAccordion.cshtml"
                              Write(building.BuildingID);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </div>\r\n                        <div class=\"p-2 text-center\">\r\n                            <span class=\"font-weight-bold\">Building Address</span>\r\n                            <br />#");
#nullable restore
#line 23 "C:\Users\sajan\source\repos\Capstone\CSD480Group3Capstone001\Views\Buildings\_BuildingAccordion.cshtml"
                              Write(building.Address);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </div>\r\n                        <div class=\"p-2 text-center d-none d-sm-block\">\r\n                            <span class=\"font-weight-bold\">Number of Tenants</span>\r\n                            <br />");
#nullable restore
#line 27 "C:\Users\sajan\source\repos\Capstone\CSD480Group3Capstone001\Views\Buildings\_BuildingAccordion.cshtml"
                             Write(getTenantsCount(building));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </div>\r\n                        <div class=\"p-2 text-center d-none d-sm-block\">\r\n                            <span class=\"font-weight-bold\">Square Footage</span>\r\n                            <br />");
#nullable restore
#line 31 "C:\Users\sajan\source\repos\Capstone\CSD480Group3Capstone001\Views\Buildings\_BuildingAccordion.cshtml"
                             Write(getSquareFootage(building));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </div>\r\n                        <div class=\"p-2 ml-auto align-self-center\">\r\n                            <button");
            BeginWriteAttribute("id", " id=\"", 1607, "\"", 1643, 1);
#nullable restore
#line 34 "C:\Users\sajan\source\repos\Capstone\CSD480Group3Capstone001\Views\Buildings\_BuildingAccordion.cshtml"
WriteAttributeValue("", 1612, GetAccordionId("expand",index), 1612, 31, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn-sm border border-dark btn-primary d-inline\" type=\"button\" aria-expanded=\"false\" data-toggle=\"collapse\" data-target=\"#");
#nullable restore
#line 34 "C:\Users\sajan\source\repos\Capstone\CSD480Group3Capstone001\Views\Buildings\_BuildingAccordion.cshtml"
                                                                                                                                                                                                    Write(GetAccordionId("body",index));

#line default
#line hidden
#nullable disable
            WriteLiteral(",");
#nullable restore
#line 34 "C:\Users\sajan\source\repos\Capstone\CSD480Group3Capstone001\Views\Buildings\_BuildingAccordion.cshtml"
                                                                                                                                                                                                                                  Write(GetAccordionId("expand",index));

#line default
#line hidden
#nullable disable
            WriteLiteral(",");
#nullable restore
#line 34 "C:\Users\sajan\source\repos\Capstone\CSD480Group3Capstone001\Views\Buildings\_BuildingAccordion.cshtml"
                                                                                                                                                                                                                                                                  Write(GetAccordionId("hide",index));

#line default
#line hidden
#nullable disable
            WriteLiteral("\"");
            BeginWriteAttribute("aria-controls", " aria-controls=\"", 1865, "\"", 1910, 1);
#nullable restore
#line 34 "C:\Users\sajan\source\repos\Capstone\CSD480Group3Capstone001\Views\Buildings\_BuildingAccordion.cshtml"
WriteAttributeValue("", 1881, GetAccordionId("body",index), 1881, 29, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Expand</button>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n                <div");
            BeginWriteAttribute("id", " id=\"", 2033, "\"", 2067, 1);
#nullable restore
#line 38 "C:\Users\sajan\source\repos\Capstone\CSD480Group3Capstone001\Views\Buildings\_BuildingAccordion.cshtml"
WriteAttributeValue("", 2038, GetAccordionId("body",index), 2038, 29, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"collapse\"");
            BeginWriteAttribute("aria-labelledby", " aria-labelledby=\"", 2085, "\"", 2134, 1);
#nullable restore
#line 38 "C:\Users\sajan\source\repos\Capstone\CSD480Group3Capstone001\Views\Buildings\_BuildingAccordion.cshtml"
WriteAttributeValue("", 2103, GetAccordionId("header",index), 2103, 31, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" data-parent=\"#tenantAccordion\">\r\n                    <div class=\"card-body\">\r\n                        ");
#nullable restore
#line 40 "C:\Users\sajan\source\repos\Capstone\CSD480Group3Capstone001\Views\Buildings\_BuildingAccordion.cshtml"
                   Write(await Html.PartialAsync("~/Views/Buildings/_DisplayBuilding.cshtml", building, new ViewDataDictionary(ViewData)));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 44 "C:\Users\sajan\source\repos\Capstone\CSD480Group3Capstone001\Views\Buildings\_BuildingAccordion.cshtml"
            index++;
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n\r\n\r\n\r\n\r\n\r\n");
        }
        #pragma warning restore 1998
#nullable restore
#line 52 "C:\Users\sajan\source\repos\Capstone\CSD480Group3Capstone001\Views\Buildings\_BuildingAccordion.cshtml"
           
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

    private int getTenantsCount(Building b)
    {
        int count = 0;
        foreach (var unit in b.Units)
        {
            foreach (var tu in unit.TenantUnits)
            {
                if (!tu.tenant.MovedOutDate.Equals(null))
                {
                    count++;
                }
            }
        }
        return count;
    }

    private int getSquareFootage(Building b)
    {
        int squareFootage = 0;
        foreach (var unit in b.Units)
        {
            squareFootage += unit.SqrFootage;
        }
        return squareFootage;
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<CSD480Group3Capstone001.Models.Building>> Html { get; private set; }
    }
}
#pragma warning restore 1591
