using CriminalsSearcher.Data.Repositories;
using CriminalsSearcher.Model.Repositories;
using Ninject.Modules;

namespace CriminalsSearcher.Site.App_Start {
    public class CriminalsSearcherBindings : NinjectModule {
        public override void Load() {
            Bind<IUserRepository>().To<UserRepository>();
        }
    }
}