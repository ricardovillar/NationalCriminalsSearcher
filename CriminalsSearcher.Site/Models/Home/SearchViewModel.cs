
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CriminalsSearcher.Site.Models {
    public class SearchViewModel {

        [MaxLength(250)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Range(0, int.MaxValue)]
        [Display(Name = "Minimum Age (years)")]        
        public int? MinimumAge { get; set; }

        [Range(0, int.MaxValue)]
        [Display(Name = "Maximum Age (years)")]
        public int? MaximumAge { get; set; }

        [MaxLength(1)]
        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [Range(0, int.MaxValue)]
        [Display(Name = "Minimum Height (inches)")]
        public int? MinimumHeight { get; set; }

        [Range(0, int.MaxValue)]
        [Display(Name = "Maximum Height (inches)")]
        public int? MaximumHeight { get; set; }

        [Range(0, int.MaxValue)]
        [Display(Name = "Minimum Weight (pounds)")]
        public int? MinimumWeight { get; set; }

        [Range(0, int.MaxValue)]
        [Display(Name = "Maximum Weight (pounds)")]
        public int? MaximumWeight { get; set; }

        [MaxLength(250)]
        [Display(Name = "Nationality Name")]
        public string Nationality { get; set; }

        [MaxLength(250)]
        [Display(Name = "Father Name")]
        public string FatherName { get; set; }

        [MaxLength(250)]
        [Display(Name = "Mother Name")]
        public string MotherName { get; set; }

        [MaxLength(50)]
        [Display(Name = "Passport Number")]
        public string PassportNumber { get; set; }

        [MaxLength(50)]
        [Display(Name = "Driver License Number")]
        public string DriverLicenseNumber { get; set; }

        [Range(1, int.MaxValue)]
        [Display(Name = "Limit Results To")]
        public int MaxResults { get; set; }

        public ICollection<SelectListItem> Genders {
            get {
                return new List<SelectListItem> {
                    new SelectListItem { Value = string.Empty, Text = "" },
                    new SelectListItem { Value = "F", Text = "Female" },
                    new SelectListItem { Value = "M", Text = "Male" },
                };
            }
        }
    }
}