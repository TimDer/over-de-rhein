using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace overDeRhein.Data.Models
{
    public class Users
    {
        [Key]
        public int UserID { get; set; }
        [StringLength(100)]
        public string UserName { get; set; }
        [StringLength(128)]
        public string Password { get; set; }


        // ============================== foreigners ==============================
        public int UserTypeID { get; set; }
        public UserType UserType { get; set; }
        public List<CoverPages> CoverPages { get; set; }
    }
}