using Discovery.Core.Instruments;
using Discovery.Core.Instruments.Rover;

namespace Discovery.Core.Mission
{
    public interface IDiscoveryMissionHumanInterface
    {
        void StartMessage();

        DiscoveryInformation GetDiscoveryInformation();

        void DiscoverySuccessfulMessage(RoverPosition firstRover, RoverPosition secondRover);

        void EndMessage();
    }
}