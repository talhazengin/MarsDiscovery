using System.Collections.Generic;

namespace Discovery.Core.Instruments.Rover
{
    public class Rover
    {
        private readonly RoverActionHandler _roverActionHandler;
        
        public RoverPosition Position { get; set; }

        public Rover(RoverPosition position)
        {
            Position = position;
            _roverActionHandler = new RoverActionHandler();
        }

        /// <summary>
        /// Performs a series of actions.
        /// </summary>
        /// <param name="roverActions">A series of actions.</param>
        public void PerformActions(IEnumerable<RoverAction> roverActions)
        {
            foreach (RoverAction roverAction in roverActions)
            {
                PerformAction(roverAction);
            }
        }

        /// <summary>
        /// Performs an action.
        /// </summary>
        /// <param name="roverAction">An action.</param>
        public void PerformAction(RoverAction roverAction)
        {
            _roverActionHandler.HandleAction(this, roverAction);
        }
    }
}