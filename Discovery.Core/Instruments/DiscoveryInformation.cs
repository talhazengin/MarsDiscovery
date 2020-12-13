using System.Collections.Generic;
using System.Drawing;
using Discovery.Core.Instruments.Rover;

namespace Discovery.Core.Instruments
{
    public class DiscoveryInformation
    {
        public Point PlateauUpperRightCoordinates;

        public RoverPosition FirstRoverPosition { get; set; } = new RoverPosition();

        public RoverPosition SecondRoverPosition { get; set; } = new RoverPosition();

        public IReadOnlyList<RoverAction> FirstRoverActions { get; set; }

        public IReadOnlyList<RoverAction> SecondRoverActions { get; set; }
    }
}