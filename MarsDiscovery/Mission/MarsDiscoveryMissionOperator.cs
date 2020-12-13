using Discovery.Core.Instruments;
using Discovery.Core.Instruments.Rover;
using Discovery.Core.Mission;

namespace MarsDiscovery.Mission
{
    public class MarsDiscoveryMissionOperator : IDiscoveryMissionOperator
    {
        private readonly IDiscoveryMission _discoveryMission;
        private readonly IDiscoveryMissionHumanInterface _discoveryMissionHumanInterface;

        public MarsDiscoveryMissionOperator(IDiscoveryMission discoveryMission, IDiscoveryMissionHumanInterface discoveryMissionHumanInterface)
        {
            _discoveryMission = discoveryMission;
            _discoveryMissionHumanInterface = discoveryMissionHumanInterface;
        }

        public void StartMission()
        {
            _discoveryMissionHumanInterface.StartMessage();

            DiscoveryInformation discoveryInformation = _discoveryMissionHumanInterface.GetDiscoveryInformation();

            (Rover firstRover, Rover secondRover) = _discoveryMission.Discover(discoveryInformation);

            _discoveryMissionHumanInterface.DiscoverySuccessfulMessage(firstRover.Position, secondRover.Position);
            _discoveryMissionHumanInterface.EndMessage();
        }
    }
}
