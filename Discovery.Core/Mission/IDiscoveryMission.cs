using Discovery.Core.Instruments;
using Discovery.Core.Instruments.Rover;

namespace Discovery.Core.Mission
{
    public interface IDiscoveryMission
    {
        /// <summary>
        /// Discovers the given plateau coordinates with given discovery details.
        /// </summary>
        /// <param name="discoveryInformation">Detailed discovery information.</param>
        /// <returns>Returns the latest state of the discovery rover pair.</returns>
        (Rover firstRover, Rover secondRover) Discover(DiscoveryInformation discoveryInformation);
    }
}