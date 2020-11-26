using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bayi.Business.IService;
using Bayi.DataAccess;
using Bayi.DTO;
using Bayi.DTO.Customer;
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
    public class CustomerController : BaseController
    {
        private readonly ICustomerService _customerService;
        private readonly IDealerService _dealerService;

        public CustomerController(ICustomerService customerService, IDealerService dealerService)
        {
            this._dealerService = dealerService;
            this._customerService = customerService;
        }

        public IActionResult List()
        {
            string userId = HttpContext.Session.GetString(SessionKeyManager.Login);
            Dealer dealer = this._dealerService.GetByAppUserId(Convert.ToInt32(userId));
           List<Customer> customerList = this._customerService.ListActiveOnesByDealerId(dealer.Id);
            List<ListCustomerResponse> customerResponseList = new List<ListCustomerResponse>();
            foreach (Customer customer in customerList)
                customerResponseList.Add(new ListCustomerResponse()
                {
                    Id = customer.Id,
                    CompanyName = customer.CompanyName,
                    Email = customer.Email,
                    Address = customer.Address,
                    Phone = customer.Phone,
                    Authorized = customer.AuthorizedPerson
                });
            return (IActionResult)this.View((object)customerResponseList);
        }

        public IActionResult Create() => (IActionResult)this.View();

        [HttpPost]
        public JsonResult CreateCustomer([FromBody] CreateCustomerRequest request)
        {
            string userId = HttpContext.Session.GetString(SessionKeyManager.Login);
            Dealer dealer = this._dealerService.GetByAppUserId(Convert.ToInt32(userId));
            BaseResponse baseResponse = new BaseResponse();
            this._customerService.Add(new Customer()
            {
                IsActive = true,
                Email = request.Email,
                CompanyName = request.CompanyName,
                AuthorizedPerson = request.Authorized,
                Phone = request.Phone,
                Address = request.Address,
                DealerId = dealer.Id
            });
            baseResponse.Number = 1;
            baseResponse.Message = "Müşteri başarılı bir şekilde oluşturulmuştur..";
            return this.Json((object)baseResponse);
        }

        public IActionResult Update(int customerId)
        {
            Bayi.DataAccess.Customer byId = this._customerService.GetById(customerId);
            return (IActionResult)this.View((object)new ListCustomerResponse()
            {
                CompanyName = byId.CompanyName,
                Email = byId.Email,
                Phone = byId.Phone,
                Address = byId.Address,
                Authorized = byId.AuthorizedPerson,
                Id = byId.Id
            });
        }

        [HttpPost]
        public JsonResult UpdateCustomer([FromBody] UpdateCustomerRequest request)
        {
            BaseResponse baseResponse = new BaseResponse();
            Bayi.DataAccess.Customer byId = this._customerService.GetById(request.Id);
            byId.Email = request.Email;
            byId.Phone = request.Phone;
            byId.Address = request.Address;
            byId.CompanyName = request.CompanyName;
            byId.AuthorizedPerson = request.Authorized;
            this._customerService.Update(byId);
            baseResponse.Message = "Bilgiler başarıyla değiştirilmiştir..";
            baseResponse.Number = 1;
            return this.Json((object)baseResponse);
        }

        [HttpPost]
        public JsonResult DeleteCustomer([FromBody] DeleteCustomerRequest request)
        {
            BaseResponse baseResponse = new BaseResponse();
            Bayi.DataAccess.Customer byId = this._customerService.GetById(request.CustomerId);
            byId.IsActive = false;
            this._customerService.Update(byId);
            baseResponse.Number = 1;
            baseResponse.Message = "Kullanıcı başarıyla silinmiştir..";
            return this.Json((object)baseResponse);
        }
    }
}
