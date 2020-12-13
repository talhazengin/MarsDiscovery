using System.Drawing;
using Discovery.Core.Instruments;
using Discovery.Core.Instruments.Rover;
using NUnit.Framework;

namespace Discovery.Core.Tests
{
    [TestFixture]
    public class RoverTests
    {
        private Rover _rover;

        [SetUp]
        public void SetUp_Rover()
        {
            var roverPosition = new RoverPosition { Coordinate = new Point(5, 2), Heading = Heading.S };

            _rover = new Rover(roverPosition);
        }

        [Test]
        public void Rover_Turns_Around_Itself_Clockwise()
        {
            _rover.PerformActions(new [] { RoverAction.R, RoverAction.R, RoverAction.R, RoverAction.R });

            Assert.AreEqual(_rover.Position.Heading, Heading.S);
        }

        [Test]
        public void Rover_Turns_Around_Itself_Counter_Clockwise()
        {
            _rover.PerformActions(new[] { RoverAction.L, RoverAction.L, RoverAction.L, RoverAction.L });

            Assert.AreEqual(_rover.Position.Heading, Heading.S);
        }

        [Test]
        public void Rover_Moves_Forward_One_Unit()
        {
            _rover.PerformAction(RoverAction.M);

            Assert.AreEqual(_rover.Position.Coordinate, new Point(5, 1));
        }

        [Test]
        public void Rover_Moves_To_Origin_Of_Plateau_With_Custom_Rota()
        {
            _rover.PerformActions(new[]
            {   RoverAction.M, RoverAction.L, RoverAction.M, RoverAction.L, 
                RoverAction.M, RoverAction.L, RoverAction.M, RoverAction.R,
                RoverAction.L, RoverAction.M, RoverAction.M, RoverAction.L, 
                RoverAction.M, RoverAction.M, RoverAction.R, RoverAction.M, 
                RoverAction.M, RoverAction.M, RoverAction.R, RoverAction.R
            });

            Assert.AreEqual(_rover.Position.Coordinate, new Point(0, 0));
            Assert.AreEqual(_rover.Position.Heading, Heading.E);
        }
    }
}
