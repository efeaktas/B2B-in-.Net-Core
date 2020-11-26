using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bayi.Business.IService;
using Bayi.DTO.Order;
using Bayi.UI.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bayi.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin/[controller]/[action]")]
    [Authorize(Roles = "Admin")]
    public class OrderController : BaseController
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService) => this._orderService = orderService;

        public IActionResult List()
        {
            System.Collections.Generic.List<Bayi.DataAccess.Order> orderList = this._orderService.ListActiveOnes();
            System.Collections.Generic.List<ListOrderResponse> listOrderResponseList = new System.Collections.Generic.List<ListOrderResponse>();
            foreach (Bayi.DataAccess.Order order in orderList)
                listOrderResponseList.Add(new ListOrderResponse()
                {
                    Id = order.Id,
                    DealerName = order.AppUser.CompanyName,
                    ProductName = order.Product.Name,
                    Quantity = order.Quantity,
                    DateOfOrder = order.DateOfOrder,
                    Statement = order.Statement,
                    IsRead = order.IsRead
                });
            return (IActionResult)this.View((object)listOrderResponseList);
        }

        public IActionResult ListReadOnes()
        {
            System.Collections.Generic.List<Bayi.DataAccess.Order> orderList = this._orderService.ListReadOnes();
            System.Collections.Generic.List<ListOrderResponse> listOrderResponseList = new System.Collections.Generic.List<ListOrderResponse>();
            foreach (Bayi.DataAccess.Order order in orderList)
                listOrderResponseList.Add(new ListOrderResponse()
                {
                    DealerName = order.AppUser.CompanyName,
                    ProductName = order.Product.Name,
                    Quantity = order.Quantity,
                    DateOfOrder = order.DateOfOrder,
                    Statement = order.Statement
                });
            return (IActionResult)this.View((object)listOrderResponseList);
        }

        [HttpPost]
        public JsonResult IsRead([FromBody] ReadOrderRequest request)
        {
            Bayi.DataAccess.Order byId = this._orderService.GetById(request.Id);
            byId.IsRead = true;
            this._orderService.Update(byId);
            return this.Json((object)"");
        }

        [HttpPost]
        public JsonResult Notification()
        {
            System.Collections.Generic.List<Bayi.DataAccess.Order> source = this._orderService.ListActiveOnes();
            System.Collections.Generic.List<ListOrderNotification> orderNotificationList = new System.Collections.Generic.List<ListOrderNotification>();
            foreach (Bayi.DataAccess.Order order in source.TakeLast<Bayi.DataAccess.Order>(5).ToList<Bayi.DataAccess.Order>())
                orderNotificationList.Add(new ListOrderNotification()
                {
                    CompanyName = order.AppUser.CompanyName,
                    OrderDate = order.DateOfOrder,
                    OrderCount = source.Count
                });
            return this.Json((object)orderNotificationList);
        }
    }
}
