using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Webmotors.Data.Mapping.IoC
{
    public static class DefaultRegistry
    {
        public static IServiceCollection AddNHibernate(this IServiceCollection pServices, IConfiguration pConfiguration)
        {

            var sessionFactory = Fluently.Configure()
                                      .Database(MsSqlConfiguration.MsSql2012.ConnectionString(pConfiguration.GetConnectionString("SqlWebmotors")))
                                      .Mappings(m => m.FluentMappings.AddFromAssemblyOf<IRegisterEscopoMapping>())                                      
                                      .BuildSessionFactory();

            var x = sessionFactory.OpenSession();
            pServices.AddSingleton(sessionFactory);
            pServices.AddScoped(factory => sessionFactory.OpenSession());

            return pServices;
        }
    }
}
