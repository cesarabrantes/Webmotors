using Microsoft.Extensions.DependencyInjection;

namespace Webmotors.Data.Dal.IoC
{
    public static class DefaultRegistry
    {
        public static IServiceCollection AddRegistryDomainRepository(this IServiceCollection pServices)
        {
            pServices.Scan(scan => scan
           .FromAssemblyOf<IRegisterEscopoDal>()
               .AddClasses(classes => classes.AssignableTo<IRegisterEscopoDal>())
                   .AsImplementedInterfaces()
                   .WithTransientLifetime());
            return pServices;
        }
    }
}
