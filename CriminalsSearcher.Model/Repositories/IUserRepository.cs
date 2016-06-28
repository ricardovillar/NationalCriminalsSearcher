using CriminalsSearcher.Model.Entities;

namespace CriminalsSearcher.Model.Repositories {
    public interface IUserRepository {
        void Create(string name, string email, string password);
        User GetUserByEmail(string email);
    }
}
