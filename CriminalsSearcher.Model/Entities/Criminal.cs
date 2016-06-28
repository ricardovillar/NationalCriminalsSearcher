using System;
using System.Data.Linq.Mapping;

namespace CriminalsSearcher.Model.Entities {

    [Table(Name = "Criminals")]
    public class Criminal : Entity {

        [Column(IsPrimaryKey = true)]
        public long ID { get; set; }

        [Column]
        public string Name { get; set; }

        [Column]
        public DateTime? BirthDate { get; set; }

        [Column]
        public string Gender { get; set; }

        [Column]
        public int? Height { get; set; }

        [Column]
        public int? Weight { get; set; }

        [Column]
        public string Nationality { get; set; }

        [Column]
        public string FatherName { get; set; }

        [Column]
        public string MotherName { get; set; }

        [Column]
        public string PassportNumber { get; set; }

        [Column]
        public string DriverLicenseNumber { get; set; }        
    }
}
