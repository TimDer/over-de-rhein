using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace overDeRhein.Data.Models
{
    public class CoverPageType
    {
        [Key]
        public int CoverPageTypeID { get; set; }
        [StringLength(50)]
        public string Type { get; set; }

        // ============================== foreigners ==============================
        #nullable enable
        public List<CoverPages>? CoverPages { get; set; }
        #nullable disable
    }
}