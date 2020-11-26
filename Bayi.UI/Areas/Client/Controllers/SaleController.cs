using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bayi.Business.IService;
using Bayi.DataAccess;
using Bayi.DTO;
using Bayi.DTO.Customer;
using Bayi.DTO.Product;
using Bayi.DTO.Sale;
using Bayi.UI.Controllers;
using Bayi.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bayi.UI.Areas.Client.Controllers
{
    [Area("Client")]
    [Route("client/[controller]/[action]")]
    [Authorize(Roles = "Bayi")]
    public class SaleController : BaseController
    {
        private readonly ICustomerService _customerService;
        private readonly IDealerService _dealerService;
        private readonly IDealerProductService _dealerProductService;
        private readonly IDealerSaleService _dealerSaleService;

        public SaleController(
          ICustomerService customerService,
          IDealerService dealerService,
          IDealerProductService dealerProductService,
          IDealerSaleService dealerSaleService)
        {
            this._customerService = customerService;
            this._dealerService = dealerService;
            this._dealerProductService = dealerProductService;
            this._dealerSaleService = dealerSaleService;
        }

        public IActionResult List()
        {
            string userId = HttpContext.Session.GetString(SessionKeyManager.Login);
            Dealer dealer = _dealerService.GetByAppUserId(Convert.ToInt32(userId));
            List<DealerSale> dealerSaleList = _dealerSaleService.ListActiveOnesForDealer(dealer.Id);
            List<ListSaleResponse> listSaleResponseList = new List<ListSaleResponse>();
            foreach (DealerSale dealerSale in dealerSaleList)
                listSaleResponseList.Add(new ListSaleResponse()
                {
                    Id = dealerSale.Id,
                    ProductName = dealerSale.Product.Name,
                    CompanyName = dealerSale.Customer.CompanyName,
                    DateOfSale = dealerSale.DateOfSale,
                    TotalPrice = string.Format("{0:#,0.00}", (object)dealerSale.TotalPrice),
                    UnitPrice = string.Format("{0:#,0.00}", (object)dealerSale.UnitPrice),
                    Quantity = dealerSale.Quantity
                });
            return (IActionResult)this.View((object)listSaleResponseList);
        }

        [HttpPost]
        public JsonResult DeleteSale([FromBody] DeleteSaleRequest request)
        {
            BaseResponse baseResponse = new BaseResponse();
            DealerSale sale = this._dealerSaleService.GetSale(request.SaleId);
            sale.IsActive = false;
            this._dealerSaleService.Update(sale);
            DealerProduct dealerProduct = this._dealerProductService.IsExists(sale.DealerId, sale.ProductId);
            dealerProduct.Stock += sale.Quantity;
            this._dealerProductService.Update(dealerProduct);
            baseResponse.Number = 1;
            baseResponse.Message = "Satış işlemi başarıyla silinmiştir..";
            return this.Json((object)baseResponse);
        }

        public IActionResult Create()
        {
            string userId = HttpContext.Session.GetString(SessionKeyManager.Login);
            int int32 = Convert.ToInt32(userId);
            Dealer dealer = _dealerService.GetByAppUserId(int32);
            List<Customer> customerList = _customerService.ListActiveOnesByDealerId(dealer.Id);
            List<ListCustomerNameResponse> customerNameResponseList = new List<ListCustomerNameResponse>();
            foreach (Customer customer in customerList)
                customerNameResponseList.Add(new ListCustomerNameResponse()
                {
                    Id = customer.Id,
                    Name = customer.CompanyName
                });

            List<DealerProduct> dealerProductList = _dealerProductService.ListDealerStockStatusForDealer(int32);
            List<ListProductForSaleResponse> productForSaleResponseList = new List<ListProductForSaleResponse>();
            foreach (DealerProduct dealerProduct in dealerProductList)
                productForSaleResponseList.Add(new ListProductForSaleResponse()
                {
                    Id = dealerProduct.ProductId,
                    ProductName = dealerProduct.Product.Name,
                    Quantity = dealerProduct.Stock
                });
            ViewBag.Customers = customerNameResponseList;
            ViewBag.DealerProducts = productForSaleResponseList;
            return (IActionResult)this.View();
        }

        [HttpPost]
        public JsonResult CreateSale([FromBody] CreateSaleForCustomerRequest request)
        {
            string unitPrice = string.Empty;
            if (request.SalePrice.Substring(request.SalePrice.Length - 3).Contains(','))
            {
                unitPrice = request.SalePrice;
            }
            else
            {
                unitPrice = request.SalePrice.Replace(',', ';').Replace('.', ',').Replace(';', '.');
            }
            string userId = HttpContext.Session.GetString(SessionKeyManager.Login);
            BaseResponse baseResponse = new BaseResponse();
            int id = Convert.ToInt32(userId);
            int quantity = Convert.ToInt32(request.Quantity);
            Dealer dealer = _dealerService.GetByAppUserId(id);
            DealerSale sale = new DealerSale();
            sale.DealerId = dealer.Id;
            sale.CustomerId = request.CustomerId;
            sale.DateOfSale = request.SaleTime.Replace('/', '-');
            sale.IsActive = true;
            sale.Quantity = quantity;
            sale.ProductId = request.ProductId;
            sale.UnitPrice = Convert.ToDecimal(unitPrice);
            sale.TotalPrice = sale.UnitPrice * sale.Quantity;
            _dealerSaleService.Add(sale);
            _dealerProductService.UpdateDealerStock(_dealerProductService.IsExists(dealer.Id, request.ProductId), quantity);
            baseResponse.Number = 1;
            baseResponse.Message = "Satış başarılı bir şekilde yapılmıştır..";
            return this.Json((object)baseResponse);
        }
    }
}
