#pragma checksum "C:\Users\HP\Desktop\Projeler\Dealer\Bayi.UI\Areas\Client\Views\Sale\List.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "71480dd78201b7c21850d33fbbc45a503e3bde7b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Client_Views_Sale_List), @"mvc.1.0.view", @"/Areas/Client/Views/Sale/List.cshtml")]
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
#line 6 "C:\Users\HP\Desktop\Projeler\Dealer\Bayi.UI\Areas\Client\Views\Sale\List.cshtml"
using Bayi.DTO.Sale;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"71480dd78201b7c21850d33fbbc45a503e3bde7b", @"/Areas/Client/Views/Sale/List.cshtml")]
    public class Areas_Client_Views_Sale_List : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<ListSaleResponse>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\HP\Desktop\Projeler\Dealer\Bayi.UI\Areas\Client\Views\Sale\List.cshtml"
  
    ViewData["Title"] = "List";
    Layout = "~/Areas/Client/Views/Shared/_ClientLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<section class=""content"">


    <div class=""card"">
        <div class=""card-header"">
            <h3 class=""card-title"">Satış Tablosu</h3>
        </div>
        <div class=""card-body"">

            <table id=""example1"" class=""table table-bordered table-striped"">
                <thead>
                    <tr>

                        <th>Firma Ünvanı</th>
                        <th>Ürün İsmi</th>
                        <th>Birim Fiyatı</th>
                        <th>Ürün Adeti</th>
                        <th>Toplam Fiyat</th>
                        <th>Satış Tarihi</th>
                        <th id=""thUpdate""></th>
                    </tr>
                </thead>
                <tbody>
");
#nullable restore
#line 31 "C:\Users\HP\Desktop\Projeler\Dealer\Bayi.UI\Areas\Client\Views\Sale\List.cshtml"
                     foreach (ListSaleResponse saleResponse in Model)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n                            <td>");
#nullable restore
#line 34 "C:\Users\HP\Desktop\Projeler\Dealer\Bayi.UI\Areas\Client\Views\Sale\List.cshtml"
                           Write(saleResponse.CompanyName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 35 "C:\Users\HP\Desktop\Projeler\Dealer\Bayi.UI\Areas\Client\Views\Sale\List.cshtml"
                           Write(saleResponse.ProductName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 36 "C:\Users\HP\Desktop\Projeler\Dealer\Bayi.UI\Areas\Client\Views\Sale\List.cshtml"
                           Write(saleResponse.UnitPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 37 "C:\Users\HP\Desktop\Projeler\Dealer\Bayi.UI\Areas\Client\Views\Sale\List.cshtml"
                           Write(saleResponse.Quantity);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 38 "C:\Users\HP\Desktop\Projeler\Dealer\Bayi.UI\Areas\Client\Views\Sale\List.cshtml"
                           Write(saleResponse.TotalPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 39 "C:\Users\HP\Desktop\Projeler\Dealer\Bayi.UI\Areas\Client\Views\Sale\List.cshtml"
                           Write(saleResponse.DateOfSale);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td class=\"text-center\">\r\n                                <a data-href=\"\" id=\"btnDelete\" data-record-id=\"");
#nullable restore
#line 41 "C:\Users\HP\Desktop\Projeler\Dealer\Bayi.UI\Areas\Client\Views\Sale\List.cshtml"
                                                                          Write(saleResponse.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" data-toggle=\"modal\" data-target=\"#confirm-delete\" class=\"btn btn-danger btn-sm float-right\">Sil</a>\r\n                            </td>\r\n                        </tr>\r\n");
#nullable restore
#line 44 "C:\Users\HP\Desktop\Projeler\Dealer\Bayi.UI\Areas\Client\Views\Sale\List.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                </tbody>\r\n\r\n            </table>\r\n        </div>\r\n        <!-- /.card-body -->\r\n    </div>\r\n\r\n\r\n\r\n\r\n</section>\r\n");
            DefineSection("JS", async() => {
                WriteLiteral("\r\n\r\n    <script>var deleteSaleUrl =\'/Client/Sale/DeleteSale\';</script>\r\n    <script src=\"/js/CustomScriptsClient/Sale/deleteSale.js\"></script>\r\n    <script src=\"/js/CustomScriptsClient/Sale/listSale.js\"></script>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<ListSaleResponse>> Html { get; private set; }
    }
}
#pragma warning restore 1591