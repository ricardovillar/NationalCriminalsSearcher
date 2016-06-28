using System;

namespace CriminalsSearcher.Model.DTO {
    public class CriminalSearchParameters {
        public string Name { get; set; }
        public DateTime? MinimumBirthDate { get; set; }
        public DateTime? MaximumBirthDate { get; set; }
        public string Gender { get; set; }
        public int? MinimumHeight { get; set; }
        public int? MaximumHeight { get; set; }
        public int? MinimumWeight { get; set; }
        public int? MaximumWeight { get; set; }
        public string Nationality { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string PassportNumber { get; set; }
        public string DriverLicenseNumber { get; set; }
    }
}
