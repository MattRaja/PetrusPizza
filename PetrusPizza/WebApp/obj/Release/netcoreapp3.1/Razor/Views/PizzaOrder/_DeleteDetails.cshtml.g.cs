#pragma checksum "C:\Users\NZXT\RiderProjects\icd0009-2019s\PetrusPizza\PetrusPizza\WebApp\Views\PizzaOrder\_DeleteDetails.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6f4f16d36cfbcb9beb7d7f1f6d13af9e587cf7f9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_PizzaOrder__DeleteDetails), @"mvc.1.0.view", @"/Views/PizzaOrder/_DeleteDetails.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6f4f16d36cfbcb9beb7d7f1f6d13af9e587cf7f9", @"/Views/PizzaOrder/_DeleteDetails.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fc48f17eb9bac3476d8060730298bf398eb2fa5e", @"/Views/_ViewImports.cshtml")]
    public class Views_PizzaOrder__DeleteDetails : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ee.itcollege.mrajam.BLL.App.DTO.PizzaOrder>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<h4>PizzaOrder</h4>\r\n<hr />\r\n<dl class=\"row\">\r\n    <dt class = \"col-sm-2\">\r\n        ");
#nullable restore
#line 7 "C:\Users\NZXT\RiderProjects\icd0009-2019s\PetrusPizza\PetrusPizza\WebApp\Views\PizzaOrder\_DeleteDetails.cshtml"
   Write(Html.DisplayNameFor(model => model.PizzaName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </dt>\r\n");
            WriteLiteral("    <dt class = \"col-sm-2\">\r\n        ");
#nullable restore
#line 13 "C:\Users\NZXT\RiderProjects\icd0009-2019s\PetrusPizza\PetrusPizza\WebApp\Views\PizzaOrder\_DeleteDetails.cshtml"
   Write(Html.DisplayNameFor(model => model.PizzaSize));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </dt>\r\n");
            WriteLiteral("    <dt class = \"col-sm-2\">\r\n        ");
#nullable restore
#line 19 "C:\Users\NZXT\RiderProjects\icd0009-2019s\PetrusPizza\PetrusPizza\WebApp\Views\PizzaOrder\_DeleteDetails.cshtml"
   Write(Html.DisplayNameFor(model => model.PizzaType));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </dt>\r\n");
            WriteLiteral("    <dt class = \"col-sm-2\">\r\n        ");
#nullable restore
#line 25 "C:\Users\NZXT\RiderProjects\icd0009-2019s\PetrusPizza\PetrusPizza\WebApp\Views\PizzaOrder\_DeleteDetails.cshtml"
   Write(Html.DisplayNameFor(model => model.Price));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </dt>\r\n    <dd class = \"col-sm-10\">\r\n        ");
#nullable restore
#line 28 "C:\Users\NZXT\RiderProjects\icd0009-2019s\PetrusPizza\PetrusPizza\WebApp\Views\PizzaOrder\_DeleteDetails.cshtml"
   Write(Html.DisplayFor(model => model.Price));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </dd>\r\n");
            WriteLiteral("</dl>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ee.itcollege.mrajam.BLL.App.DTO.PizzaOrder> Html { get; private set; }
    }
}
#pragma warning restore 1591
