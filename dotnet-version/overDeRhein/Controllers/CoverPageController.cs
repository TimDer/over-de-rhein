using System.Collections.Generic;
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
            CoverPageStatusModel statusModel = new CoverPageStatusModel(_AppDbContext, "Open");

            return View("CoverPage", statusModel.ViewModel);
        }

        public IActionResult StatusClosed()
        {
            CoverPageStatusModel statusModel = new CoverPageStatusModel(_AppDbContext, "Gesloten");

            return View("CoverPage", statusModel.ViewModel);
        }

        public IActionResult Edit(int id1, string id2)
        {
            //int edit, string type
            int edit = id1;
            string type = id2;

            return View("EditAdd");
        }

        public IActionResult Add()
        {
            return View("EditAdd");
        }
    }
}