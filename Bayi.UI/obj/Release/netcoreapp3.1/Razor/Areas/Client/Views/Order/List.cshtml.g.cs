#pragma checksum "C:\Users\HP\Desktop\Projeler\Bayi\Bayi.UI\Areas\Client\Views\Order\List.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9d7de0e02079d2fd0b02709de56c865363df3426"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Client_Views_Order_List), @"mvc.1.0.view", @"/Areas/Client/Views/Order/List.cshtml")]
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
#line 6 "C:\Users\HP\Desktop\Projeler\Bayi\Bayi.UI\Areas\Client\Views\Order\List.cshtml"
using Bayi.DTO.Order;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9d7de0e02079d2fd0b02709de56c865363df3426", @"/Areas/Client/Views/Order/List.cshtml")]
    public class Areas_Client_Views_Order_List : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<ListOrderResponse>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\HP\Desktop\Projeler\Bayi\Bayi.UI\Areas\Client\Views\Order\List.cshtml"
  
    ViewData["Title"] = "List";
    Layout = "~/Areas/Client/Views/Shared/_ClientLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<section class=""content"">


    <div class=""card"">
        <div class=""card-header"">
            <h3 class=""card-title"">Sipariş Tablosu</h3>
        </div>
        <div class=""card-body"">

            <table id=""example1"" class=""table table-bordered table-striped"">
                <thead>
                    <tr>

                        <th>Ürün İsmi</th>
                        <th>Ürün Adeti</th>
                        <th>Açıklama</th>
                        <th>İşlem Tarihi</th>
                        <th id=""thUpdate""></th>
                    </tr>
                </thead>
                <tbody>
");
#nullable restore
#line 29 "C:\Users\HP\Desktop\Projeler\Bayi\Bayi.UI\Areas\Client\Views\Order\List.cshtml"
                     foreach (ListOrderResponse orderResponse in Model)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n                            <td>");
#nullable restore
#line 32 "C:\Users\HP\Desktop\Projeler\Bayi\Bayi.UI\Areas\Client\Views\Order\List.cshtml"
                           Write(orderResponse.ProductName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 33 "C:\Users\HP\Desktop\Projeler\Bayi\Bayi.UI\Areas\Client\Views\Order\List.cshtml"
                           Write(orderResponse.Quantity);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 34 "C:\Users\HP\Desktop\Projeler\Bayi\Bayi.UI\Areas\Client\Views\Order\List.cshtml"
                           Write(orderResponse.Statement);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 35 "C:\Users\HP\Desktop\Projeler\Bayi\Bayi.UI\Areas\Client\Views\Order\List.cshtml"
                           Write(orderResponse.DateOfOrder);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td class=\"text-center\">\r\n                                <a");
            BeginWriteAttribute("href", " href=\"", 1267, "\"", 1274, 0);
            EndWriteAttribute();
            WriteLiteral(" id=\"btnDelete\" data-record-id=\"");
#nullable restore
#line 37 "C:\Users\HP\Desktop\Projeler\Bayi\Bayi.UI\Areas\Client\Views\Order\List.cshtml"
                                                                     Write(orderResponse.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" data-toggle=\"modal\" data-target=\"#confirm-delete\" class=\"btn btn-danger btn-sm float-right\">Sil</a>\r\n                            </td>\r\n                        </tr>\r\n");
#nullable restore
#line 40 "C:\Users\HP\Desktop\Projeler\Bayi\Bayi.UI\Areas\Client\Views\Order\List.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </tbody>\r\n\r\n            </table>\r\n        </div>\r\n        <!-- /.card-body -->\r\n    </div>\r\n\r\n\r\n\r\n</section>\r\n");
            DefineSection("JS", async() => {
                WriteLiteral("\r\n    <script>var deleteOrderUrl = \'/Client/Order/DeleteOrder\';</script>\r\n    <script src=\"/js/CustomScriptsClient/Order/deleteOrder.js\"></script>\r\n    <script src=\"/js/CustomScriptsClient/Order/listOrder.js\"></script>\r\n\r\n");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<ListOrderResponse>> Html { get; private set; }
    }
}
#pragma warning restore 1591
