using CriminalsSearcher.Data.Repositories;
using CriminalsSearcher.Model.Repositories;
using Ninject.Modules;

namespace CriminalsSearcher.Services {
    public class ServiceBindings : NinjectModule {
        public override void Load() {
            Bind<ICriminalRepository>().To<CriminalRepository>();
        }
    }
}