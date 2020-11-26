#pragma checksum "C:\Users\HP\Desktop\Projeler\Bayi\Bayi.UI\Areas\Admin\Views\Dealer\Create.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b6eb4d8b0bd650643d703f77d64c67fe3a18e282"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Dealer_Create), @"mvc.1.0.view", @"/Areas/Admin/Views/Dealer/Create.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b6eb4d8b0bd650643d703f77d64c67fe3a18e282", @"/Areas/Admin/Views/Dealer/Create.cshtml")]
    public class Areas_Admin_Views_Dealer_Create : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\HP\Desktop\Projeler\Bayi\Bayi.UI\Areas\Admin\Views\Dealer\Create.cshtml"
  
    ViewData["Title"] = "Create";
    Layout = "~/Areas/Admin/Views/_AdminLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<section class=""content"">


    <section class=""content-header"">
        <div class=""container-fluid"">
            <div class=""row mb-2"">
                <div class=""col-md-4""></div>
                <div class=""col-md-3"">
                    <h1>Bayi Oluştur</h1>
                </div>
                <div class=""col-md-5"">
                    <ol class=""breadcrumb float-sm-right"">
                        <li class=""breadcrumb-item""><a href=""#"">Bayi Yönetimi</a></li>
                        <li class=""breadcrumb-item active"">Bayi Oluştur</li>
                    </ol>
                </div>
            </div>
        </div><!-- /.container-fluid -->
    </section>

    <!-- Main content -->
    <section class=""content"">
        <div class=""row"">
            <div class=""col-md-2""></div>
            <div class=""col-md-8"">
                <div class=""card card-primary"">
                    <div class=""card-header"">
                        <h3 class=""card-title"">Bilgiler</h3>

       ");
            WriteLiteral(@"                 <div class=""card-tools"">
                            <button type=""button"" class=""btn btn-tool"" data-card-widget=""collapse"" title=""Collapse"">
                                <i class=""fas fa-minus""></i>
                            </button>
                        </div>
                    </div>
                    <form id=""createDealerForm"" method=""post"" enctype=""multipart/form-data"">
                        <div class=""card-body"">
                            <div class=""form-group"">
                                <label for=""inputName"">Firma Ünvanı</label>
                                <input type=""text"" id=""txtCompanyName"" class=""form-control"">
                            </div>
                            <div class=""form-group"">
                                <label for=""inputName"">Yetkili Kişi</label>
                                <input type=""text"" id=""txtAuthorized"" class=""form-control"">
                            </div>
                            <div class");
            WriteLiteral(@"=""form-group"">
                                <label>Adres</label>
                                <textarea class=""form-control"" id=""txtAddress"" rows=""3"" placeholder=""Adres Giriniz...""></textarea>
                            </div>
                            <div class=""form-group"">
                                <label>Telefon</label>

                                <div class=""input-group"">
                                    <div class=""input-group-prepend"">
                                        <span class=""input-group-text""><i class=""fas fa-phone""></i></span>
                                    </div>
                                    <input type=""text"" id=""txtPhone"" class=""form-control"" data-inputmask=""&quot;mask&quot;: &quot;(999) 999-9999&quot;"" data-mask="""" inputmode=""text"">
                                </div>
                                <!-- /.input group -->
                            </div>
                            <div class=""form-group"">
                      ");
            WriteLiteral(@"          <label for=""exampleInputEmail1"">Email</label>
                                <div class=""input-group mb-3"">
                                    <div class=""input-group-prepend"">
                                        <span class=""input-group-text""><i class=""fas fa-envelope""></i></span>
                                    </div>
                                    <input type=""email"" id=""txtEmail"" class=""form-control"" placeholder=""Email"" required>
                                </div>
                            </div>

                        </div>
                        <div class=""col-md-2"">

                            <!-- /.card -->
                        </div>
                        <div class=""row mb-4"">
                            <div class=""col-1""></div>
                            <div class=""col-10"">
                                <a href=""/Admin/Dealer/List"" class=""btn btn-secondary"" style=""background-color:red !important;border-color:red !important;"">İptal Et<");
            WriteLiteral(@"/a>
                                <input type=""submit"" value=""Oluştur"" class=""btn btn-success float-right"">
                            </div>
                            <div class=""col-1""></div>
                        </div>
                    </form>

                    <!-- /.card-body -->
                </div>
                <!-- /.card -->
            </div>

        </div>

    </section>
    <!-- /.content -->

</section>
");
            DefineSection("JS", async() => {
                WriteLiteral("\r\n    <script>var createDealerUrl =\'/Admin/Dealer/CreateDealer\';</script>\r\n    <script src=\"/js/CustomScripts/Dealer/createDealer.js\"></script>\r\n");
            }
            );
            WriteLiteral("\r\n");
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
