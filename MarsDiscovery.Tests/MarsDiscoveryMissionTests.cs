using System.Drawing;
using Discovery.Core.Instruments;
using Discovery.Core.Instruments.Rover;
using MarsDiscovery.Mission;
using NUnit.Framework;

namespace MarsDiscovery.Tests
{
    /// <summary>
    /// The tests in this assembly are kind of integrations tests.
    /// </summary>
    [TestFixture]
    public class MarsDiscoveryMissionTests
    {
        [Test]
        public void Operate_An_Example_Mars_Mission()
        {
            var marsDiscoveryInformation = new DiscoveryInformation
            {
                PlateauUpperRightCoordinates = new Point(5, 5),
                FirstRoverPosition = new RoverPosition {Coordinate = new Point(1, 2), Heading = Heading.N},
                FirstRoverActions = new [] {RoverAction.L, RoverAction.M, RoverAction.L, RoverAction.M, RoverAction.L, RoverAction.M, RoverAction.L, RoverAction.M, RoverAction.M},
                SecondRoverPosition = new RoverPosition {Coordinate = new Point(3, 3), Heading = Heading.E},
                SecondRoverActions = new[] {RoverAction.M, RoverAction.M, RoverAction.R, RoverAction.M, RoverAction.M, RoverAction.R, RoverAction.M, RoverAction.R, RoverAction.R, RoverAction.M},
            };

            var marsDiscoveryMission = new MarsDiscoveryMission();

            (Rover firstRover, Rover secondRover) = marsDiscoveryMission.Discover(marsDiscoveryInformation);

            Assert.AreEqual(firstRover.Position.Coordinate, new Point(1, 3));
            Assert.AreEqual(firstRover.Position.Heading, Heading.N);

            Assert.AreEqual(secondRover.Position.Coordinate, new Point(5, 1));
            Assert.AreEqual(secondRover.Position.Heading, Heading.E);
        }
    }
}
