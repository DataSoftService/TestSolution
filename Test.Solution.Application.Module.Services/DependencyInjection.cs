using Acv2.SharedKernel.Crosscutting.Adapter;
using Acv2.SharedKernel.Crosscutting.NetFramerwork.Adapter;
using Acv2.SharedKernel.Crosscutting.NetFramerwork.Logging;
using Acv2.SharedKernel.Crosscutting.NetFramerwork.Validator;
using Acv2.SharedKernel.Crosscutting.Validator;
using Microsoft.Extensions.DependencyInjection;
using Test.Solution.Application.Module.Services.Services;
using Unity;
using Unity.Lifetime;

namespace Test.Solution.Application.Module.Services
{
    public static class DependencyInjection
    {
        public static IUnityContainer AddContainerApplication(this IUnityContainer container)
        {
            container.RegisterType<ITypeAdapterFactory, AutomapperTypeAdapterFactory>(new ContainerControlledLifetimeManager());

            Acv2.SharedKernel.Crosscutting.Logging.LoggerFactory.SetCurrent(new TraceSourceLogFactory());
            EntityValidatorFactory.SetCurrent(new DataAnnotationsEntityValidatorFactory());

            var typeAdapterFactory = container.Resolve<ITypeAdapterFactory>();
            TypeAdapterFactory.SetCurrent(typeAdapterFactory);

            //Register services
            container.RegisterType(typeof(RegisterAppService));
            return container;
        }
        public static IServiceCollection AddServiceApplicationGeneral(this IServiceCollection service)
        {
            //service.AddAuthentication(JwtBearerDefaults)

            return service;
        }
    }
}
