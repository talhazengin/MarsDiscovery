using Discovery.Core.Instruments;
using Discovery.Core.Instruments.Rover;
using Discovery.Core.Mission;

namespace MarsDiscovery.Mission
{
    public class MarsDiscoveryMission : IDiscoveryMission
    {
        public (Rover firstRover, Rover secondRover) Discover(DiscoveryInformation discoveryInformation)
        {
            var firstRover = new Rover(discoveryInformation.FirstRoverPosition);
            var secondRover = new Rover(discoveryInformation.SecondRoverPosition);

            firstRover.PerformActions(discoveryInformation.FirstRoverActions);
            secondRover.PerformActions(discoveryInformation.SecondRoverActions);

            return (firstRover, secondRover);
        }
    }
}
