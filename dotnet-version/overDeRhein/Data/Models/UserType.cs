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


        // ============================== foreigners ==============================
        public List<Users> Users { get; set; }
    }
}