#pragma checksum "C:\Users\natha\Source\Repos\mugatu9\Capstone\CSD480Group3Capstone001\Views\Tenants\_DisplayTenant.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "81490156580348aea147e7bf819847602963b870"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Tenants__DisplayTenant), @"mvc.1.0.view", @"/Views/Tenants/_DisplayTenant.cshtml")]
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
#line 1 "C:\Users\natha\Source\Repos\mugatu9\Capstone\CSD480Group3Capstone001\Views\_ViewImports.cshtml"
using CSD480Group3Capstone001;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\natha\Source\Repos\mugatu9\Capstone\CSD480Group3Capstone001\Views\_ViewImports.cshtml"
using CSD480Group3Capstone001.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"81490156580348aea147e7bf819847602963b870", @"/Views/Tenants/_DisplayTenant.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"aaa63d68d288c22042961e0f88ec427923ad4374", @"/Views/_ViewImports.cshtml")]
    public class Views_Tenants__DisplayTenant : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CSD480Group3Capstone001.Models.Tenant>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n<div>\r\n    <dl class=\"row\">\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 7 "C:\Users\natha\Source\Repos\mugatu9\Capstone\CSD480Group3Capstone001\Views\Tenants\_DisplayTenant.cshtml"
       Write(Html.DisplayNameFor(model => model.FirstName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 10 "C:\Users\natha\Source\Repos\mugatu9\Capstone\CSD480Group3Capstone001\Views\Tenants\_DisplayTenant.cshtml"
       Write(Html.DisplayFor(model => model.FirstName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 13 "C:\Users\natha\Source\Repos\mugatu9\Capstone\CSD480Group3Capstone001\Views\Tenants\_DisplayTenant.cshtml"
       Write(Html.DisplayNameFor(model => model.LastName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 16 "C:\Users\natha\Source\Repos\mugatu9\Capstone\CSD480Group3Capstone001\Views\Tenants\_DisplayTenant.cshtml"
       Write(Html.DisplayFor(model => model.LastName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 19 "C:\Users\natha\Source\Repos\mugatu9\Capstone\CSD480Group3Capstone001\Views\Tenants\_DisplayTenant.cshtml"
       Write(Html.DisplayNameFor(model => model.Employer));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 22 "C:\Users\natha\Source\Repos\mugatu9\Capstone\CSD480Group3Capstone001\Views\Tenants\_DisplayTenant.cshtml"
       Write(Html.DisplayFor(model => model.Employer));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 25 "C:\Users\natha\Source\Repos\mugatu9\Capstone\CSD480Group3Capstone001\Views\Tenants\_DisplayTenant.cshtml"
       Write(Html.DisplayNameFor(model => model.Salary));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 28 "C:\Users\natha\Source\Repos\mugatu9\Capstone\CSD480Group3Capstone001\Views\Tenants\_DisplayTenant.cshtml"
       Write(Html.DisplayFor(model => model.Salary));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 31 "C:\Users\natha\Source\Repos\mugatu9\Capstone\CSD480Group3Capstone001\Views\Tenants\_DisplayTenant.cshtml"
       Write(Html.DisplayNameFor(model => model.MovedInDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 34 "C:\Users\natha\Source\Repos\mugatu9\Capstone\CSD480Group3Capstone001\Views\Tenants\_DisplayTenant.cshtml"
       Write(Html.DisplayFor(model => model.MovedInDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 37 "C:\Users\natha\Source\Repos\mugatu9\Capstone\CSD480Group3Capstone001\Views\Tenants\_DisplayTenant.cshtml"
       Write(Html.DisplayNameFor(model => model.MovedOutDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 40 "C:\Users\natha\Source\Repos\mugatu9\Capstone\CSD480Group3Capstone001\Views\Tenants\_DisplayTenant.cshtml"
       Write(Html.DisplayFor(model => model.MovedOutDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CSD480Group3Capstone001.Models.Tenant> Html { get; private set; }
    }
}
#pragma warning restore 1591
