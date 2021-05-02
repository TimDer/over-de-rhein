using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using overDeRhein.Data;
using overDeRhein.Data.Models;
using overDeRhein.ViewModels;

namespace overDeRhein.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        public AppDbContext AppDbContext { get; set; }

        public AdminController(AppDbContext appDbContext)
        {
            this.AppDbContext = appDbContext;
        }

        public IActionResult Index()
        {
            return View(new AdminIndexViewModel
            {
                Users = AppDbContext.Users
                        .Include(u => u.UserType)
                        .OrderByDescending(u => u.UserID)
                        .ToList<Users>()
            });
        }

        public IActionResult Edit(int type)
        {
            int userID = type;
            Users users = AppDbContext.Users
                            .Include(u => u.UserType)
                            .Where(u => u.UserID == userID)
                            .FirstOrDefault();

            return View("AddEdit", new AdminEditAddViewModel
            {
                UserID = users.UserID,
                UserName = users.UserName,
                UserTypeID = users.UserTypeID,
                UserType = AppDbContext.UserType.ToList<UserType>(),
                EditAdd = "Edit"
            });
        }

        public IActionResult Add()
        {
            return View("AddEdit", new AdminEditAddViewModel
            {
                UserType = AppDbContext.UserType.ToList<UserType>()
            });
        }
    }
}