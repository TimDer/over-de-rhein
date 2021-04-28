using System.Linq;
using Microsoft.EntityFrameworkCore;
using overDeRhein.Data;
using overDeRhein.Data.Models;
using overDeRhein.ViewModels;

namespace overDeRhein.Models
{
    public class CoverPageStatusModel
    {
        public AppDbContext _AppDbContext { get; set; }
        public CoverPageStatusViewModel ViewModel { get; set; }
        public CoverPageStatusModel(AppDbContext appDbContext, string statusType)
        {
            _AppDbContext = appDbContext;

            ViewModel = new CoverPageStatusViewModel
            {
                CoverPages = _AppDbContext.CoverPages
                    .Include(c => c.CoverPageStatus)
                    .Include(c => c.CableChecklists)
                    .Include(c => c.LiftingTests)
                    .Include(c => c.CoverPageStatus)
                    .Include(c => c.CoverPageType)
                    .Where(c => c.CoverPageStatus.StatusType == statusType)
                    .OrderByDescending(c => c.CoverPagesID)
                    .ToList<CoverPages>(),
                CoverPageType = _AppDbContext.CoverPageType.ToList<CoverPageType>()
            };
        }
    }
}