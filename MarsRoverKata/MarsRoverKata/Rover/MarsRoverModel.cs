
namespace MarsRoverKata
{
    class MarsRoverModel
    {
        private Grid map;

        public MarsRoverModel(Grid map)
        {
            this.map = map;
        }

        public MarsRover TurnRight(MarsRover rover)
        {
            rover.roverState = rover.roverState.rightTurn();
            return rover;
        }

        public MarsRover TurnLeft(MarsRover rover)
        {
            rover.roverState = rover.roverState.leftTurn();
            return rover;
        }

        public MarsRover MoveForward(MarsRover rover)
        {
            var newXCoordinate = rover.XCoordinate + rover.roverState.HorizontalDistance();
            var newYCoordinate = rover.YCoordinate + rover.roverState.VerticalDistance();
            return map.MoveRoverTo(rover, newXCoordinate, newYCoordinate);
        }

        public MarsRover MoveBackwards(MarsRover rover)
        {
            var newXCoordinate = rover.XCoordinate - rover.roverState.HorizontalDistance();
            var newYCoordinate = rover.YCoordinate - rover.roverState.VerticalDistance();
            return map.MoveRoverTo(rover, newXCoordinate, newYCoordinate);
        }

        public string PrintMapFromGrid()
        {
            return map.GridToString();
        }
    }
}
