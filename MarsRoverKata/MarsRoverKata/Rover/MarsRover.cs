using MarsRoverKata.States;
using System;

namespace MarsRoverKata
{
    public class MarsRover
    {
        public Int32 XCoordinate { get; set; }
        public Int32 YCoordinate { get; set; }
        public Boolean AtObstacle { get; set; }
        public IDirectionState roverState { get; set; }
        public Int32 ObstableXCoordinate { get; set; }
        public Int32 ObstableYCoordinate { get; set; }
        private MarsRoverController roverController;

        public MarsRover(Int32 xCoordinate, Int32 yCoordinate, Char initialDirection)
        {
            this.XCoordinate = xCoordinate;
            this.YCoordinate = yCoordinate;
            this.roverState = setInitialState(initialDirection);
            roverController = new MarsRoverController(new Grid());
        }

        public MarsRover(Grid map, Int32 xCoordinate, Int32 yCoordinate, Char initialDirection)
        {
            this.XCoordinate = xCoordinate;
            this.YCoordinate = yCoordinate;
            this.roverState = setInitialState(initialDirection);
            map.PlaceRover(this, xCoordinate, yCoordinate, initialDirection);
            roverController = new MarsRoverController(map);
        }

        public void RunRoverWithCommands(Char[] commands)
        {
            if (!AtObstacle)
                roverController.ProcessCommands(commands, this);
        }

        public void RunRoverWithCommands(String commands)
        {
            if (!AtObstacle)
                roverController.ProcessCommands(commands, this);
        }

        public String PrintMap()
        {
            return roverController.PrintMapFromGrid();
        }

        private IDirectionState setInitialState(Char stateChar)
        {
            switch (Char.ToUpper(stateChar))
            {
                case DirectionConstants.North: return new States.North();
                case DirectionConstants.South: return new States.South();
                case DirectionConstants.East: return new States.East();
                case DirectionConstants.West: return new States.West();
                default: return new States.Invalid();
            }
        }
    }
}
