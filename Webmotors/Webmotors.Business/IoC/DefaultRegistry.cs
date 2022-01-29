using Microsoft.Extensions.DependencyInjection;

namespace Webmotors.Business.IoC
{
    public static class DefaultRegistry
    {
        public static IServiceCollection AddRegistryDomainBusiness(this IServiceCollection pServices)
        {
            pServices.Scan(scan => scan
           .FromAssemblyOf<IRegisterEscopoBusiness>()
               .AddClasses(classes => classes.AssignableTo<IRegisterEscopoBusiness>())
                   .AsImplementedInterfaces()
                   .WithTransientLifetime());
            return pServices;
        }
    }
}
