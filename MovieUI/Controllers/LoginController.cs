using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Movie.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MovieUI.Controllers
{
    public class LoginController : Controller
    {
        public readonly IUserService _userService;
        public LoginController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string UserName,string Password)
        {
            var user = _userService.Get(a => a.UserId == UserName && a.Password == Password);
            if(user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,UserName)
                };
                var useridentity = new ClaimsIdentity(claims, "Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(principal);

                return RedirectToAction("Index", "Home");
            }
            {
                return RedirectToAction("Index");
            }
           
        }


        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Login");
        }
    }
}
