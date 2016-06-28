using Ninject;
using Ninject.Web.Common;

namespace CriminalsSearcher.Services {
    public class Global : NinjectHttpApplication {
        protected override IKernel CreateKernel() {
            return new StandardKernel(new ServiceBindings());
        }
    }
}