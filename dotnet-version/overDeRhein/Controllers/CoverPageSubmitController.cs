using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using overDeRhein.Data;
using overDeRhein.Data.Models;
using overDeRhein.Models;

namespace overDeRhein.Controllers
{
    [Authorize]
    public class CoverPageSubmitController : Controller
    {
        public AppDbContext _AppDbContext { get; set; }
        public CoverPageSubmitController(AppDbContext appDbContext)
        {
            _AppDbContext = appDbContext;
        }

        [HttpPost]
        public IActionResult Edit(
            string type,
            [FromForm] CoverPages coverPage,
            [FromForm] LiftingTests liftingTests,
            [FromForm] CableChecklists cableChecklists
        )
        {
            CoverPageSubmitEditModel coverPageSubmitEditModel = new CoverPageSubmitEditModel(
                type,
                _AppDbContext,
                coverPage,
                liftingTests,
                cableChecklists
            );
            coverPageSubmitEditModel.GetData();
            coverPageSubmitEditModel.UpdateData();

            /*string subTable = (type == "Hijs-testen") ? nameof(CoverPage.LiftingTests) : nameof(CoverPage.CableChecklists);

            CoverPages coverPageOld = _AppDbContext.CoverPages
                .Include(subTable)
                .Where(c => c.CoverPagesID == CoverPage.CoverPagesID)
                .FirstOrDefault();

            if (coverPageOld is CoverPages)
            {
                int oldUserId       = coverPageOld.UserID;
                int CoverPageTypeID = coverPageOld.CoverPageTypeID;

                if (type == "Hijs-testen")
                {}
            }*/

            return RedirectToAction("Index", "CoverPage");
        }

        [HttpPost]
        public IActionResult Add(
            string type,
            [FromForm] CoverPages coverPage,
            [FromForm] LiftingTests liftingTests,
            [FromForm] CableChecklists cableChecklists
        )
        {
            int userId = int.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);

            if (type == "Hijs-testen")
            {
                coverPage.CoverPageTypeID = 1;
                liftingTests.UserID = userId;
                coverPage.LiftingTests = liftingTests;
            }
            else
            {
                coverPage.CoverPageTypeID = 2;
                cableChecklists.UserID = userId;
                coverPage.CableChecklists = cableChecklists;
            }

            coverPage.UserID = userId;

            _AppDbContext.CoverPages.Add(coverPage);

            _AppDbContext.SaveChanges();

            return RedirectToAction("Index", "CoverPage");
        }
    }
}