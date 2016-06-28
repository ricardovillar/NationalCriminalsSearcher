using System.Runtime.Serialization;

namespace CriminalsSearcher.Services {
    public class SearchParameters {

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int? MinimumAge { get; set; }

        [DataMember]
        public int? MaximumAge { get; set; }

        [DataMember]
        public string Gender { get; set; }

        [DataMember]
        public int? MinimumHeight { get; set; }

        [DataMember]
        public int? MaximumHeight { get; set; }

        [DataMember]
        public int? MinimumWeight { get; set; }

        [DataMember]
        public int? MaximumWeight { get; set; }

        [DataMember]
        public string Nationality { get; set; }

        [DataMember]
        public string FatherName { get; set; }

        [DataMember]
        public string MotherName { get; set; }

        [DataMember]
        public string PassportNumber { get; set; }

        [DataMember]
        public string DriverLicenseNumber { get; set; }
    }
}