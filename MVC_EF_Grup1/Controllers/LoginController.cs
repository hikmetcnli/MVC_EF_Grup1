using System.Runtime.InteropServices;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using MVC_EF_Grup1.Models;

namespace MVC_EF_Grup1.Controllers
{
    public class LoginController : Controller
    {
        Context c = new Context();
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(User user)
        {

            var BULUNANUSER = c.Users_.FirstOrDefault(x =>
            x.Username == user.Username && x.Password == user.Password
            );

            if (BULUNANUSER != null) //yani kullanıcı varsa
            {
                var claim = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,BULUNANUSER.Username),
                    new Claim(ClaimTypes.Role,BULUNANUSER.Role)
                };

                var claimidentity = new ClaimsIdentity(claim, CookieAuthenticationDefaults.AuthenticationScheme);
                var claimproperties = new AuthenticationProperties();

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimidentity), claimproperties);

                 
                return RedirectToAction("Liste", "SatinAlma");
            }
            else //Kullanıcı Adı veya Şifre Hatalı
            {
                ViewBag.Mesaj = "Hatalı Kullanıcı veya Şifre";
                return View();
            }



        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Login");
        }
    }
}
