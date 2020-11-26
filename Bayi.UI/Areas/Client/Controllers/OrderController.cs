using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bayi.Business.IService;
using Bayi.DataAccess;
using Bayi.DTO;
using Bayi.DTO.Order;
using Bayi.DTO.Product;
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
    public class OrderController : BaseController
    {
        private readonly IProductService _productService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IOrderService _orderService;

        public OrderController(
          IProductService productService,
          UserManager<AppUser> userManager,
          IOrderService orderService)
        {
            this._orderService = orderService;
            this._productService = productService;
            this._userManager = userManager;
        }

        public IActionResult List()
        {
            BaseResponse baseResponse = new BaseResponse();
            string userId = HttpContext.Session.GetString(SessionKeyManager.Login);
            List<Order> orderList = _orderService.ListActiveOnesForDealer(Convert.ToInt32(userId));
            List<ListOrderResponse> listOrderResponseList = new List<ListOrderResponse>();
            foreach (Order order in orderList)
                listOrderResponseList.Add(new ListOrderResponse()
                {
                    Id = order.Id,
                    ProductName = order.Product.Name,
                    Quantity = order.Quantity,
                    DateOfOrder = order.DateOfOrder,
                    Statement = order.Statement
                });
            return (IActionResult)this.View((object)listOrderResponseList);
        }

        public IActionResult Create()
        {
            List<Product> activeProducts = this._productService.GetActiveProducts();
           List<ListProductNameResponse> productNameResponseList = new List<ListProductNameResponse>();
            foreach (Product product in activeProducts)
                productNameResponseList.Add(new ListProductNameResponse()
                {
                    Id = product.Id,
                    Name = product.Name
                });
            return (IActionResult)this.View((object)productNameResponseList);
        }

        [HttpPost]
        public async Task<JsonResult> CreateOrder([FromBody] CreateOrderRequest request)
        {
            OrderController orderController = this;
            BaseResponse response = new BaseResponse();
            string userId = HttpContext.Session.GetString(SessionKeyManager.Login);
            AppUser byIdAsync = await orderController._userManager.FindByIdAsync(userId);
            orderController._orderService.Add(new Order()
            {
                AppUserId = byIdAsync.Id,
                DateOfOrder = request.SaleTime.Replace('/', '-'),
                IsActive = true,
                IsRead = false,
                Quantity = Convert.ToInt32(request.Quantity),
                Statement = request.Statement,
                ProductId = request.ProductId
            });
            response.Number = 1;
            response.Message = "Sipariş başarıyla oluşturulmuştur..";
            return Json(response);
        }

        [HttpPost]
        public JsonResult DeleteOrder([FromBody] DeleteOrderRequest request)
        {
            BaseResponse baseResponse = new BaseResponse();
            Bayi.DataAccess.Order byId = this._orderService.GetById(request.OrderId);
            byId.IsActive = false;
            this._orderService.Update(byId);
            baseResponse.Number = 1;
            baseResponse.Message = "Sipariş işlemi başarıyla silinmiştir..";
            return this.Json((object)baseResponse);
        }
    }
}
