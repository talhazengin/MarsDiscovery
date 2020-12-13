using System;
using System.Collections.Generic;
using System.Linq;
using Discovery.Core.Instruments;
using Discovery.Core.Instruments.Rover;
using Discovery.Core.Mission;

namespace MarsDiscovery.Mission
{
    public class MarsDiscoveryMissionHumanInterface : IDiscoveryMissionHumanInterface
    {
        private readonly IDiscoveryInformationParser _discoveryInformationParser;

        public MarsDiscoveryMissionHumanInterface(IDiscoveryInformationParser discoveryInformationParser)
        {
            _discoveryInformationParser = discoveryInformationParser;
        }

        public void StartMessage()
        {
            Console.WriteLine("\n *.*.*.*.*.*.* MARS DISCOVERY MISSION STARTED *.*.*.*.*.*.*");
        }

        public DiscoveryInformation GetDiscoveryInformation()
        {
            Console.WriteLine("\n Please type all the discovery information: \n");

            Console.Write(" ");
            IEnumerable<string> plateauCoordinates = Console.ReadLine()?.Split(' ');

            Console.Write(" ");
            IEnumerable<string> firstRoverPosition = Console.ReadLine()?.Split(' ');

            Console.Write(" ");
            IEnumerable<string> firstRoverActions = Console.ReadLine()?.ToCharArray().Select(c => c.ToString());

            Console.Write(" ");
            IEnumerable<string> secondRoverPosition = Console.ReadLine()?.Split(' ');

            Console.Write(" ");
            IEnumerable<string> secondRoverActions = Console.ReadLine()?.ToCharArray().Select(c => c.ToString());

            DiscoveryInformation discoveryInformation = _discoveryInformationParser.ParseAllDiscoveryInformation(
                plateauCoordinates,
                firstRoverPosition,
                firstRoverActions,
                secondRoverPosition,
                secondRoverActions);

            if (discoveryInformation == null)
            {
                Console.WriteLine("\n Please type the discovery information correctly!");
                Console.Write("\n Press any key to start mission over...");
                Console.ReadKey();
                Console.Clear();
                StartMessage();
                return GetDiscoveryInformation();
            }

            return discoveryInformation;
        }

        public void DiscoverySuccessfulMessage(RoverPosition firstRover, RoverPosition secondRover)
        {
            Console.WriteLine("\n *.*.*.*.*.*.* MARS HAS BEEN SUCCESSFULLY DISCOVERED *.*.*.*.*.*.*");
            Console.WriteLine("\n Rovers last positions:");
            Console.Write($"\n {firstRover.Coordinate.X} {firstRover.Coordinate.Y} {firstRover.Heading} -> First Rover");
            Console.WriteLine($"\n {secondRover.Coordinate.X} {secondRover.Coordinate.Y} {secondRover.Heading} -> Second Rover");
        }

        public void EndMessage()
        {
            Console.Write("\n *.*.*.*.*.*.* MARS DISCOVERY MISSION ENDED *.*.*.*.*.*.*");
            Console.ReadKey();
        }
    }
}