using AutoMapper;
using Jody.Services;
using Jody.Services.Configuration;
using Ninject;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jody.Test.Unit.Services.TestConfiguration
{
    public class TestServiceConfiguration:ServiceConfiguration
    {
        public IMapper Mapper { get { return Kernel.Get<IMapper>(); } }

        public TestServiceConfiguration()
        {
            kernel = new KernelConfiguration(new TestServiceBindings()).BuildReadonlyKernel();
        }
    }
}
