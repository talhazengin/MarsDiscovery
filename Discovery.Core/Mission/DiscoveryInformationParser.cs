using System;
using System.Collections.Generic;
using System.Linq;
using Discovery.Core.Instruments;
using Discovery.Core.Instruments.Rover;

namespace Discovery.Core.Mission
{
    public class DiscoveryInformationParser : IDiscoveryInformationParser
    {
        public DiscoveryInformation ParseAllDiscoveryInformation(
            IEnumerable<string> plateauCoordinates,
            IEnumerable<string> firstRoverPosition,
            IEnumerable<string> firstRoverActions,
            IEnumerable<string> secondRoverPosition,
            IEnumerable<string> secondRoverActions)
        {
            var discoveryInformation = new DiscoveryInformation();

            if (!ParsePlateauCoordinates(plateauCoordinates.ToList(), discoveryInformation))
            {
                return null;
            }

            if (!ParseRoverPosition(firstRoverPosition.ToList(), discoveryInformation.FirstRoverPosition))
            {
                return null;
            }

            if (!ParseRoverPosition(secondRoverPosition.ToList(), discoveryInformation.SecondRoverPosition))
            {
                return null;
            }

            bool result;

            (result, discoveryInformation.FirstRoverActions) = ParseRoverActions(firstRoverActions);

            if (!result)
            {
                return null;
            }

            (result, discoveryInformation.SecondRoverActions) = ParseRoverActions(secondRoverActions);

            return result ? discoveryInformation : null;
        }

        private bool ParsePlateauCoordinates(IReadOnlyList<string> plateauCoordinates, DiscoveryInformation discoveryInformation)
        {
            if (plateauCoordinates.Count != 2)
            {
                return false;
            }

            if (int.TryParse(plateauCoordinates[0], out int coordinate))
            {
                discoveryInformation.PlateauUpperRightCoordinates.X = coordinate;
            }
            else
            {
                return false;
            }

            if (int.TryParse(plateauCoordinates[1], out coordinate))
            {
                discoveryInformation.PlateauUpperRightCoordinates.Y = coordinate;
            }
            else
            {
                return false;
            }

            return true;
        }

        private bool ParseRoverPosition(IReadOnlyList<string> roverPositionInput, RoverPosition roverPosition)
        {
            if (roverPositionInput.Count != 3)
            {
                return false;
            }

            if (int.TryParse(roverPositionInput[0], out int coordinate))
            {
                roverPosition.Coordinate.X = coordinate;
            }
            else
            {
                return false;
            }

            if (int.TryParse(roverPositionInput[1], out coordinate))
            {
                roverPosition.Coordinate.Y = coordinate;
            }
            else
            {
                return false;
            }

            if (Enum.TryParse(roverPositionInput[2], out Heading heading))
            {
                roverPosition.Heading = heading;
            }
            else
            {
                return false;
            }

            return true;
        }

        private (bool result, IReadOnlyList<RoverAction> roverActions) ParseRoverActions(IEnumerable<string> roverActionsInput)
        {
            var roverActions = new List<RoverAction>();

            foreach (string actionString in roverActionsInput)
            {
                if (Enum.TryParse(actionString, out RoverAction action))
                {
                    roverActions.Add(action);
                }
                else
                {
                    return (false, null);
                }
            }

            return (true, roverActions);
        }
    }
}
