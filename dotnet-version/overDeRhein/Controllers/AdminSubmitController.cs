using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using overDeRhein.Classes;
using overDeRhein.Data;
using overDeRhein.Data.Models;
using overDeRhein.ViewModels;

namespace overDeRhein.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminSubmitController : Controller
    {
        public AppDbContext AppDbContext { get; set; }
        public Cryptography Cryptography { get; set; }
        public AdminSubmitController(AppDbContext appDbContext, Cryptography cryptography)
        {
            this.AppDbContext = appDbContext;
            this.Cryptography = cryptography;
        }

        public IActionResult Add([FromForm] AdminEditAddViewModel data)
        {
            bool ifHasError = false;
            if (
                (data.Password != null && data.PasswordRepeat != null) &&
                (data.UserName != null) &&
                (Cryptography.CreateHash(data.Password) == Cryptography.CreateHash(data.PasswordRepeat))
            )
            {
                Users user = new Users
                {
                    UserName = data.UserName,
                    Password = Cryptography.CreateHash(data.Password),
                    UserTypeID = data.UserTypeID
                };
                AppDbContext.Users.Add(user);
                AppDbContext.SaveChanges();
            }
            else if (
                (data.Password != null && data.PasswordRepeat != null) ||
                (data.UserName == null)
            )
            {
                ifHasError = true;
            }

            return (ifHasError) ? RedirectToAction("AdminError", "Home") : RedirectToAction("Index", "Admin");
        }

        public IActionResult Edit([FromForm] AdminEditAddViewModel data)
        {
            Users dataFromDb = AppDbContext.Users
                                .Where(u => u.UserID == data.UserID)
                                .FirstOrDefault();
            
            bool ifHasError = false;
            if (dataFromDb is Users) {
                if (
                    (data.Password != null && data.PasswordRepeat != null) &&
                    (Cryptography.CreateHash(data.Password) == Cryptography.CreateHash(data.PasswordRepeat))
                )
                {
                    dataFromDb.Password = Cryptography.CreateHash(data.Password);
                }
                else if (data.Password != null && data.PasswordRepeat != null)
                {
                    ifHasError = true;
                }

                if (data.UserName != null)
                {
                    dataFromDb.UserName = data.UserName;
                }
                else {
                    ifHasError = true;
                }
                dataFromDb.UserTypeID = data.UserTypeID;

                AppDbContext.SaveChanges();
            }
            else
            {
                ifHasError = true;
            }

            return (ifHasError) ? RedirectToAction("AdminError", "Home") : RedirectToAction("Index", "Admin");
        }

        public IActionResult Delete(int type)
        {
            int userId = type;

            int currentUser = int.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);

            Users user = AppDbContext.Users.Where(u => u.UserID == userId).FirstOrDefault();

            bool ifHasError = false;
            if (user is Users && currentUser != userId)
            {
                AppDbContext.Users.Remove(user);
                AppDbContext.SaveChanges();
            }
            else
            {
                ifHasError = true;
            }

            return (ifHasError) ? RedirectToAction("AdminError", "Home") : RedirectToAction("Index", "Admin");
        }
    }
}