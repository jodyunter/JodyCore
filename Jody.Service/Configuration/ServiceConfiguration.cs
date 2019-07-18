using Jody.Services;
using Ninject;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jody.Services.Configuration
{
    public class ServiceConfiguration
    {
        protected IReadOnlyKernel kernel;
        public IReadOnlyKernel Kernel { get { return kernel; } }
        public ITeamService TeamService { get { return Kernel.Get<ITeamService>(); } }
        public ServiceConfiguration()
        {
            kernel = new KernelConfiguration(new ServiceBindings()).BuildReadonlyKernel();
        }
    }
}
