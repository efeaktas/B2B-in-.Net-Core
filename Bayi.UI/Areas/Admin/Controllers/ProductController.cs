using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bayi.Business.IService;
using Bayi.DTO;
using Bayi.DTO.Product;
using Bayi.UI.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bayi.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin/[controller]/[action]")]
    [Authorize(Roles = "Admin")]
    public class ProductController : BaseController
    {
        private readonly IProductService _productService;
        private readonly IDealerProductService _dealerProductService;

        public ProductController(
          IProductService productService,
          IDealerProductService dealerProductService)
        {
            this._productService = productService;
            this._dealerProductService = dealerProductService;
        }

        public IActionResult List()
        {
        
            List<ListProductResponse> listProductResponseList = new List<ListProductResponse>();
            foreach (Bayi.DataAccess.Product activeProduct in this._productService.GetActiveProducts())
                listProductResponseList.Add(new ListProductResponse()
                {
                    Id = activeProduct.Id,
                    ProductName = activeProduct.Name,
                    Quantity = activeProduct.Stock,
                    BuyingPrice = string.Format("{0:#,0.00}", (object)activeProduct.AdminBuyPrice),
                    SalePrice = string.Format("{0:#,0.00}", (object)activeProduct.AdminSalePrice)
                });
            return (IActionResult)this.View((object)listProductResponseList);
        }

        public IActionResult Create() => (IActionResult)this.View();

        [HttpPost]
        public JsonResult CreateProduct([FromBody] CreateProductRequest request)
        {
            BaseResponse baseResponse = new BaseResponse();
            this._productService.Add(new Bayi.DataAccess.Product()
            {
                IsActive = true,
                Name = request.ProductName,
                Stock = Convert.ToInt32(request.Quantity),
                AdminBuyPrice = Convert.ToDecimal(request.BuyingPrice.Replace(',', ';').Replace('.', ',').Replace(';', '.')),
                AdminSalePrice = Convert.ToDecimal(request.SalePrice.Replace(',', ';').Replace('.', ',').Replace(';', '.')),
                DealerSalePrice = 0
            });
            baseResponse.Number = 1;
            baseResponse.Message = "Ürün başarıyla oluşturulmuştur..";
            return this.Json((object)baseResponse);
        }

        public IActionResult Update(int productId)
        {
            Bayi.DataAccess.Product byId = this._productService.GetById(productId);
            return (IActionResult)this.View((object)new ListProductSpecificResponse()
            {
                Id = byId.Id,
                ProductName = byId.Name,
                BuyingPrice = string.Format("{0:#,0.00}", (object)byId.AdminBuyPrice),
                SalePrice = string.Format("{0:#,0.00}", (object)byId.AdminSalePrice)
            });
        }

        [HttpPost]
        public JsonResult UpdateProduct([FromBody] UpdateProductRequest request)
        {
            BaseResponse baseResponse = new BaseResponse();
            Bayi.DataAccess.Product byId = this._productService.GetById(request.Id);
            byId.Name = request.ProductName;
            byId.AdminBuyPrice = Convert.ToDecimal(request.BuyingPrice.Replace(',', ';').Replace('.', ',').Replace(';', '.'));
            byId.AdminSalePrice = Convert.ToDecimal(request.SalePrice.Replace(',', ';').Replace('.', ',').Replace(';', '.'));
            this._productService.Update(byId);
            baseResponse.Number = 1;
            baseResponse.Message = "Ürün başarıyla değiştirilmiştir..";
            return this.Json((object)baseResponse);
        }

        [HttpPost]
        public JsonResult DeleteProduct([FromBody] DeleteProductRequest request)
        {
            BaseResponse baseResponse = new BaseResponse();
            Bayi.DataAccess.Product byId = this._productService.GetById(request.Id);
            byId.IsActive = false;
            this._productService.Update(byId);
            baseResponse.Number = 1;
            baseResponse.Message = "Ürün başarıyla silinmiştir..";
            return this.Json((object)baseResponse);
        }

        public IActionResult Stock()
        {
        List<ListProductNameResponse> productNameResponseList = new System.Collections.Generic.List<ListProductNameResponse>();
            foreach (Bayi.DataAccess.Product activeProduct in this._productService.GetActiveProducts())
                productNameResponseList.Add(new ListProductNameResponse()
                {
                    Id = activeProduct.Id,
                    Name = activeProduct.Name,
                    Quantity = activeProduct.Stock
                });
            return (IActionResult)this.View((object)productNameResponseList);
        }

        [HttpPost]
        public JsonResult StockProduct([FromBody] StockProductRequest request)
        {
            BaseResponse baseResponse = new BaseResponse();
            baseResponse.Number = 1;
            baseResponse.Message = "Stok başarıyla eklenmiştir..";
            Bayi.DataAccess.Product byId = this._productService.GetById(request.ProductId);
            byId.Stock += Convert.ToInt32(request.Quantity);
            this._productService.Update(byId);
            return this.Json((object)baseResponse);
        }

        [HttpPost]
        public JsonResult SubtractStockProduct([FromBody] StockProductRequest request)
        {
            BaseResponse baseResponse = new BaseResponse();
            baseResponse.Number = 1;
            baseResponse.Message = "Stok başarıyla çıkarılmıştır..";
            Bayi.DataAccess.Product byId = this._productService.GetById(request.ProductId);
            byId.Stock -= Convert.ToInt32(request.Quantity);
            this._productService.Update(byId);
            return this.Json((object)baseResponse);
        }
    }
}
