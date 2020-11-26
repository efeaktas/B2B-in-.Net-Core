using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bayi.Business.IService;
using Bayi.DataAccess;
using Bayi.DTO;
using Bayi.DTO.Customer;
using Bayi.DTO.Dealer;
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
    public class DealerController : BaseController
    {
        private readonly IDealerService _dealerService;
        private readonly IDealerProductService _dealerProductService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IDealerSaleService _dealerSaleService;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly ICustomerService _customerService;

        public DealerController(
          UserManager<AppUser> userManager,
          SignInManager<AppUser> signInManager,
          RoleManager<AppRole> roleManager,
          IDealerService dealerService,
          IDealerProductService dealerProductService,
          IDealerSaleService dealerSaleService,
          ICustomerService customerService)
        {
            this._dealerSaleService = dealerSaleService;
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._roleManager = roleManager;
            this._dealerService = dealerService;
            this._dealerProductService = dealerProductService;
            this._customerService = customerService;
        }

        public async Task<IActionResult> List()
        {
            DealerController dealerController = this;
            IList<AppUser> list = (IList<AppUser>)(await dealerController._userManager.GetUsersInRoleAsync("Bayi")).Where<AppUser>((Func<AppUser, bool>)(p => p.IsActive)).ToList<AppUser>();
            System.Collections.Generic.List<ListDealerResponse> listDealerResponseList = new System.Collections.Generic.List<ListDealerResponse>();
            foreach (AppUser appUser in (IEnumerable<AppUser>)list)
                listDealerResponseList.Add(new ListDealerResponse()
                {
                    Id = appUser.Id,
                    CompanyName = appUser.CompanyName,
                    Email = appUser.Email,
                    Address = appUser.Address,
                    Phone = appUser.PhoneNumber,
                    Authorized = appUser.AuthorizedPerson
                });
            return (IActionResult)dealerController.View((object)listDealerResponseList);
        }

        public IActionResult Create() => (IActionResult)this.View();

        [HttpPost]
        public async Task<JsonResult> CreateDealer([FromBody] CreateDealerRequest request)
        {
            DealerController dealerController = this;
            BaseResponse baseResponse = new BaseResponse();
            AppUser appUser = await dealerController._userManager.FindByEmailAsync(request.Email);
            if (appUser == null)
            {
                appUser = new AppUser();
                appUser.Email = request.Email;
                appUser.CompanyName = request.CompanyName;
                appUser.UserName = request.Email;
                appUser.AuthorizedPerson = request.Authorized;
                appUser.PhoneNumber = request.Phone;
                appUser.IsActive = true;
                appUser.Address = request.Address;
                appUser.EmailConfirmed = true;
                IdentityResult async = await dealerController._userManager.CreateAsync(appUser, "Test123123");
                dealerController._dealerService.Add(new Bayi.DataAccess.Dealer()
                {
                    IsActive = true,
                    AppUserId = appUser.Id
                });
                IdentityResult roleAsync = await dealerController._userManager.AddToRoleAsync(appUser, "Bayi");
                baseResponse.Number = 1;
                baseResponse.Message = "Bayi başarılı bir şekilde oluşturulmuştur..";
                return dealerController.Json((object)baseResponse);
            }
            baseResponse.Number = 2;
            baseResponse.Message = "Daha önce alınmış bir Email adresi girdiniz..";
            return dealerController.Json((object)baseResponse);
        }

        public async Task<IActionResult> Update(int dealerId)
        {
            DealerController dealerController = this;
            AppUser byIdAsync = await dealerController._userManager.FindByIdAsync(dealerId.ToString());
            return (IActionResult)dealerController.View((object)new ListDealerResponse()
            {
                CompanyName = byIdAsync.CompanyName,
                Email = byIdAsync.Email,
                Phone = byIdAsync.PhoneNumber,
                Address = byIdAsync.Address,
                Authorized = byIdAsync.AuthorizedPerson,
                Id = byIdAsync.Id
            });
        }

        [HttpPost]
        public async Task<JsonResult> UpdateDealer([FromBody] UpdateDealerRequest request)
        {
            DealerController dealerController = this;
            BaseResponse response = new BaseResponse();
            string userId = request.Id.ToString();
            AppUser byIdAsync = await dealerController._userManager.FindByIdAsync(userId);
            byIdAsync.Email = request.Email;
            byIdAsync.UserName = request.Email;
            byIdAsync.PhoneNumber = request.Phone;
            byIdAsync.Address = request.Address;
            byIdAsync.CompanyName = request.CompanyName;
            byIdAsync.AuthorizedPerson = request.Authorized;
            if ((await dealerController._userManager.UpdateAsync(byIdAsync)).Succeeded)
            {
                response.Message = "Bilgiler başarıyla değiştirilmiştir..";
                response.Number = 1;
                return dealerController.Json((object)response);
            }
            response.Message = "Bu email adresi kullanılmaktadır.Lütfen farklı bir email adresi giriniz..";
            response.Number = 2;
            return dealerController.Json((object)response);
        }

        [HttpPost]
        public async Task<JsonResult> DeleteDealer([FromBody] DeleteDealerRequest request)
        {
            DealerController dealerController = this;
            BaseResponse response = new BaseResponse();
            AppUser appDealer = await dealerController._userManager.Users.Where(p=>p.Id==request.DealerId).Include(c=>c.Dealers).FirstOrDefaultAsync(); 
            
            AppUser byIdAsync = await dealerController._userManager.FindByIdAsync(request.DealerId.ToString());
            byIdAsync.IsActive = false;
            byIdAsync.EmailConfirmed = false;
            if ((await dealerController._userManager.UpdateAsync(byIdAsync)).Succeeded)
            {
                Bayi.DataAccess.Dealer dealer = appDealer.Dealers.FirstOrDefault<Bayi.DataAccess.Dealer>();
                dealer.IsActive = false;
                dealerController._dealerService.Update(dealer);
                response.Number = 1;
                response.Message = "Kullanıcı başarıyla silinmiştir..";
                return dealerController.Json((object)response);
            }
            response.Number = 2;
            response.Message = "Kullanıcı silme işlemi yapılırken hata oluştu..";
            return dealerController.Json((object)response);
        }

        public IActionResult StockStatus()
        {
            this._dealerService.ListDealerStockStatus();
            System.Collections.Generic.List<DealerProduct> dealerProductList = this._dealerProductService.ListDealerStockStatus();
            System.Collections.Generic.List<ListDealerStockStatusResponse> stockStatusResponseList = new System.Collections.Generic.List<ListDealerStockStatusResponse>();
            foreach (DealerProduct dealerProduct in dealerProductList)
                stockStatusResponseList.Add(new ListDealerStockStatusResponse()
                {
                    Id = dealerProduct.Id,
                    CompanyName = dealerProduct.Dealer.AppUser.CompanyName,
                    ProductName = dealerProduct.Product.Name,
                    Quantity = dealerProduct.Stock
                });
            return (IActionResult)this.View((object)stockStatusResponseList);
        }

        public IActionResult Sales()
        {
            System.Collections.Generic.List<DealerSale> dealerSaleList = this._dealerSaleService.ListActiveOnes();
            System.Collections.Generic.List<ListSaleResponse> listSaleResponseList = new System.Collections.Generic.List<ListSaleResponse>();
            foreach (DealerSale dealerSale in dealerSaleList)
                listSaleResponseList.Add(new ListSaleResponse()
                {
                    CompanyName = dealerSale.Dealer.AppUser.CompanyName,
                    CustomerName = dealerSale.Customer.CompanyName,
                    DateOfSale = dealerSale.DateOfSale,
                    ProductName = dealerSale.Product.Name,
                    Quantity = dealerSale.Quantity,
                    TotalPrice = dealerSale.TotalPrice.ToString().Replace(',', '.'),
                    UnitPrice = dealerSale.UnitPrice.ToString().Replace(',', '.')
                });
            return (IActionResult)this.View((object)listSaleResponseList);
        }

        public IActionResult ListCustomers()
        {
            System.Collections.Generic.List<Bayi.DataAccess.Customer> customerList = this._customerService.ListActiveOnes();
            System.Collections.Generic.List<ListCustomerResponse> customerResponseList = new System.Collections.Generic.List<ListCustomerResponse>();
            foreach (Bayi.DataAccess.Customer customer in customerList)
                customerResponseList.Add(new ListCustomerResponse()
                {
                    DealerName = customer.Dealer.AppUser.CompanyName,
                    CompanyName = customer.CompanyName,
                    Address = customer.Address,
                    Authorized = customer.AuthorizedPerson,
                    Email = customer.Email,
                    Phone = customer.Phone
                });
            return (IActionResult)this.View((object)customerResponseList);
        }
    }
}
