using CriminalsSearcher.Model.Entities;
using System.Data.Linq;
using System.Configuration;

namespace CriminalsSearcher.Data.Repositories {
    public abstract class BaseRepository<T> where T:Entity {        
        private readonly DataContext _dataContext;

        protected BaseRepository() {            
            _dataContext = new DataContext(ConfigurationManager.ConnectionStrings["CriminalsSearcherDB"].ConnectionString);
        }

        protected Table<T> GetTable() {            
            return _dataContext.GetTable<T>();            
        }
        
        protected int ExecuteCommand(string command, params object[] parameters) {
            return _dataContext.ExecuteCommand(command, parameters);
        }        
    }
}
