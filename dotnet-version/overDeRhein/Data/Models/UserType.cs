using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace overDeRhein.Data.Models
{
    public class UserType
    {
        [Key]
        public int UserTypeID { get; set; }
        [StringLength(50)]
        public string Type { get; set; }
        public byte Role { get; set; }


        // ============================== foreigners ==============================
        #nullable enable
        public List<Users>? Users { get; set; }
        #nullable disable
    }
}