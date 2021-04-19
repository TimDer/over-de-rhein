using System;
using System.ComponentModel.DataAnnotations;

namespace overDeRhein.Data.Models
{
    public class CoverPages
    {
        [Key]
        public int CoverPagesID { get; set; }
        public int TCVTNumber { get; set; }
        public DateTime InspectionDate { get; set; }
        [StringLength(50)]
        public string Executor { get; set; }
        [StringLength(50)]
        public string Specialist { get; set; }
        [StringLength(52)]
        public string CrainSetup { get; set; }
        public int ExecutionTowerHookHeight { get; set; }
        [StringLength(13)]
        public string BoomType { get; set; }
        public double TelescopicBoomParts { get; set; }
        public double ConstructionBoomMeters { get; set; }
        public double JibBoomMeters { get; set; }
        public int FlyJibParts { get; set; }
        public double BoomLength { get; set; }
        public double Topable { get; set; }
        public byte Trolley { get; set; }
        public byte AdjustableBoom { get; set; }
        public int StampsType { get; set; }
        public byte Shortcomings { get; set; }
        public DateTime SignOutBefore { get; set; }
        [StringLength(250)]
        public string Elucidation { get; set; }
        [StringLength(500)]
        public string WorkInstruction { get; set; }
        [StringLength(250)]
        public string CableSupplier { get; set; }
        [StringLength(500)]
        public string Observations { get; set; }
        public int OperatingHours { get; set; }
        [StringLength(500)]
        public int DiscardReason { get; set; }


        // ============================== foreigners ==============================
        public int UserID { get; set; }
        public Users User { get; set; }
        public int CoverPageStatusID { get; set; }
        public CoverPageStatus CoverPageStatus { get; set; }
        public int SignatureID { get; set; }
        public Signatures Signatures { get; set; }
    }
}