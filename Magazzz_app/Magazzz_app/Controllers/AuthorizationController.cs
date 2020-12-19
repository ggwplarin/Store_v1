using Magazzz_app.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace Magazzz_app.Controllers
{
    public class AuthorizationController : Controller
    {
        private AccountContext db;

        public AuthorizationController(AccountContext context)
        {
            db = context;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Account account)
        {
            if (ModelState.IsValid)
            {
                if (await db.Accounts.FirstOrDefaultAsync(a=>a.account_email==account.account_email)==null)
                {
                    db.Accounts.Add(account);
                    await db.SaveChangesAsync();
                    await Authenticate(account.account_email);
                    
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return Content($"Такой пользователь уже существует");
                }
                
            }
            else
                return View(account);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogIn(Account account)
        {
            
            if (ModelState.IsValid)
            {
                if (await db.Accounts.FirstOrDefaultAsync(a => a.account_email == account.account_email) != null)
                {
                    await Authenticate(account.account_email);
                    
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return Content($"Такой пользователь уже существует");
                }

            }
            else
                return View(account);
        }
        
        public IActionResult SignIn()
        { 
            return View();
        }
        
        public IActionResult SignUp()
        {
            return View();
        }

        public async Task<IActionResult> SignOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        private async Task Authenticate(string userName)
        {
            // создаем один claim
            var claims = new List<Claim>
    {
        new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
    };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
    }
}