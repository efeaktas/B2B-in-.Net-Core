using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bayi.DataAccess;
using Bayi.DTO;
using Bayi.DTO.Dealer;
using Bayi.DTO.User;
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
    public class SettingsController : BaseController
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<AppRole> _roleManager;

        public SettingsController(
          UserManager<AppUser> userManager,
          SignInManager<AppUser> signInManager,
          RoleManager<AppRole> roleManager)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._roleManager = roleManager;
        }

        public async Task<IActionResult> Update()
        {
            SettingsController settingsController = this;
            string userId = HttpContext.Session.GetString(SessionKeyManager.Login);
            AppUser byIdAsync = await settingsController._userManager.FindByIdAsync(userId);
            return (IActionResult)settingsController.View((object)new ListDealerResponse()
            {
                Address = byIdAsync.Address,
                CompanyName = byIdAsync.CompanyName,
                Email = byIdAsync.Email,
                Phone = byIdAsync.PhoneNumber,
                Authorized = byIdAsync.AuthorizedPerson
            });
        }

        [HttpPost]
        public async Task<JsonResult> UpdateDealer([FromBody] UpdateDealerRequest request)
        {
            SettingsController settingsController = this;
            BaseResponse response = new BaseResponse();
            string userId = HttpContext.Session.GetString(SessionKeyManager.Login);
            AppUser byIdAsync = await settingsController._userManager.FindByIdAsync(userId);
            byIdAsync.Email = request.Email;
            byIdAsync.UserName = request.Email;
            byIdAsync.PhoneNumber = request.Phone;
            byIdAsync.Address = request.Address;
            byIdAsync.CompanyName = request.CompanyName;
            byIdAsync.AuthorizedPerson = request.Authorized;
            if ((await settingsController._userManager.UpdateAsync(byIdAsync)).Succeeded)
            {
                response.Message = "Bilgiler Başarıyla Değiştirilmiştir..";
                response.Number = 1;
                return settingsController.Json((object)response);
            }
            response.Message = "Bu Email Adresi Kayıtlıdır.Lütfen Farklı Bir Email Adresi Giriniz";
            response.Number = 2;
            return settingsController.Json((object)response);
        }

        public IActionResult UpdatePassword() => (IActionResult)this.View();

        [HttpPost]
        public async Task<JsonResult> UpdatePassword([FromBody] UpdateDealerPasswordRequest request)
        {
            SettingsController settingsController = this;
            BaseResponse baseResponse = new BaseResponse();
            string userId = HttpContext.Session.GetString(SessionKeyManager.Login);
            AppUser byIdAsync = await settingsController._userManager.FindByIdAsync(userId);
            if ((await settingsController._userManager.ChangePasswordAsync(byIdAsync, request.CurrentPassword, request.NewPassword)).Succeeded)
            {
                baseResponse.Number = 1;
                baseResponse.Message = "Şifreniz Başarıyle Değiştirilmiştir..";
                return settingsController.Json((object)baseResponse);
            }
            baseResponse.Number = 2;
            baseResponse.Message = "Eski Şifrenizi Yanlış Girdiniz..";
            return settingsController.Json((object)baseResponse);
        }

        [HttpPost]
        public async Task<JsonResult> UserDetail()
        {
            SettingsController settingsController = this;
            string userId = HttpContext.Session.GetString(SessionKeyManager.Login);
            AppUser byIdAsync = await settingsController._userManager.FindByIdAsync(userId);
            return settingsController.Json((object)new UserDetailResponse()
            {
                CompanyName = byIdAsync.AuthorizedPerson
            });
        }

        public IActionResult Exit()
        {
            HttpContext.Session.Clear();
            return (IActionResult)((ControllerBase)this).RedirectToAction("login", "account");
        }
    }
}
