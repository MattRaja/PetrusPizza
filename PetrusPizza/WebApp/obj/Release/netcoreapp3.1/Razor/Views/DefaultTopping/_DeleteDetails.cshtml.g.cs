#pragma checksum "C:\Users\NZXT\RiderProjects\icd0009-2019s\PetrusPizza\PetrusPizza\WebApp\Views\DefaultTopping\_DeleteDetails.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "576481f90607deb3c7126a81701fba27f2b10761"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_DefaultTopping__DeleteDetails), @"mvc.1.0.view", @"/Views/DefaultTopping/_DeleteDetails.cshtml")]
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
#line 1 "C:\Users\NZXT\RiderProjects\icd0009-2019s\PetrusPizza\PetrusPizza\WebApp\Views\_ViewImports.cshtml"
using WebApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\NZXT\RiderProjects\icd0009-2019s\PetrusPizza\PetrusPizza\WebApp\Views\_ViewImports.cshtml"
using WebApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"576481f90607deb3c7126a81701fba27f2b10761", @"/Views/DefaultTopping/_DeleteDetails.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fc48f17eb9bac3476d8060730298bf398eb2fa5e", @"/Views/_ViewImports.cshtml")]
    public class Views_DefaultTopping__DeleteDetails : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ee.itcollege.mrajam.BLL.App.DTO.DefaultTopping>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<h4>DefaultTopping</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n");
            WriteLiteral("        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 19 "C:\Users\NZXT\RiderProjects\icd0009-2019s\PetrusPizza\PetrusPizza\WebApp\Views\DefaultTopping\_DeleteDetails.cshtml"
       Write(Html.DisplayNameFor(model => model.AppUserId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 22 "C:\Users\NZXT\RiderProjects\icd0009-2019s\PetrusPizza\PetrusPizza\WebApp\Views\DefaultTopping\_DeleteDetails.cshtml"
       Write(Html.DisplayFor(model => model.AppUser!.FirstName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n");
            WriteLiteral("    </dl>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ee.itcollege.mrajam.BLL.App.DTO.DefaultTopping> Html { get; private set; }
    }
}
#pragma warning restore 1591