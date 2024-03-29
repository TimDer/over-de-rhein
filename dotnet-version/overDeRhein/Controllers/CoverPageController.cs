using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using overDeRhein.Data;
using overDeRhein.Data.Models;
using overDeRhein.Models;
using overDeRhein.ViewModels;

namespace overDeRhein.Controllers
{
    [Authorize]
    public class CoverPageController : Controller
    {
        public AppDbContext _AppDbContext { get; set; }
        public CoverPageController(AppDbContext appDbContext)
        {
            _AppDbContext = appDbContext;
        }

        public IActionResult Index()
        {
            CoverPageStatusModel statusModel = new CoverPageStatusModel(_AppDbContext, "Open", HttpContext);

            return View("CoverPage", statusModel.ViewModel);
        }

        public IActionResult StatusClosed()
        {
            CoverPageStatusModel statusModel = new CoverPageStatusModel(_AppDbContext, "Gesloten", HttpContext);

            return View("CoverPage", statusModel.ViewModel);
        }

        public IActionResult Edit(string type, int edit)
        {
            return View("EditAdd", new CoverPageEditAddViewModel(_AppDbContext, type, "edit", edit));
        }

        public IActionResult Add(string type)
        {
            return View("EditAdd", new CoverPageEditAddViewModel(_AppDbContext, type, "add"));
        }
    }
}