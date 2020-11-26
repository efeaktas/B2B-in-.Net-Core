using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bayi.Business.IService;
using Bayi.DataAccess;
using Bayi.DTO.Dealer;
using Bayi.DTO.Sale;
using Bayi.UI.Controllers;
using Bayi.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Bayi.UI.Areas.Client.Controllers
{
    [Area("Client")]
    [Route("client/[controller]/[action]")]
    [Authorize(Roles = "Bayi")]
    public class ProductController : BaseController
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IDealerProductService _dealerProductService;
        private readonly IAdminSaleService _adminSaleService;
        private readonly IDealerService _dealerService;
        private readonly IProductService _productService;

        public ProductController(
          UserManager<AppUser> userManager,
          IDealerProductService dealerProductService,
          IAdminSaleService adminSaleService,
          IDealerService dealerService,
          IProductService productService)
        {
            this._productService = productService;
            this._dealerProductService = dealerProductService;
            this._userManager = userManager;
            this._adminSaleService = adminSaleService;
            this._dealerService = dealerService;
        }

        public async Task<IActionResult> StockStatus()
        {
            ProductController productController = this;
            string userId = HttpContext.Session.GetString(SessionKeyManager.Login);
            AppUser byIdAsync = await productController._userManager.FindByIdAsync(userId);
            List<DealerProduct> dealerProductList = productController._dealerProductService.ListDealerStockStatusForDealer(Convert.ToInt32(userId));
            List<ListDealerStockStatusResponse> stockStatusResponseList = new List<ListDealerStockStatusResponse>();
            foreach (DealerProduct dealerProduct in dealerProductList)
                stockStatusResponseList.Add(new ListDealerStockStatusResponse()
                {
                    Id = dealerProduct.Product.Id,
                    ProductName = dealerProduct.Product.Name,
                    Quantity = dealerProduct.Stock
                });
            IActionResult iactionResult = (IActionResult)productController.View((object)stockStatusResponseList);
            userId = (string)null;
            return iactionResult;
        }

        public IActionResult BuyingList()
        {
            string userId = HttpContext.Session.GetString(SessionKeyManager.Login);
            Dealer dealer=_dealerService.GetByAppUserId(Convert.ToInt32(userId));
            List<AdminSale> salesByDealer = _adminSaleService.GetSalesByDealer(dealer.Id);
            List<ListSaleResponse> listSaleResponseList = new List<ListSaleResponse>();
            foreach (AdminSale adminSale in salesByDealer)
                listSaleResponseList.Add(new ListSaleResponse()
                {
                    ProductName = adminSale.Product.Name,
                    DateOfSale = adminSale.DateOfSale,
                    TotalPrice = string.Format("{0:#,0.00}", (object)adminSale.TotalPrice),
                    UnitPrice = string.Format("{0:#,0.00}", (object)adminSale.UnitPrice),
                    Quantity = adminSale.Quantity
                });
            return (IActionResult)this.View((object)listSaleResponseList);
        }
    }
}
