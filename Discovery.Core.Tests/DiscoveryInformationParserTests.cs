using System.Collections.Generic;
using System.Drawing;
using Discovery.Core.Instruments;
using Discovery.Core.Instruments.Rover;
using Discovery.Core.Mission;
using NUnit.Framework;

namespace Discovery.Core.Tests
{
    [TestFixture]
    public class DiscoveryInformationParserTests
    {
        [Test]
        public void Parse_An_Example_Input_Into_DiscoveryInformation_Successfully()
        {
            var discoveryInformationParser = new DiscoveryInformationParser();

            string[] plateauCoordinates = { "5", "5" };
            string[] firstRoverPosition = { "1", "2", "N" };
            string[] firstRoverActions =  { "L", "M", "L", "M", "L", "M", "L", "M", "M"};

            string[] secondRoverPosition = { "3", "3", "E" };
            string[] secondRoverActions = { "M", "M", "R", "M", "M", "R", "M", "R", "R", "M" };

            DiscoveryInformation allDiscoveryInformation = discoveryInformationParser
                .ParseAllDiscoveryInformation(plateauCoordinates, firstRoverPosition, firstRoverActions, secondRoverPosition, secondRoverActions);

            Assert.NotNull(allDiscoveryInformation);

            Assert.AreEqual(allDiscoveryInformation.PlateauUpperRightCoordinates, new Point(5, 5));

            Assert.AreEqual(allDiscoveryInformation.FirstRoverPosition.Coordinate, new Point(1, 2));
            Assert.AreEqual(allDiscoveryInformation.FirstRoverPosition.Heading, Heading.N);
            Assert.AreEqual(allDiscoveryInformation.FirstRoverActions, new List<RoverAction> {RoverAction.L, RoverAction.M, RoverAction.L, RoverAction.M, RoverAction.L, RoverAction.M, RoverAction.L, RoverAction.M, RoverAction.M});

            Assert.AreEqual(allDiscoveryInformation.SecondRoverPosition.Coordinate, new Point(3, 3));
            Assert.AreEqual(allDiscoveryInformation.SecondRoverPosition.Heading, Heading.E);
            Assert.AreEqual(allDiscoveryInformation.SecondRoverActions, new List<RoverAction> {RoverAction.M, RoverAction.M, RoverAction.R, RoverAction.M, RoverAction.M, RoverAction.R, RoverAction.M, RoverAction.R, RoverAction.R, RoverAction.M});
        }

        [Test]
        public void Parse_An_Example_Input_Into_DiscoveryInformation_Unsuccessfully()
        {
            var discoveryInformationParser = new DiscoveryInformationParser();

            string[] plateauCoordinates = { "5  ", "5vbn" };
            string[] firstRoverPosition = { "** 1 fd", " 2", "N", "bn" };
            string[] firstRoverActions = { "L", "fgM", "L", "M", "L", "M ", "L", "M", "M" };

            string[] secondRoverPosition = { "1", "1", "sd   E " };
            string[] secondRoverActions = { "M", "M", "R", "Mvbn", "M", "R", "M", "R ", "R", "M" };

            DiscoveryInformation allDiscoveryInformation = discoveryInformationParser
                .ParseAllDiscoveryInformation(plateauCoordinates, firstRoverPosition, firstRoverActions, secondRoverPosition, secondRoverActions);

            Assert.Null(allDiscoveryInformation);
        }
    }
}
