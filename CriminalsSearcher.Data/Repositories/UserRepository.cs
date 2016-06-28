using System.Linq;
using CriminalsSearcher.Model.Entities;
using CriminalsSearcher.Model.Repositories;

namespace CriminalsSearcher.Data.Repositories {
    public class UserRepository : BaseRepository<User>, IUserRepository  {

        public void Create(string name, string email, string password) {
            var sql = "insert into users (name, email, password) values ({0}, {1}, {2})";
            ExecuteCommand(sql, name, email, password);            
        }

        public User GetUserByEmail(string email) {
            return GetTable().FirstOrDefault(user => user.Email == email);
        }
    }
}
