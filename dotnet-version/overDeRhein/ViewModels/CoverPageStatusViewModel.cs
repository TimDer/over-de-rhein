using System.Collections.Generic;
using overDeRhein.Data.Models;

namespace overDeRhein.ViewModels
{
    public class CoverPageStatusViewModel
    {
        public List<CoverPages> CoverPages { get; set; }
        public List<CoverPageType> CoverPageType { get; set; }
        public bool IsAdmin { get; set; }
    }
}