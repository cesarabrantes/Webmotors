using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Webmotors.Mapper.IoC
{
    public static class DefaultRegistry
    {
        public static IServiceCollection AddAutoMapper(this IServiceCollection pServices)
        {
            var vMapperConfiguration = new MapperConfiguration(config =>
            {
                config.AddProfile<DomainProfile>();
                config.AddProfile<ViewModelProfile>();
                config.AddProfile<MediatorDomain>();
            });

            IMapper mapper = vMapperConfiguration.CreateMapper();
            pServices.AddSingleton(mapper);

            return pServices;
        }
    }
}
