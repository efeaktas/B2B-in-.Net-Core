#pragma checksum "C:\Users\HP\Desktop\Projeler\Bayi\Bayi.UI\Areas\Admin\Views\Dealer\List.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6a79e858d89cd815b32636d1fdb7c099af83c072"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Dealer_List), @"mvc.1.0.view", @"/Areas/Admin/Views/Dealer/List.cshtml")]
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
#line 6 "C:\Users\HP\Desktop\Projeler\Bayi\Bayi.UI\Areas\Admin\Views\Dealer\List.cshtml"
using Bayi.DTO.Dealer;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6a79e858d89cd815b32636d1fdb7c099af83c072", @"/Areas/Admin/Views/Dealer/List.cshtml")]
    public class Areas_Admin_Views_Dealer_List : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<ListDealerResponse>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\HP\Desktop\Projeler\Bayi\Bayi.UI\Areas\Admin\Views\Dealer\List.cshtml"
  
    ViewData["Title"] = "List";
    Layout = "~/Areas/Admin/Views/_AdminLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<section class=""content"">

    <div class=""card"">
        <div class=""card-header"">
            <h3 class=""card-title"">Bayi Tablosu</h3>
        </div>
        <div class=""card-body"">

            <table id=""example1"" class=""table table-bordered table-striped"">
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>Firma Ünvanı</th>
                        <th>Yetkili Kişi</th>
                        <th>Adres</th>
                        <th>Telefon</th>
                        <th>Email</th>
                        <th id=""thUpdate""></th>
                    </tr>
                </thead>
                <tbody>
");
#nullable restore
#line 29 "C:\Users\HP\Desktop\Projeler\Bayi\Bayi.UI\Areas\Admin\Views\Dealer\List.cshtml"
                     foreach (ListDealerResponse dealer in Model)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>");
#nullable restore
#line 32 "C:\Users\HP\Desktop\Projeler\Bayi\Bayi.UI\Areas\Admin\Views\Dealer\List.cshtml"
                       Write(dealer.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 33 "C:\Users\HP\Desktop\Projeler\Bayi\Bayi.UI\Areas\Admin\Views\Dealer\List.cshtml"
                       Write(dealer.CompanyName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 34 "C:\Users\HP\Desktop\Projeler\Bayi\Bayi.UI\Areas\Admin\Views\Dealer\List.cshtml"
                       Write(dealer.Authorized);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 35 "C:\Users\HP\Desktop\Projeler\Bayi\Bayi.UI\Areas\Admin\Views\Dealer\List.cshtml"
                       Write(dealer.Address);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 36 "C:\Users\HP\Desktop\Projeler\Bayi\Bayi.UI\Areas\Admin\Views\Dealer\List.cshtml"
                       Write(dealer.Phone);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 37 "C:\Users\HP\Desktop\Projeler\Bayi\Bayi.UI\Areas\Admin\Views\Dealer\List.cshtml"
                       Write(dealer.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td class=\"text-center\">\r\n                            <a");
            BeginWriteAttribute("href", " href=\"", 1352, "\"", 1399, 2);
            WriteAttributeValue("", 1359, "/Admin/Dealer/Update?dealerId=", 1359, 30, true);
#nullable restore
#line 39 "C:\Users\HP\Desktop\Projeler\Bayi\Bayi.UI\Areas\Admin\Views\Dealer\List.cshtml"
WriteAttributeValue("", 1389, dealer.Id, 1389, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-secondary btn-sm float-right\">Düzenle</a>\r\n                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 42 "C:\Users\HP\Desktop\Projeler\Bayi\Bayi.UI\Areas\Admin\Views\Dealer\List.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </tbody>\r\n\r\n            </table>\r\n        </div>\r\n        <!-- /.card-body -->\r\n    </div>\r\n\r\n</section>\r\n");
            DefineSection("JS", async() => {
                WriteLiteral("\r\n\r\n    <script src=\"/js/CustomScripts/Dealer/listDealer.js\"></script>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<ListDealerResponse>> Html { get; private set; }
    }
}
#pragma warning restore 1591
