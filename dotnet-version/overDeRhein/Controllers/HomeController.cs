using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using overDeRhein.ViewModels;

namespace overDeRhein.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public IActionResult Index() {
            return Redirect("/CoverPage");
        }

        public IActionResult Error()
        {
            return View(new HomeErrorViewModel
            {
                Controller = "CoverPage",
                Action = "Index"
            });
        }

        [Authorize(Roles = "Admin")]
        public IActionResult AdminError()
        {
            return View("Error", new HomeErrorViewModel
            {
                Controller = "Admin",
                Action = "Index"
            });
        }
    }
}