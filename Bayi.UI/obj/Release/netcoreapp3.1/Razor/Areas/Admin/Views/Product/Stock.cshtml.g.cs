#pragma checksum "C:\Users\HP\Desktop\Projeler\Bayi\Bayi.UI\Areas\Admin\Views\Product\Stock.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9e3d1abea928f27f3afcf2abacad757d7233c042"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Product_Stock), @"mvc.1.0.view", @"/Areas/Admin/Views/Product/Stock.cshtml")]
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
#line 6 "C:\Users\HP\Desktop\Projeler\Bayi\Bayi.UI\Areas\Admin\Views\Product\Stock.cshtml"
using Bayi.DTO.Product;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9e3d1abea928f27f3afcf2abacad757d7233c042", @"/Areas/Admin/Views/Product/Stock.cshtml")]
    public class Areas_Admin_Views_Product_Stock : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<ListProductNameResponse>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\HP\Desktop\Projeler\Bayi\Bayi.UI\Areas\Admin\Views\Product\Stock.cshtml"
  
    ViewData["Title"] = "Stock";
    Layout = "~/Areas/Admin/Views/_AdminLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<section class=""content-header"">
    <div class=""container-fluid"">
        <div class=""row mb-2"">
            <div class=""col-md-5""></div>
            <div class=""col-md-2"">
                <h1>Stok Kaydı</h1>
            </div>
            <div class=""col-md-5"">
                <ol class=""breadcrumb float-sm-right"">
                    <li class=""breadcrumb-item""><a href=""#"">Stok Kaydı</a></li>
                    <li class=""breadcrumb-item active"">Stok Kaydı Oluştur</li>
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


                </div>
                <form id=""stockForm"" method=""post"" enctype=""multipart/form-data"">
                    <div");
            WriteLiteral(" class=\"card-body\">\r\n                        <div class=\"form-group\">\r\n                            <label>Ürün İsmi</label>\r\n                            <select id=\"selectProduct\" class=\"form-control select2\" style=\"width: 100%;\">\r\n");
#nullable restore
#line 41 "C:\Users\HP\Desktop\Projeler\Bayi\Bayi.UI\Areas\Admin\Views\Product\Stock.cshtml"
                                 foreach (ListProductNameResponse productNameResponse in Model)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <option class=\"optionValue\" data-stock=\"");
#nullable restore
#line 43 "C:\Users\HP\Desktop\Projeler\Bayi\Bayi.UI\Areas\Admin\Views\Product\Stock.cshtml"
                                                                       Write(productNameResponse.Quantity);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" data-id=\"");
#nullable restore
#line 43 "C:\Users\HP\Desktop\Projeler\Bayi\Bayi.UI\Areas\Admin\Views\Product\Stock.cshtml"
                                                                                                               Write(productNameResponse.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">");
#nullable restore
#line 43 "C:\Users\HP\Desktop\Projeler\Bayi\Bayi.UI\Areas\Admin\Views\Product\Stock.cshtml"
                                                                                                                                        Write(productNameResponse.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</option>\r\n");
#nullable restore
#line 44 "C:\Users\HP\Desktop\Projeler\Bayi\Bayi.UI\Areas\Admin\Views\Product\Stock.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                            </select>
                        </div>
                        <div class=""form-group"">
                            <label>Mevcut Ürünün Stok Adeti</label>
                            <input type=""text"" class=""form-control"" id=""txtProductStock""");
            BeginWriteAttribute("value", " value=\"", 2043, "\"", 2051, 0);
            EndWriteAttribute();
            BeginWriteAttribute("placeholder", " placeholder=\"", 2052, "\"", 2066, 0);
            EndWriteAttribute();
            WriteLiteral(@" disabled=""disabled"">
                        </div>
                        <div class=""form-group"">
                            <label for=""inputEstimatedBudget"">İşlem Yapılacak Adet</label>
                            <input type=""number"" min=""0"" step=""1"" id=""txtQuantity"" class=""form-control"" required>
                        </div>

                    </div>
                    <div class=""col-md-2"">

                        <!-- /.card -->
                    </div>
                    <div class=""row mb-4"">

                        <div class=""col-12"">
                            <a href=""/Admin/Product/List"" class=""btn btn-secondary ml-3"" style=""background-color:red !important;border-color:red !important;"">İptal Et</a>
                            <input type=""submit"" value=""Ekle"" class=""btn btn-success float-right mr-3"" style=""width:65px;"">

                            <button type=""submit"" style=""width: 65px; height: 38px;"" id=""btnSubtract"" class=""btn btn-danger float-right mr-2"">Çı");
            WriteLiteral(@"kar</button>
                        </div>

                    </div>
                </form> <!-- /.card-body -->
            </div>
            <!-- /.card -->
        </div>
        <div class=""col-md-2"">

            <!-- /.card -->
        </div>
    </div>

</section>
");
            DefineSection("JS", async() => {
                WriteLiteral(@"
    <script>var stockProductUrl = '/Admin/Product/StockProduct';</script>
    <script>var subtractStockProductUrl = '/Admin/Product/SubtractStockProduct';</script>
    <script src=""/js/CustomScripts/Product/subtractStockProduct.js""></script>
    <script src=""/js/CustomScripts/Product/stockProduct.js""></script>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<ListProductNameResponse>> Html { get; private set; }
    }
}
#pragma warning restore 1591
