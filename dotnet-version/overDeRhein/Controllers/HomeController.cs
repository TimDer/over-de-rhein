using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace overDeRhein.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public IActionResult Index() {
            return Redirect("/CoverPage");
        }
    }
}