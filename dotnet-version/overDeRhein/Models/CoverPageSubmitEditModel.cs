using System.Linq;
using Microsoft.EntityFrameworkCore;
using overDeRhein.Data;
using overDeRhein.Data.Models;

namespace overDeRhein.Models
{
    public class CoverPageSubmitEditModel
    {
        public string Type { get; set; }
        public string subTable { get; set; }
        public AppDbContext AppDbContext { get; set; }
        public CoverPages CoverPagesDb { get; set; }
        public CoverPages CoverPages { get; set; }
        public LiftingTests LiftingTests { get; set; }
        public CableChecklists CableChecklists { get; set; }
        public int OldUserId { get; set; }
        public int CoverPageTypeId { get; set; }

        public CoverPageSubmitEditModel(
            string type,
            AppDbContext appDbContext,
            CoverPages coverPages,
            LiftingTests liftingTests,
            CableChecklists cableChecklists
        )
        {
            Type            = type;
            AppDbContext    = appDbContext;
            CoverPages      = coverPages;
            LiftingTests    = liftingTests;
            CableChecklists = cableChecklists;
        }

        public void GetData()
        {
            string subTable = (Type == "Hijs-testen") ? nameof(CoverPages.LiftingTests) : nameof(CoverPages.CableChecklists);

            CoverPagesDb = AppDbContext.CoverPages
                .Include(subTable)
                .Where(c => c.CoverPagesID == CoverPages.CoverPagesID)
                .FirstOrDefault();
        }

        public void UpdateData()
        {
            if (CoverPagesDb is CoverPages)
            {
                OldUserId       = CoverPagesDb.UserID;
                CoverPageTypeId = CoverPagesDb.CoverPageTypeID;

                this.UpdateCoverPage();

                if (Type == "Hijs-testen")
                {
                    this.UpdateLiftingTests();
                }
                else
                {
                    this.UpdateCableChecklists();
                }

                AppDbContext.SaveChanges();
            }
        }

        private void UpdateCoverPage()
        {
            CoverPagesDb.TCVTNumber                 = CoverPages.TCVTNumber;
            CoverPagesDb.InspectionDate             = CoverPages.InspectionDate;
            CoverPagesDb.Executor                   = CoverPages.Executor;
            CoverPagesDb.Specialist                 = CoverPages.Specialist;
            CoverPagesDb.CrainSetup                 = CoverPages.CrainSetup;
            CoverPagesDb.ExecutionTowerHookHeight   = CoverPages.ExecutionTowerHookHeight;
            CoverPagesDb.BoomType                   = CoverPages.BoomType;
            CoverPagesDb.TelescopicBoomParts        = CoverPages.TelescopicBoomParts;
            CoverPagesDb.ConstructionBoomMeters     = CoverPages.ConstructionBoomMeters;
            CoverPagesDb.JibBoomMeters              = CoverPages.JibBoomMeters;
            CoverPagesDb.FlyJibParts                = CoverPages.FlyJibParts;
            CoverPagesDb.BoomLength                 = CoverPages.BoomLength;
            CoverPagesDb.Topable                    = CoverPages.Topable;
            CoverPagesDb.Trolley                    = CoverPages.Trolley;
            CoverPagesDb.AdjustableBoom             = CoverPages.AdjustableBoom;
            CoverPagesDb.TCVTNumber                 = CoverPages.StampsType;
            CoverPagesDb.Shortcomings               = CoverPages.Shortcomings;
            CoverPagesDb.SignOutBefore              = CoverPages.SignOutBefore;
            CoverPagesDb.Elucidation                = CoverPages.Elucidation;
            CoverPagesDb.WorkInstruction            = CoverPages.WorkInstruction;
            CoverPagesDb.CableSupplier              = CoverPages.CableSupplier;
            CoverPagesDb.Observations               = CoverPages.Observations;
            CoverPagesDb.OperatingHours             = CoverPages.OperatingHours;
            CoverPagesDb.DiscardReason              = CoverPages.DiscardReason;
            CoverPagesDb.CoverPageStatusID          = CoverPages.CoverPageStatusID;
        }

        private void UpdateLiftingTests()
        {
            CoverPagesDb.LiftingTests.DateDrawn                 = LiftingTests.DateDrawn;
            CoverPagesDb.LiftingTests.MainBoomLength            = LiftingTests.MainBoomLength;
            CoverPagesDb.LiftingTests.MechSectionBoomLength     = LiftingTests.MechSectionBoomLength;
            CoverPagesDb.LiftingTests.AuxiliaryBoomLength       = LiftingTests.AuxiliaryBoomLength;
            CoverPagesDb.LiftingTests.JibBoomLength             = LiftingTests.JibBoomLength;
            CoverPagesDb.LiftingTests.HoistingCablePartsAmount  = LiftingTests.HoistingCablePartsAmount;
            CoverPagesDb.LiftingTests.SwingAngle                = LiftingTests.SwingAngle;
            CoverPagesDb.LiftingTests.OwnMassBallast            = LiftingTests.OwnMassBallast;
            CoverPagesDb.LiftingTests.PermissibleOperatingLoad  = LiftingTests.PermissibleOperatingLoad;
            CoverPagesDb.LiftingTests.LbmInEffect               = LiftingTests.LbmInEffect;
            CoverPagesDb.LiftingTests.TestLoad                  = LiftingTests.TestLoad;
            CoverPagesDb.LiftingTests.Agreed                    = LiftingTests.Agreed;
        }

        private void UpdateCableChecklists()
        {
            CoverPagesDb.CableChecklists.CableDamage_6D         = CableChecklists.CableDamage_6D;
            CoverPagesDb.CableChecklists.CableDamage_30D        = CableChecklists.CableDamage_30D;
            CoverPagesDb.CableChecklists.OutsideCableDamage     = CableChecklists.OutsideCableDamage;
            CoverPagesDb.CableChecklists.Rust                   = CableChecklists.Rust;
            CoverPagesDb.CableChecklists.ReducedCableDiameter   = CableChecklists.ReducedCableDiameter;
            CoverPagesDb.CableChecklists.MeasuringPoints        = CableChecklists.MeasuringPoints;
            CoverPagesDb.CableChecklists.TotalDamage            = CableChecklists.TotalDamage;
            CoverPagesDb.CableChecklists.DamageRustType         = CableChecklists.DamageRustType;
        }
    }
}