using System.Security.Claims;
using Application.Interfaces;
using Application.Security;
using Application.ViewModels;
using Domain.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace Web.Mvc.Controllers
{
    public class AccountController : Controller
    {
        private IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        #region Register

        [Route("Register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [Route("Register")]
        public IActionResult Register(RegisterViewModel register)
        {
            if (!ModelState.IsValid)
                return View(register);

            var checkEmail = _userService.CheckEmail(register.Email);
            var checkUserName = _userService.CheckUserName(register.UserName);

            if (checkEmail == CheckUser.Ok && checkUserName == CheckUser.Ok)
            {
                //User
                User user = new User()
                {
                    Email = register.Email.Trim().ToLower(),
                    UserName = register.UserName,
                    Password = SecretHasher.Hash(register.Password.Trim())
                };
                _userService.RegisterUser(user);
                return View("Success", register);
            }
            else
            {
                ViewBag.CheckError = new { Email = checkEmail, UserName = checkUserName };
                return View(register);
            }

        }

        #endregion

        #region Login

        [Route("Login")]
        public IActionResult Login(string ReturnUrl = "/")
        {
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(LoginViewModel login, string ReturnUrl="/")
        {
            if (!ModelState.IsValid)
                return View(login);

            if (!_userService.IsExistUser(login.Email,login.Password))
            {
                ModelState.AddModelError("Email","User Not Found ...");
                return View(login);
            }

            #region Login User

            var user = _userService.GetUserByEmail(login.Email);

            var claims = new List<Claim>
            {
                new (ClaimTypes.Name,user.UserName),
                new (ClaimTypes.NameIdentifier,user.Email)
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var principal = new ClaimsPrincipal(identity);

            var properties = new AuthenticationProperties()
            {
                IsPersistent = login.RememberMe
            };

            HttpContext.SignInAsync(principal, properties);

            #endregion

            return Redirect(ReturnUrl);
        }

        #endregion

        #region Logout

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        #endregion
    }
}
