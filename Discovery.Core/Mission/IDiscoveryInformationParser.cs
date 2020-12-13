using System.Collections.Generic;
using Discovery.Core.Instruments;

namespace Discovery.Core.Mission
{
    public interface IDiscoveryInformationParser
    {
        public DiscoveryInformation ParseAllDiscoveryInformation(
            IEnumerable<string> plateauCoordinates,
            IEnumerable<string> firstRoverPosition,
            IEnumerable<string> firstRoverActions,
            IEnumerable<string> secondRoverPosition,
            IEnumerable<string> secondRoverActions);
    }
}