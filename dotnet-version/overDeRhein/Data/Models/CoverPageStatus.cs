using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace overDeRhein.Data.Models
{
    public class CoverPageStatus
    {
        [Key]
        public int CoverPageStatusID { get; set; }
        [StringLength(50)]
        public string StatusType { get; set; }


        // ============================== foreigners ==============================
        public List<CoverPages> CoverPages { get; set; }
    }
}