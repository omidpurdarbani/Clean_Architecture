using Application.Interfaces;
using Application.ViewModels;
using Domain.Models;
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
                    Password = register.Password.Trim()
                };
                _userService.RegisterUser(user);
                return View("Success",register);
            }
            else
            {
                ViewBag.CheckError = new { Email = checkEmail , UserName=checkUserName };
                return View(register);
            }

        }
    }
}
