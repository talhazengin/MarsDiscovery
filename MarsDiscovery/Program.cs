using System;
using Discovery.Core.Mission;
using MarsDiscovery.Mission;
using Microsoft.Extensions.DependencyInjection;

namespace MarsDiscovery
{
    internal static class Program
    {
        private static void Main()
        {
            InitContainer().InitServices().StartMarsDiscoveryMission();
        }

        private static IServiceCollection InitContainer()
        {
            return new ServiceCollection();
        }

        private static IServiceProvider InitServices(this IServiceCollection services)
        {
            services.AddSingleton<IDiscoveryInformationParser, DiscoveryInformationParser>();
            services.AddSingleton<IDiscoveryMissionHumanInterface, MarsDiscoveryMissionHumanInterface>();
            services.AddSingleton<IDiscoveryMission, MarsDiscoveryMission>();
            services.AddSingleton<IDiscoveryMissionOperator, MarsDiscoveryMissionOperator>();

            return services.BuildServiceProvider();
        }

        private static void StartMarsDiscoveryMission(this IServiceProvider services)
        {
            services.GetRequiredService<IDiscoveryMissionOperator>().StartMission();
        }
    }
}