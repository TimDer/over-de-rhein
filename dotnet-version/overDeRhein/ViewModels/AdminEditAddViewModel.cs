using System.Collections.Generic;
using overDeRhein.Data.Models;

namespace overDeRhein.ViewModels
{
    public class AdminEditAddViewModel
    {
        #nullable enable
        public int UserID { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? PasswordRepeat { get; set; }
        public int? UserTypeID { get; set; }
        public List<UserType>? UserType { get; set; }
        public string EditAdd { get; set; } = "Add";
        #nullable disable
    }
}