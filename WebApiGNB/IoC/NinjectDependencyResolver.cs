using System;
using System.Collections.Generic;
using System.Web.Mvc;
using WebApiGNB.InfrastructureAPI.UnitOfWork.Contract;
using Ninject;
using WebApiGNB.InfrastructureAPI.UnitOfWork.Implementation;


namespace WebApiGNB.IoC
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private readonly IKernel _kernel;

        public NinjectDependencyResolver()
        {
            _kernel = new StandardKernel();
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {

            // Unit of work

           // _kernel.Bind<IUnitOfWork>().To<UnitOfWork>().WhenInjectedInto<ConversionService>();

            //// Services

            //_kernel.Bind<IConversionService>().To<ConversionService>();

            //// Factories

            // _kernel.Bind<IConversionFactory>().To<ConversionFactory>();
            
            //Helpers

        }
    }
}