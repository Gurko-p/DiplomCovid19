#pragma checksum "D:\Study\Diplom\DiplomCovid19\DiplomCovid19\Views\Shared\Components\VaccinationStatistic\Statistics.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0bd6fd6d8795a7692e44f59b71380c1a5c4929f4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_VaccinationStatistic_Statistics), @"mvc.1.0.view", @"/Views/Shared/Components/VaccinationStatistic/Statistics.cshtml")]
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
#line 1 "D:\Study\Diplom\DiplomCovid19\DiplomCovid19\Views\_ViewImports.cshtml"
using DiplomCovid19.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Study\Diplom\DiplomCovid19\DiplomCovid19\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Study\Diplom\DiplomCovid19\DiplomCovid19\Views\_ViewImports.cshtml"
using DiplomCovid19.Models.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\Study\Diplom\DiplomCovid19\DiplomCovid19\Views\_ViewImports.cshtml"
using DiplomCovid19.Helpers;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0bd6fd6d8795a7692e44f59b71380c1a5c4929f4", @"/Views/Shared/Components/VaccinationStatistic/Statistics.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6346698341d346ea2f7fd7fb3943dd34bdce835c", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_VaccinationStatistic_Statistics : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<EmployeeViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"statistics\">\r\n    <div class=\"content\">\r\n        <div>\r\n            <p>Общее количество сотрудников: <span class=\"d33\">");
#nullable restore
#line 6 "D:\Study\Diplom\DiplomCovid19\DiplomCovid19\Views\Shared\Components\VaccinationStatistic\Statistics.cshtml"
                                                          Write(Model.CountEmployees);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></p>\r\n        </div>\r\n        <div>\r\n            <p>Прошли полный курс вакцинации: \r\n            <span class=\"d33\">");
#nullable restore
#line 10 "D:\Study\Diplom\DiplomCovid19\DiplomCovid19\Views\Shared\Components\VaccinationStatistic\Statistics.cshtml"
                         Write(Model.FullCourseOfVaccinationCount);

#line default
#line hidden
#nullable disable
            WriteLiteral(" / ");
#nullable restore
#line 10 "D:\Study\Diplom\DiplomCovid19\DiplomCovid19\Views\Shared\Components\VaccinationStatistic\Statistics.cshtml"
                                                               Write(Model.FullCourseOfVaccinationPercent);

#line default
#line hidden
#nullable disable
            WriteLiteral(" %</span></p>\r\n        </div>\r\n        <div> \r\n            <p>Вакцинированы первым компонентом: \r\n                <span class=\"d33\">");
#nullable restore
#line 14 "D:\Study\Diplom\DiplomCovid19\DiplomCovid19\Views\Shared\Components\VaccinationStatistic\Statistics.cshtml"
                             Write(Model.VaccinatedFirstComponentCount);

#line default
#line hidden
#nullable disable
            WriteLiteral(" / ");
#nullable restore
#line 14 "D:\Study\Diplom\DiplomCovid19\DiplomCovid19\Views\Shared\Components\VaccinationStatistic\Statistics.cshtml"
                                                                    Write(Model.VaccinatedFirstComponentPercent);

#line default
#line hidden
#nullable disable
            WriteLiteral(" %</span>\r\n            </p>\r\n        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<EmployeeViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
