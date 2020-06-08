#pragma checksum "C:\Users\sajan\source\repos\Capstone\CSD480Group3Capstone001\Views\Units\_DisplayUnit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6d37513068f502016b39c66b106a9359c7f692a9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Units__DisplayUnit), @"mvc.1.0.view", @"/Views/Units/_DisplayUnit.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6d37513068f502016b39c66b106a9359c7f692a9", @"/Views/Units/_DisplayUnit.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b84f6cdf9f28b937e6ee447ec9f2a02f1e99e744", @"/Views/_ViewImports.cshtml")]
    public class Views_Units__DisplayUnit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CSD480Group3Capstone001.Models.Unit>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n<div>\n    <dl class=\"row\">\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 6 "C:\Users\sajan\source\repos\Capstone\CSD480Group3Capstone001\Views\Units\_DisplayUnit.cshtml"
       Write(Html.DisplayNameFor(model => model.UnitNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 9 "C:\Users\sajan\source\repos\Capstone\CSD480Group3Capstone001\Views\Units\_DisplayUnit.cshtml"
       Write(Html.DisplayFor(model => model.UnitNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 12 "C:\Users\sajan\source\repos\Capstone\CSD480Group3Capstone001\Views\Units\_DisplayUnit.cshtml"
       Write(Html.DisplayNameFor(model => model.SqrFootage));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 15 "C:\Users\sajan\source\repos\Capstone\CSD480Group3Capstone001\Views\Units\_DisplayUnit.cshtml"
       Write(Html.DisplayFor(model => model.SqrFootage));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 18 "C:\Users\sajan\source\repos\Capstone\CSD480Group3Capstone001\Views\Units\_DisplayUnit.cshtml"
       Write(Html.DisplayNameFor(model => model.Building));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 21 "C:\Users\sajan\source\repos\Capstone\CSD480Group3Capstone001\Views\Units\_DisplayUnit.cshtml"
       Write(Html.DisplayFor(model => model.Building.BuildingID));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n\r\n\r\n");
            WriteLiteral("            <dt class=\"col-sm-2\">\r\n                Tenants\r\n            </dt>\r\n            <dd class=\"col-sm-10\">\r\n");
#nullable restore
#line 30 "C:\Users\sajan\source\repos\Capstone\CSD480Group3Capstone001\Views\Units\_DisplayUnit.cshtml"
                 foreach (TenantUnit tu in Model.TenantUnits)
                {


#line default
#line hidden
#nullable disable
            WriteLiteral("                    <span>");
#nullable restore
#line 33 "C:\Users\sajan\source\repos\Capstone\CSD480Group3Capstone001\Views\Units\_DisplayUnit.cshtml"
                     Write(tu.tenant.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 33 "C:\Users\sajan\source\repos\Capstone\CSD480Group3Capstone001\Views\Units\_DisplayUnit.cshtml"
                                          Write(tu.tenant.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n");
#nullable restore
#line 34 "C:\Users\sajan\source\repos\Capstone\CSD480Group3Capstone001\Views\Units\_DisplayUnit.cshtml"

                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </dd>\r\n            <dt class=\"col-sm-2\">\r\n                Vehicles\r\n            </dt>\r\n            <dd class=\"col-sm-10\">\r\n");
#nullable restore
#line 41 "C:\Users\sajan\source\repos\Capstone\CSD480Group3Capstone001\Views\Units\_DisplayUnit.cshtml"
                 foreach (TenantUnit tu in Model.TenantUnits)
                {
                    foreach (Vehicle v in tu.tenant.Vehicles)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <span>");
#nullable restore
#line 45 "C:\Users\sajan\source\repos\Capstone\CSD480Group3Capstone001\Views\Units\_DisplayUnit.cshtml"
                         Write(v.Make);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 45 "C:\Users\sajan\source\repos\Capstone\CSD480Group3Capstone001\Views\Units\_DisplayUnit.cshtml"
                                 Write(v.Model);

#line default
#line hidden
#nullable disable
            WriteLiteral(" plate number:");
#nullable restore
#line 45 "C:\Users\sajan\source\repos\Capstone\CSD480Group3Capstone001\Views\Units\_DisplayUnit.cshtml"
                                                       Write(v.LicensePlate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n");
#nullable restore
#line 46 "C:\Users\sajan\source\repos\Capstone\CSD480Group3Capstone001\Views\Units\_DisplayUnit.cshtml"
                    }
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </dd>\r\n");
            WriteLiteral("\r\n    </dl>\n</div>\n\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CSD480Group3Capstone001.Models.Unit> Html { get; private set; }
    }
}
#pragma warning restore 1591
