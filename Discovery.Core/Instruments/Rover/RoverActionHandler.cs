namespace Discovery.Core.Instruments.Rover
{
    public class RoverActionHandler
    {
        public void HandleAction(Rover rover, RoverAction roverAction)
        {
            switch (roverAction)
            {
                case RoverAction.M:
                    Move(rover);
                    break;
                case RoverAction.R:
                    TurnRight(rover);
                    break;
                case RoverAction.L:
                    TurnLeft(rover);
                    break;
            }
        }

        private void Move(Rover rover)
        {
            switch (rover.Position.Heading)
            {
                case Heading.N:
                    rover.Position.Coordinate.Y++;
                    break;
                case Heading.E:
                    rover.Position.Coordinate.X++;
                    break;
                case Heading.S:
                    rover.Position.Coordinate.Y--;
                    break;
                case Heading.W:
                    rover.Position.Coordinate.X--;
                    break;
            }
        }

        private void TurnRight(Rover rover)
        {
            switch (rover.Position.Heading)
            {
                case Heading.N:
                    rover.Position.Heading = Heading.E;
                    break;
                case Heading.E:
                    rover.Position.Heading = Heading.S;
                    break;
                case Heading.S:
                    rover.Position.Heading = Heading.W;
                    break;
                case Heading.W:
                    rover.Position.Heading = Heading.N;
                    break;
            }
        }

        private void TurnLeft(Rover rover)
        {
            switch (rover.Position.Heading)
            {
                case Heading.N:
                    rover.Position.Heading = Heading.W;
                    break;
                case Heading.E:
                    rover.Position.Heading = Heading.N;
                    break;
                case Heading.S:
                    rover.Position.Heading = Heading.E;
                    break;
                case Heading.W:
                    rover.Position.Heading = Heading.S;
                    break;
            }
        }
    }
}