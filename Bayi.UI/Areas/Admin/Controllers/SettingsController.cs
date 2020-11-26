using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bayi.DataAccess;
using Bayi.DTO;
using Bayi.DTO.Admin;
using Bayi.DTO.User;
using Bayi.UI.Controllers;
using Bayi.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Bayi.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin/[controller]/[action]")]
    [Authorize(Roles = "Admin")]
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
            string userId = HttpContext.Session.GetString(SessionKeyManager.Login);
            AppUser appUser = await _userManager.FindByIdAsync(userId);
            UpdateAdminResponse response = new UpdateAdminResponse();
            response.Address = appUser.Address;
            response.CompanyName = appUser.CompanyName;
            response.Email = appUser.Email;
            response.Phone = appUser.PhoneNumber;
            response.AuthorizedPerson = appUser.AuthorizedPerson;
            return View(response);
        }

        [HttpPost]
        public async Task<JsonResult> UpdateAdmin([FromBody] UpdateAdminRequest request)
        {
            BaseResponse response = new BaseResponse();
            string userId = HttpContext.Session.GetString(SessionKeyManager.Login);
            AppUser byIdAsync = await _userManager.FindByIdAsync(userId);
            byIdAsync.Email = request.Email;
            byIdAsync.UserName = request.Email;
            byIdAsync.PhoneNumber = request.Phone;
            byIdAsync.Address = request.Address;
            byIdAsync.CompanyName = request.CompanyName;
            byIdAsync.AuthorizedPerson = request.Authorized;
            var result=await _userManager.UpdateAsync(byIdAsync);
            if (result.Succeeded)
            {
                response.Message = "Bilgiler Başarıyla Değiştirilmiştir..";
                response.Number = 1;
                return Json(response);
            }
            response.Message = "Bu Email Adresi Kayıtlıdır.Lütfen Farklı Bir Email Adresi Giriniz";
            response.Number = 2;
            return Json(response);
        }

        public IActionResult UpdatePassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> UpdateForPassword([FromBody] UpdateAdminPasswordRequest request)
        {
            BaseResponse baseResponse = new BaseResponse();
            string userId = HttpContext.Session.GetString(SessionKeyManager.Login);
            AppUser byIdAsync = await _userManager.FindByIdAsync(userId);
            var result= await _userManager.ChangePasswordAsync(byIdAsync, request.CurrentPassword, request.NewPassword);
            if (result.Succeeded)
            {
                baseResponse.Number = 1;
                baseResponse.Message = "Şifreniz Başarıyle Değiştirilmiştir..";
                return Json(baseResponse);
            }
            baseResponse.Number = 2;
            baseResponse.Message = "Eski Şifrenizi Yanlış Girdiniz..";
            return Json(baseResponse);
        }

        [HttpPost]
        public async Task<JsonResult> UserDetail()
        {
            string userId = HttpContext.Session.GetString(SessionKeyManager.Login);
            AppUser byIdAsync = await _userManager.FindByIdAsync(userId);
            return Json(new UserDetailResponse()
            {
                CompanyName = byIdAsync.AuthorizedPerson
            });
        }

        public IActionResult Exit()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("login", "account");
        }
    }
}
