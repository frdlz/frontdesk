#pragma checksum "C:\Users\XCV\Documents\GitHub\frontdesk\Views\Appointments\_PartialView.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fd01286f91f12173d4f312cb443836aaba8b8325"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Appointments__PartialView), @"mvc.1.0.view", @"/Views/Appointments/_PartialView.cshtml")]
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
#line 1 "C:\Users\XCV\Documents\GitHub\frontdesk\Views\_ViewImports.cshtml"
using Frontdesk6;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\XCV\Documents\GitHub\frontdesk\Views\_ViewImports.cshtml"
using Frontdesk6.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\XCV\Documents\GitHub\frontdesk\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\XCV\Documents\GitHub\frontdesk\Views\Appointments\_PartialView.cshtml"
using Frontdesk6.Models.Frontdesk;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fd01286f91f12173d4f312cb443836aaba8b8325", @"/Views/Appointments/_PartialView.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1b8d22048a97f2ec66df06b5b8e9356bf3186c36", @"/Views/_ViewImports.cshtml")]
    public class Views_Appointments__PartialView : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CountViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n<p>\r\n    anda urutan ");
#nullable restore
#line 6 "C:\Users\XCV\Documents\GitHub\frontdesk\Views\Appointments\_PartialView.cshtml"
           Write(Model.TotalHari);

#line default
#line hidden
#nullable disable
            WriteLiteral(" dari ");
#nullable restore
#line 6 "C:\Users\XCV\Documents\GitHub\frontdesk\Views\Appointments\_PartialView.cshtml"
                                 Write(Model.DateCount);

#line default
#line hidden
#nullable disable
            WriteLiteral(" pada layanan yang anda plih\r\n</p>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CountViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
