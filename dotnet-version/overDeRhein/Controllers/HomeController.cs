using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace overDeRhein.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public IActionResult Index() {
            return View();
        }
    }
}