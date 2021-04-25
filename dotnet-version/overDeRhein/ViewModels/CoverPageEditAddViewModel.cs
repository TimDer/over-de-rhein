using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using overDeRhein.Data;
using overDeRhein.Data.Models;

namespace overDeRhein.ViewModels
{
    public class CoverPageEditAddViewModel
    {
        public CoverPages CoverPage { get; set; }
        public string Type { get; set; }
        public string AddOrEdit { get; set; }
        public List<CoverPageStatus> CoverPageStatus { get; set; }
        private AppDbContext _AppDbContext { get; set; }

        public string Topable { get; set; }
        public string Trolley { get; set; }
        public string AdjustableBoom { get; set; }
        public string Shortcomings_yes { get; set; }
        public string Shortcomings_no { get; set; }
        public string InspectionDate { get; set; }
        public string SignOutBefore { get; set; }
        public string AgreedHijsTesten { get; set; }

        public CoverPageEditAddViewModel(AppDbContext appDbContext, string type, string addOrEdit, int edit = 0)
        {
            _AppDbContext = appDbContext;
            Type = type;
            AddOrEdit = addOrEdit;

            if (type == "Hijs-testen" && addOrEdit == "edit") {
                CoverPage = _AppDbContext.CoverPages
                    .Include(c => c.LiftingTests)
                    .Where(c => c.CoverPagesID == edit)
                    .FirstOrDefault<CoverPages>();
            }
            else if (type == "Kabel-check-lijst" && addOrEdit == "edit") {
                CoverPage = _AppDbContext.CoverPages
                    .Include(c => c.CableChecklists)
                    .Where(c => c.CoverPagesID == edit)
                    .FirstOrDefault<CoverPages>();
            }
            else {
                CoverPage = new CoverPages
                {
                    InspectionDate = DateTime.UtcNow,
                    SignOutBefore = DateTime.UtcNow,
                    LiftingTests = new LiftingTests
                    {
                        DateDrawn = DateTime.UtcNow,
                        Agreed = 0
                    },
                    CableChecklists = new CableChecklists
                    {
                        CableDamage_6D = 0
                    }
                };
            }
            
            this.init(type);
        }

        public void init(string type)
        {
            CoverPageStatus = _AppDbContext.CoverPageStatus.ToList<CoverPageStatus>();

            Topable         = (CoverPage.Topable == 1) ? "checked" : "";
            Trolley         = (CoverPage.Trolley == 1) ? "checked" : "";
            AdjustableBoom  = (CoverPage.AdjustableBoom == 1) ? "checked" : "";

            Shortcomings_yes = (CoverPage.Shortcomings == 1) ? "checked" : "";
            Shortcomings_no  = (CoverPage.Shortcomings == 0) ? "checked" : "";

            InspectionDate  = CoverPage.InspectionDate.Date.ToString("yyyy-MM-dd");

            SignOutBefore   = CoverPage.SignOutBefore.Date.ToString("yyyy-MM-dd");

            if (type == "Hijs-testen") {
                AgreedHijsTesten = (CoverPage.LiftingTests.Agreed == 1) ? "checked" : "";
            }
        }
    }
}