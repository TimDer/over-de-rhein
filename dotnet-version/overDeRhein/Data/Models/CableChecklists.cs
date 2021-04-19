using System.ComponentModel.DataAnnotations;

namespace overDeRhein.Data.Models
{
    public class CableChecklists
    {
        [Key]
        public int CableChecklistsID { get; set; }
        public int CableDamage_6D { get; set; }
        public int CableDamage_30D { get; set; }
        public int OutsideCableDamage { get; set; }
        public int Rust { get; set; }
        public int ReducedCableDiameter { get; set; }
        public int MeasuringPoints { get; set; }
        public int TotalDamage { get; set; }
        public int DamageRustType { get; set; }


        // ============================== foreigners ==============================
        public int CoverPagesID { get; set; }
        public CoverPages CoverPage { get; set; }

        // user table
        public int UserID { get; set; }
        public Users Users { get; set; }
    }
}