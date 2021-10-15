#pragma checksum "C:\Projetos\Thiago\BackOffice\backoffice\BackOfficeCode\Web_Application\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f9a6a15ee4493b3638c9db87fecab81a617b9987"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "C:\Projetos\Thiago\BackOffice\backoffice\BackOfficeCode\Web_Application\Views\_ViewImports.cshtml"
using Web_Application;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Projetos\Thiago\BackOffice\backoffice\BackOfficeCode\Web_Application\Views\_ViewImports.cshtml"
using Web_Application.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Projetos\Thiago\BackOffice\backoffice\BackOfficeCode\Web_Application\Views\_ViewImports.cshtml"
using Domain.Models.Settings;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f9a6a15ee4493b3638c9db87fecab81a617b9987", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ec7a51b1d24391c3807fe68ede7cee98df45cced", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 2 "C:\Projetos\Thiago\BackOffice\backoffice\BackOfficeCode\Web_Application\Views\Home\Index.cshtml"
   
    ViewData["Title"] = "Painel";
    var location = ViewData["Location"];
    var entity = ViewData["Entity"];
    var text = ViewData["Text"];
    var callback = ViewData["Callback"]; 

#line default
#line hidden
#nullable disable
            WriteLiteral("\n\n<!-- Rendering the site map -->\n");
#nullable restore
#line 12 "C:\Projetos\Thiago\BackOffice\backoffice\BackOfficeCode\Web_Application\Views\Home\Index.cshtml"
Write(await Component.InvokeAsync("VcSiteMap", new { location = location, entity = entity, text = text, callback = callback }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<!-- Dashboard -->
<section class=""content"">
    <div class=""container-fluid"">
        <div class=""row"">
            <div class=""col-12 col-sm-6 col-md-3"">
                <div class=""info-box"">
                    <span class=""info-box-icon bg-info elevation-1""><i class=""fas fa-cog""></i></span>

                    <div class=""info-box-content"">
                        <span class=""info-box-text"">CPU Traffic</span>
                        <span class=""info-box-number"">
                            10
                            <small>%</small>
                        </span>
                    </div>
                </div>
            </div>
            <div class=""col-12 col-sm-6 col-md-3"">
                <div class=""info-box mb-3"">
                    <span class=""info-box-icon bg-danger elevation-1""><i class=""fas fa-thumbs-up""></i></span>

                    <div class=""info-box-content"">
                        <span class=""info-box-text"">Likes</span>
                        <span class=""info-box-nu");
            WriteLiteral(@"mber"">41,410</span>
                    </div>
                </div>
            </div>

            <div class=""clearfix hidden-md-up""></div>

            <div class=""col-12 col-sm-6 col-md-3"">
                <div class=""info-box mb-3"">
                    <span class=""info-box-icon bg-success elevation-1""><i class=""fas fa-shopping-cart""></i></span>

                    <div class=""info-box-content"">
                        <span class=""info-box-text"">Sales</span>
                        <span class=""info-box-number"">760</span>
                    </div>
                </div>
            </div>
            <div class=""col-12 col-sm-6 col-md-3"">
                <div class=""info-box mb-3"">
                    <span class=""info-box-icon bg-warning elevation-1""><i class=""fas fa-users""></i></span>

                    <div class=""info-box-content"">
                        <span class=""info-box-text"">New Members</span>
                        <span class=""info-box-number"">2,000</span>
                    </div>");
            WriteLiteral(@"
                </div>
            </div>
        </div>

        <div class=""row"">
            <div class=""col-md-12"">
                <div class=""card"">
                    <div class=""card-header"">
                        <h5 class=""card-title"">Monthly Recap Report</h5>

                        <div class=""card-tools"">
                            <button type=""button"" class=""btn btn-tool"" data-card-widget=""collapse"">
                                <i class=""fas fa-minus""></i>
                            </button>
                            <div class=""btn-group"">
                                <button type=""button"" class=""btn btn-tool dropdown-toggle"" data-toggle=""dropdown"">
                                    <i class=""fas fa-wrench""></i>
                                </button>
                                <div class=""dropdown-menu dropdown-menu-right"" role=""menu"">
                                    <a href=""#"" class=""dropdown-item"">Action</a>
                                    <a href=""#"" clas");
            WriteLiteral(@"s=""dropdown-item"">Another action</a>
                                    <a href=""#"" class=""dropdown-item"">Something else here</a>
                                    <a class=""dropdown-divider""></a>
                                    <a href=""#"" class=""dropdown-item"">Separated link</a>
                                </div>
                            </div>
                            <button type=""button"" class=""btn btn-tool"" data-card-widget=""remove"">
                                <i class=""fas fa-times""></i>
                            </button>
                        </div>
                    </div>
                    <div class=""card-body"">
                        <div class=""row"">
                            <div class=""col-md-8"">
                                <p class=""text-center"">
                                    <strong>Sales: 1 Jan, 2014 - 30 Jul, 2014</strong>
                                </p>

                                <div class=""chart"">
                                    ");
            WriteLiteral(@"<canvas id=""salesChart"" height=""180"" style=""height: 180px;""></canvas>
                                </div>
                            </div>
                            <div class=""col-md-4"">
                                <p class=""text-center"">
                                    <strong>Goal Completion</strong>
                                </p>

                                <div class=""progress-group"">
                                    Add Products to Cart
                                    <span class=""float-right""><b>160</b>/200</span>
                                    <div class=""progress progress-sm"">
                                        <div class=""progress-bar bg-primary"" style=""width: 80%""></div>
                                    </div>
                                </div>

                                <div class=""progress-group"">
                                    Complete Purchase
                                    <span class=""float-right""><b>310</b>/400</span>
        ");
            WriteLiteral(@"                            <div class=""progress progress-sm"">
                                        <div class=""progress-bar bg-danger"" style=""width: 75%""></div>
                                    </div>
                                </div>

                                <div class=""progress-group"">
                                    <span class=""progress-text"">Visit Premium Page</span>
                                    <span class=""float-right""><b>480</b>/800</span>
                                    <div class=""progress progress-sm"">
                                        <div class=""progress-bar bg-success"" style=""width: 60%""></div>
                                    </div>
                                </div>

                                <div class=""progress-group"">
                                    Send Inquiries
                                    <span class=""float-right""><b>250</b>/500</span>
                                    <div class=""progress progress-sm"">
                 ");
            WriteLiteral(@"                       <div class=""progress-bar bg-warning"" style=""width: 50%""></div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class=""card-footer"">
                        <div class=""row"">
                            <div class=""col-sm-3 col-6"">
                                <div class=""description-block border-right"">
                                    <span class=""description-percentage text-success""><i class=""fas fa-caret-up""></i> 17%</span>
                                    <h5 class=""description-header"">$35,210.43</h5>
                                    <span class=""description-text"">TOTAL REVENUE</span>
                                </div>
                            </div>
                            <div class=""col-sm-3 col-6"">
                                <div class=""description-block border-right"">
                                 ");
            WriteLiteral(@"   <span class=""description-percentage text-warning""><i class=""fas fa-caret-left""></i> 0%</span>
                                    <h5 class=""description-header"">$10,390.90</h5>
                                    <span class=""description-text"">TOTAL COST</span>
                                </div>
                            </div>
                            <div class=""col-sm-3 col-6"">
                                <div class=""description-block border-right"">
                                    <span class=""description-percentage text-success""><i class=""fas fa-caret-up""></i> 20%</span>
                                    <h5 class=""description-header"">$24,813.53</h5>
                                    <span class=""description-text"">TOTAL PROFIT</span>
                                </div>
                            </div>
                            <div class=""col-sm-3 col-6"">
                                <div class=""description-block"">
                                    <span class=""descript");
            WriteLiteral(@"ion-percentage text-danger""><i class=""fas fa-caret-down""></i> 18%</span>
                                    <h5 class=""description-header"">1200</h5>
                                    <span class=""description-text"">GOAL COMPLETIONS</span>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>

    </div>
</section>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
