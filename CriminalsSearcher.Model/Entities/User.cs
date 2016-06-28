using System.Data.Linq.Mapping;

namespace CriminalsSearcher.Model.Entities {

    [Table(Name = "Users")]
    public class User : Entity {

        [Column(IsPrimaryKey = true)]
        public long ID { get; set; }

        [Column]
        public string Name { get; set; }

        [Column]
        public string Email { get; set; }

        [Column]
        public string Password { get; set; }
    }
}
