using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Webmotors.Mediator.Service.Contracts;

namespace Webmotors.Mediator.Service.IoC
{
    public static class DefaultRegistry
    {
        public static IServiceCollection AddMediator(this IServiceCollection pServices, IConfiguration pConfiguration)
        {
            pServices.Add(new ServiceDescriptor(typeof(IChallengeService), new ChallengeService(pConfiguration.GetSection("UriApi").Value)));
            return pServices;
        }
    }
}
