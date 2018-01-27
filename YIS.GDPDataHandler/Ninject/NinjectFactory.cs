using Ninject;
using System;

namespace YIS.GDPDataHandler.Ninject
{
    public static class NinjectFactory
    {
        public static IKernel GetInitialisedStandardKernelUsing(Action<IKernel> bindingMethod)
        {
            IKernel kernel = new StandardKernel();
            bindingMethod.Invoke(kernel);
            return kernel;
        }
    }
}
