using System;

namespace MarsRoverKata
{
    class MarsRoverController
    {
        private MarsRoverModel roverModel;

        public MarsRoverController(Grid map)
        {
            roverModel = new MarsRoverModel(map);
        }

        public void ProcessCommands(Char[] commands, MarsRover rover)
        {
            foreach (var command in commands)
                ConsumeCommand(command, rover);
        }

        public void ProcessCommands(String commands, MarsRover rover)
        {
            foreach (var command in commands)
                rover = ConsumeCommand(command, rover);
        }

        public String PrintMapFromGrid()
        {
            return roverModel.PrintMapFromGrid();
        }

        private MarsRover ConsumeCommand(Char command, MarsRover rover)
        {
            var lowercaseCommand = Char.ToLower(command);

            if (lowercaseCommand == CommandConstants.Forward)
                return roverModel.MoveForward(rover);
            else if (lowercaseCommand == CommandConstants.Backwards)
                return roverModel.MoveBackwards(rover);
            else if (lowercaseCommand == CommandConstants.Right)
                return roverModel.TurnRight(rover);
            else if (lowercaseCommand == CommandConstants.Left)
                return roverModel.TurnLeft(rover);

            return rover;
        }
    }
}
