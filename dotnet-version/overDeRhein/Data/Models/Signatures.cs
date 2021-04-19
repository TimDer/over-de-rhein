using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace overDeRhein.Data.Models
{
    public class Signatures
    {
        [Key]
        public int SignaturesID { get; set; }
        [StringLength(100)]
        public string Signature { get; set; }


        // ============================== foreigners ==============================
        public List<CoverPages> CoverPages { get; set; }
    }
}