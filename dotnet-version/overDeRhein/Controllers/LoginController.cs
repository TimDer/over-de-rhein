using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using overDeRhein.Classes;
using overDeRhein.Data;
using overDeRhein.Models;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace overDeRhein.Controllers
{
    public class LoginController : Controller
    {
        public AppDbContext _AppDbContext { get; set; }
        public Cryptography _Cryptography { get; set; }

        public LoginController(AppDbContext appDbContext, Cryptography cryptography)
        {
            _AppDbContext = appDbContext;
            _Cryptography = cryptography;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult set([FromForm] Login formData)
        {
            var query = _AppDbContext.Users
                .Include(users => users.UserType)
                .Where(user => user.UserName == formData.UserName)
                .FirstOrDefault();

            if (query != null)
            {
                // login
                if (query.Password == _Cryptography.CreateHash(formData.Password))
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, query.UserName)
                    };

                    var claimsIdentity = new ClaimsIdentity(
                        claims,
                        CookieAuthenticationDefaults.AuthenticationScheme);
                    
                    var authProp = new AuthenticationProperties();

                    HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity),
                        authProp);

                    return Redirect("/");
                }
                else {
                    return RedirectToAction("Index");
                }
            }
            else {
                return RedirectToAction("Index");
            }
        }

        [Authorize]
        public IActionResult logout()
        {
            HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index");
        }
    }
}