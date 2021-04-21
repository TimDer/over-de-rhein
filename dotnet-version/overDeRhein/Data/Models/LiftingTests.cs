using System;
using System.ComponentModel.DataAnnotations;

namespace overDeRhein.Data.Models
{
    public class LiftingTests
    {
        [Key]
        public int LiftingTestsID { get; set; }
        public DateTime DateDrawn { get; set; }
        public int MainBoomLength { get; set; }
        public int MechSectionBoomLength { get; set; }
        public double AuxiliaryBoomLength { get; set; }
        public int JibBoomLength { get; set; }
        public int HoistingCablePartsAmount { get; set; }
        public int SwingAngle { get; set; }
        public int OwnMassBallast { get; set; }
        public double PermissibleOperatingLoad { get; set; }
        public double LbmInEffect { get; set; }
        public double TestLoad { get; set; }
        public byte Agreed { get; set; }


        // ============================== foreigners ==============================
        // CoverPages table
        public int CoverPagesID { get; set; }
        public CoverPages CoverPage { get; set; }

        // user table
        public int UserID { get; set; }
        public Users Users { get; set; }
    }
}