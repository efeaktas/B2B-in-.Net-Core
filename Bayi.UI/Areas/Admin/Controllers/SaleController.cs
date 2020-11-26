using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bayi.Business.IService;
using Bayi.DataAccess;
using Bayi.DTO;
using Bayi.DTO.Dealer;
using Bayi.DTO.Product;
using Bayi.DTO.Sale;
using Bayi.UI.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bayi.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin/[controller]/[action]")]
    [Authorize(Roles = "Admin")]
    public class SaleController : BaseController
    {
        private readonly IDealerService _dealerService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IProductService _productService;
        private readonly IAdminSaleService _adminSaleService;
        private readonly IDealerProductService _dealerProductService;

        public SaleController(
          UserManager<AppUser> userManager,
          IProductService productService,
          IAdminSaleService adminSaleService,
          IDealerProductService dealerProductService,
          IDealerService dealerService)
        {
            this._userManager = userManager;
            this._productService = productService;
            this._adminSaleService = adminSaleService;
            this._dealerProductService = dealerProductService;
            this._dealerService = dealerService;
        }

        public IActionResult List()
        {
            List<AdminSale> adminSaleList = this._adminSaleService.ListActives();
          List<ListSaleResponse> listSaleResponseList = new List<ListSaleResponse>();
            foreach (AdminSale adminSale in adminSaleList)
                listSaleResponseList.Add(new ListSaleResponse()
                {
                    Id = adminSale.Id,
                    ProductName = adminSale.Product.Name,
                    CompanyName = adminSale.Dealer.AppUser.CompanyName,
                    DateOfSale = adminSale.DateOfSale,
                    TotalPrice = string.Format("{0:#,0.00}", (object)adminSale.TotalPrice),
                    UnitPrice = string.Format("{0:#,0.00}", (object)adminSale.UnitPrice),
                    Quantity = adminSale.Quantity
                });
            return (IActionResult)this.View((object)listSaleResponseList);
        }

        [HttpPost]
        public JsonResult DeleteSale([FromBody] DeleteSaleRequest request)
        {
            BaseResponse baseResponse = new BaseResponse();
            AdminSale sale = this._adminSaleService.GetSale(request.SaleId);
            this._adminSaleService.UpdateSaleStock(sale, sale.Quantity);
            this._dealerProductService.UpdateDealerStock(this._dealerProductService.IsExists(sale.DealerId, sale.ProductId), sale.Quantity);
            baseResponse.Number = 1;
            baseResponse.Message = "Satış işlemi başarıyla silinmiştir..";
            return this.Json((object)baseResponse);
        }

        public async Task<IActionResult> Create()
        {
            SaleController saleController = this;
            List<AppUser> appUsers = await _userManager.Users.Where(p => p.IsActive == true).Include(r => r.Dealers).ToListAsync();
            List<AppUser> dealerUsers = new List<AppUser>();
            for (int i = 0; i < appUsers.Count; ++i)
            {
                if (await saleController._userManager.IsInRoleAsync(appUsers[i], "Bayi"))
                    dealerUsers.Add(appUsers[i]);
            }
            List<Product> activeProducts = saleController._productService.GetActiveProducts();
            List<ListProductForSaleResponse> productForSaleResponseList = new List<ListProductForSaleResponse>();
            //Productların eklenmesi
            foreach (Product product in activeProducts)
                productForSaleResponseList.Add(new ListProductForSaleResponse()
                {
                    Id = product.Id,
                    ProductName = product.Name,
                    Quantity = product.Stock,
                    SalePrice = string.Format("{0:#,0.00}", (object)product.AdminSalePrice)
                });
            List<ListDealerNameResponse> dealerNameResponseList = new List<ListDealerNameResponse>();
            //Userların eklenmesi
            foreach (AppUser appUser in dealerUsers)
                dealerNameResponseList.Add(new ListDealerNameResponse()
                {
                    Id = appUser.Dealers.First().Id,
                    Name = appUser.CompanyName
                });
            ViewBag.Products = productForSaleResponseList;
            ViewBag.Dealers = dealerNameResponseList;
            return View();
        }

        [HttpPost]
        public JsonResult CreateSale([FromBody] CreateSaleRequest request)
        {
            string unitPrice = string.Empty;
            if (request.SalePrice.Substring(request.SalePrice.Length-3).Contains(','))
            {
                unitPrice = request.SalePrice;
            }
            else
            {
              unitPrice = request.SalePrice.Replace(',', ';').Replace('.', ',').Replace(';', '.');
            }
            BaseResponse baseResponse = new BaseResponse();
            AdminSale sale = new AdminSale();
            sale.AdminId = 2;
            sale.ProductId = request.ProductId;
            sale.DateOfSale = request.SaleTime.Replace('/', '-');
            sale.DealerId = request.DealerId;
            sale.Quantity = Convert.ToInt32(request.Quantity);
            sale.UnitPrice = Convert.ToDecimal(unitPrice);
            sale.TotalPrice = sale.UnitPrice * sale.Quantity;
            sale.IsActive = true;
            _adminSaleService.Add(sale);

            Product product = _productService.GetById(request.ProductId);
            int int32 = Convert.ToInt32(request.Quantity);
            product.Stock -= int32;
            this._productService.Update(product);
            DealerProduct dealerProduct = this._dealerProductService.IsExists(request.DealerId, request.ProductId);
            if (dealerProduct == null)
            {
                this._dealerProductService.Add(new DealerProduct()
                {
                    DealerId = request.DealerId,
                    Stock = int32,
                    DealerBuyPrice = product.AdminSalePrice,
                    IsActive = true,
                    ProductId = request.ProductId
                });
            }
            else
            {
                dealerProduct.Stock += int32;
                this._dealerProductService.Update(dealerProduct);
            }
            baseResponse.Number = 1;
            baseResponse.Message = "Satış başarılı bir şekilde yapılmıştır..";
            return this.Json((object)baseResponse);
        }
    }
}
