using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bayi.Business.IService;
using Bayi.DataAccess;
using Bayi.DTO;
using Bayi.DTO.User;
using Bayi.Utilities;
using Bayi.Utilities.EmailSending;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;

namespace Bayi.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IEmailSender _emailSender;
        private readonly IErrorService _errorService;
        public AccountController(
          UserManager<AppUser> userManager,
          IEmailSender emailSender,
          SignInManager<AppUser> signInManager,
          RoleManager<AppRole> roleManager,IErrorService errorService)
        {
            this._userManager = userManager;
            this._emailSender = emailSender;
            this._signInManager = signInManager;
            this._roleManager = roleManager;
            this._errorService = errorService;
        }

        [AllowAnonymous]
        [Route("")]
        public IActionResult Login()
        {
        
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<JsonResult> UserLogin([FromBody] UserLoginRequest request)
        {

            var result = await _signInManager.PasswordSignInAsync(request.Username, request.Password, false, false);
            AppUser user = await _userManager.FindByNameAsync(request.Username);
            BaseResponse baseResponse = new BaseResponse();

            if (result.Succeeded && await _userManager.IsEmailConfirmedAsync(user))
            {
                List<string> rolesAsync = await _userManager.GetRolesAsync(user) as List<string>;
                if (rolesAsync.Contains("Admin"))
                {
                    baseResponse.Number = 1;
                    HttpContext.Session.SetString(SessionKeyManager.Login, user.Id.ToString());
                    return Json(baseResponse);
                }
                if (rolesAsync.Contains("Bayi"))
                {
                    baseResponse.Number = 2;
                    HttpContext.Session.SetString(SessionKeyManager.Login, user.Id.ToString());
                    return Json(baseResponse);
                }
            }
            baseResponse.Number = 3;
            baseResponse.Message = "Hatalı giriş yaptınız lütfen tekrar deneyiniz..";
            return Json(baseResponse);
        }

        [AllowAnonymous]
        public IActionResult Forgot()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<JsonResult> ForgotPassword([FromBody] ForgotPasswordRequest request)
        {
            BaseResponse response = new BaseResponse();
            AppUser user = await _userManager.FindByEmailAsync(request.Email);
            bool result = await _userManager.IsEmailConfirmedAsync(user);
            if (user != null && result == true)
            {
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                token = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(token));
                string content = string.Format("https://panel.biotec-tr.com/Account/Reset?email={0}&token={1}", user.Email, token);
                Message message = new Message(new string[] { user.Email }, "Şifre Yenileme Talebi", content);
                _emailSender.SendEmail(message);
                response.Number = 1;
                response.Message = "Email adresinize şifrenizi yenilemek için gerekli link adresi gönderilmiştir.Link'e tıklayarak yeni şifrenizi belirleyebilirsiniz..";
                return Json(response);
            }
            response.Number = 2;
            response.Message = "Geçersiz email adresi girdiniz..";
            return Json(response);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Reset(string email, string token)
        {
            token = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(token));
            if (email == null && token == null)
            {
                throw new Exception();
            }
            TempData["Email"] = email;
            TempData["Token"] = token;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<JsonResult> ResetPassword([FromBody] ResetPasswordRequest request)
        {
            BaseResponse response = new BaseResponse();
            AppUser user = await _userManager.FindByEmailAsync(request.Email);
            if (user != null)
            {
                IdentityResult identityResult = await _userManager.ResetPasswordAsync(user, request.Token, request.Password);
                if (identityResult.Succeeded)
                {
                    response.Number = 1;
                    response.Message = "Şifre Başarılı Bir Şekilde Değiştirilmiştir";
                    return Json(response);
                }
                identityResult.Errors.ToList<IdentityError>();
            }
            response.Number = 2;
            response.Message = "Geçersiz Email ve Token Bilgisi";
            return Json(response);
        }

        public IActionResult Error()
        {
            var errorInfo = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            Error error = new Error();
            error.Username = HttpContext.User.Identity.Name;
            error.Path = errorInfo.Path;
            error.Message = errorInfo.Error.Message;
            error.Information = errorInfo.Error.StackTrace;
            _errorService.Add(error);
            return RedirectToAction("login", "account");

        }

        [Route("ErrorPage/{statusCode}")]
        public IActionResult ErrorPage(int statusCode)
        {
            if (statusCode == 404)
            {
                ViewBag.Code = 404;
                ViewBag.Message = "ARADIĞINIZ SAYFA BULUNAMADI";
            }
            return View();
        }
    }
}
