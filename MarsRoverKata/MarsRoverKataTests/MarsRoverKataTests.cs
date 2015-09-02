using MarsRoverKata;
using NUnit.Framework;
using System;

namespace MarsRoverKataTests
{
    [TestFixture]
    public class MarsRoverKataTests
    {
        private const Int32 InitialXCoordinate = 2;
        private const Int32 InitialYCoordinate = 3;
        private const Char InitialRoverDirection = DirectionConstants.North;
        private MarsRover marsRover;

        [SetUp]
        public void Initialize()
        {
            marsRover = new MarsRover(new Grid(10000, 10000), InitialXCoordinate, InitialYCoordinate, InitialRoverDirection);
        }

        [TestCase(4, CommandConstants.Forward)]
        [TestCase(2, CommandConstants.Backwards)]
        [TestCase(3, CommandConstants.Forward, CommandConstants.Backwards)]
        [TestCase(3, 'F', 'B')]
        [TestCase(4, CommandConstants.Backwards, CommandConstants.Forward, CommandConstants.Forward)]
        [TestCase(1, CommandConstants.Backwards, CommandConstants.Backwards)]
        [TestCase(3, 'F', 'B', 'F', 'B', 'B', 'B', 'F', 'F', 'B', 'F')]
        [TestCase(2, CommandConstants.Backwards, 'B', 'F', CommandConstants.Forward, 'B')]
        [TestCase(3, DirectionConstants.West, 'h', DirectionConstants.East, CommandConstants.Right, DirectionConstants.East, 'i', DirectionConstants.South, 't', 'h', DirectionConstants.East, CommandConstants.Backwards, DirectionConstants.East, DirectionConstants.East, CommandConstants.Forward)]
        public void RoverMovesForwardsAndOrBackwards(Int32 expectedYCoordinate, params Char[] commands)
        {
            marsRover.RunRoverWithCommands(commands);
            var roverYCoordinate = marsRover.YCoordinate;
            Assert.That(expectedYCoordinate, Is.EqualTo(roverYCoordinate));
        }
        
        [TestCase(3, "fb")]
        [TestCase(4, "bff")]
        [TestCase(1, "bb")]
        [TestCase(3, "FBFBBBFFBF")]
        [TestCase(2, "bBFfB")]
        [TestCase(3, "whereisthebeef")]
        [TestCase(61, "ffffffffffffffffffffffffffffffffffffffffffffffffffffffffff")]
        public void RoverMovesForwardsAndOrBackwards(Int32 expectedYCoordinate, String commands)
        {
            marsRover.RunRoverWithCommands(commands);
            Assert.That(expectedYCoordinate, Is.EqualTo(marsRover.YCoordinate));
        }

        [Test]
        public void RoverDoesntRunInvalidInput()
        {
            marsRover.RunRoverWithCommands("༼ つ ͡◕ Ѿ ͡◕ ༽つ");
            Assert.That(InitialYCoordinate, Is.EqualTo(marsRover.YCoordinate));
        }

        [TestCase(DirectionConstants.East, "F", 3, InitialYCoordinate)]
        [TestCase(DirectionConstants.East, "B", 1, InitialYCoordinate)]
        [TestCase(DirectionConstants.East, "f", 3, InitialYCoordinate)]
        [TestCase(DirectionConstants.East, "F", 3, InitialYCoordinate)]
        [TestCase(DirectionConstants.West, "B", 3, InitialYCoordinate)]
        [TestCase(DirectionConstants.West, "b", 3, InitialYCoordinate)]
        [TestCase(DirectionConstants.West, "f", 1, InitialYCoordinate)]
        [TestCase(DirectionConstants.West, "b", 3, InitialYCoordinate)]
        [TestCase(DirectionConstants.North, "F", InitialXCoordinate, 4)]
        [TestCase(DirectionConstants.North, "B", InitialXCoordinate, 2)]
        [TestCase(DirectionConstants.North, "f", InitialXCoordinate, 4)]
        [TestCase(DirectionConstants.North, "F", InitialXCoordinate, 4)]
        [TestCase(DirectionConstants.South, "B", InitialXCoordinate, 4)]
        [TestCase(DirectionConstants.South, "b", InitialXCoordinate, 4)]
        [TestCase(DirectionConstants.South, "f", InitialXCoordinate, 2)]
        [TestCase(DirectionConstants.South, "b", InitialXCoordinate, 4)]
        [TestCase('U', "f", InitialXCoordinate, InitialYCoordinate)]
        [TestCase('U', "b", InitialXCoordinate, InitialYCoordinate)]
        [TestCase('U', "F", InitialXCoordinate, InitialYCoordinate)]
        [TestCase('U', "B", InitialXCoordinate, InitialYCoordinate)]
        public void RoverUnitVectors(Char initialDirection, String commands, Int32 endingXCoordinate, Int32 endingYCoordinate)
        {
            var rover = new MarsRover(InitialXCoordinate, InitialYCoordinate, initialDirection);

            rover.RunRoverWithCommands(commands);
            Assert.That(rover.XCoordinate, Is.EqualTo(endingXCoordinate));
            Assert.That(rover.YCoordinate, Is.EqualTo(endingYCoordinate));
        }

        [TestCase(DirectionConstants.North, "r", DirectionConstants.East)]
        [TestCase(DirectionConstants.North, "rr", DirectionConstants.South)]
        [TestCase(DirectionConstants.North, "rrr", DirectionConstants.West)]
        [TestCase(DirectionConstants.North, "rrrr", DirectionConstants.North)]
        [TestCase(DirectionConstants.North, "RRRRR", DirectionConstants.East)]
        [TestCase(DirectionConstants.North, "rRrRr", DirectionConstants.East)]
        [TestCase(DirectionConstants.North, "rrrrRRRRrrrrRRRRr", DirectionConstants.East)]
        [TestCase(DirectionConstants.North, "rrrrBoogierr", DirectionConstants.South)]
        [TestCase(DirectionConstants.North, "", DirectionConstants.North)]
        [TestCase(DirectionConstants.East, "r", DirectionConstants.South)]
        [TestCase(DirectionConstants.South, "r", DirectionConstants.West)]
        [TestCase(DirectionConstants.West, "r", DirectionConstants.North)]
        [TestCase(DirectionConstants.North, "l", DirectionConstants.West)]
        [TestCase(DirectionConstants.North, "ll", DirectionConstants.South)]
        [TestCase(DirectionConstants.North, "lLl", DirectionConstants.East)]
        [TestCase(DirectionConstants.North, "lLLLl", DirectionConstants.West)]
        [TestCase(DirectionConstants.North, "ilostmylllll", DirectionConstants.South)]
        [TestCase(DirectionConstants.East, "l", DirectionConstants.North)]
        [TestCase(DirectionConstants.South, "l", DirectionConstants.East)]
        [TestCase(DirectionConstants.West, "l", DirectionConstants.South)]
        [TestCase(DirectionConstants.North, "lrl", DirectionConstants.West)]
        [TestCase(DirectionConstants.West, "lRl", DirectionConstants.South)]
        [TestCase(DirectionConstants.South, "RlR", DirectionConstants.West)]
        [TestCase(DirectionConstants.East, "rLr", DirectionConstants.South)]
        public void RoverTurning(Char initialDirection, String commands, Char endingDireciton)
        {
            var rover = new MarsRover(InitialXCoordinate, InitialYCoordinate, initialDirection);

            rover.RunRoverWithCommands(commands);
            Assert.That(rover.roverState.Direction, Is.EqualTo(endingDireciton));
        }

        [TestCase(DirectionConstants.North, 0, 0, "fblr", DirectionConstants.North, 0, 0)]
        [TestCase(DirectionConstants.North, 0, 0, "bflr", DirectionConstants.North, 0, 0)]
        [TestCase(DirectionConstants.North, 0, 0, "blfr", DirectionConstants.North, -1, -1)]
        [TestCase(DirectionConstants.North, 0, 0, "blrf", DirectionConstants.North, 0, 0)]
        [TestCase(DirectionConstants.North, 0, 0, "lbrf", DirectionConstants.North, 1, 1)]
        [TestCase(DirectionConstants.North, 0, 0, "lrbf", DirectionConstants.North, 0, 0)]
        [TestCase(DirectionConstants.North, 0, 0, "lrfb", DirectionConstants.North, 0, 0)]
        [TestCase(DirectionConstants.North, 0, 0, "rlfb", DirectionConstants.North, 0, 0)]
        [TestCase(DirectionConstants.North, 0, 0, "rflb", DirectionConstants.North, 1, -1)]
        [TestCase(DirectionConstants.North, 0, 0, "rfbl", DirectionConstants.North, 0, 0)]
        [TestCase(DirectionConstants.North, 0, 0, "frbl", DirectionConstants.North, -1, 1)]
        [TestCase(DirectionConstants.North, 0, 0, "fbrl", DirectionConstants.North, 0, 0)]
        [TestCase(DirectionConstants.West, 0, 0, "fblr", DirectionConstants.West, 0, 0)]
        [TestCase(DirectionConstants.West, 0, 0, "bflr", DirectionConstants.West, 0, 0)]
        [TestCase(DirectionConstants.West, 0, 0, "blfr", DirectionConstants.West, 1, -1)]
        [TestCase(DirectionConstants.West, 0, 0, "blrf", DirectionConstants.West, 0, 0)]
        [TestCase(DirectionConstants.West, 0, 0, "lbrf", DirectionConstants.West, -1, 1)]
        [TestCase(DirectionConstants.West, 0, 0, "lrbf", DirectionConstants.West, 0, 0)]
        [TestCase(DirectionConstants.West, 0, 0, "lrfb", DirectionConstants.West, 0, 0)]
        [TestCase(DirectionConstants.West, 0, 0, "rlfb", DirectionConstants.West, 0, 0)]
        [TestCase(DirectionConstants.West, 0, 0, "rflb", DirectionConstants.West, 1, 1)]
        [TestCase(DirectionConstants.West, 0, 0, "rfbl", DirectionConstants.West, 0, 0)]
        [TestCase(DirectionConstants.West, 0, 0, "frbl", DirectionConstants.West, -1, -1)]
        [TestCase(DirectionConstants.West, 0, 0, "fbrl", DirectionConstants.West, 0, 0)]
        [TestCase(DirectionConstants.South, 0, 0, "fblr", DirectionConstants.South, 0, 0)]
        [TestCase(DirectionConstants.South, 0, 0, "bflr", DirectionConstants.South, 0, 0)]
        [TestCase(DirectionConstants.South, 0, 0, "blfr", DirectionConstants.South, 1, 1)]
        [TestCase(DirectionConstants.South, 0, 0, "blrf", DirectionConstants.South, 0, 0)]
        [TestCase(DirectionConstants.South, 0, 0, "lbrf", DirectionConstants.South, -1, -1)]
        [TestCase(DirectionConstants.South, 0, 0, "lrbf", DirectionConstants.South, 0, 0)]
        [TestCase(DirectionConstants.South, 0, 0, "lrfb", DirectionConstants.South, 0, 0)]
        [TestCase(DirectionConstants.South, 0, 0, "rlfb", DirectionConstants.South, 0, 0)]
        [TestCase(DirectionConstants.South, 0, 0, "rflb", DirectionConstants.South, -1, 1)]
        [TestCase(DirectionConstants.South, 0, 0, "rfbl", DirectionConstants.South, 0, 0)]
        [TestCase(DirectionConstants.South, 0, 0, "frbl", DirectionConstants.South, 1, -1)]
        [TestCase(DirectionConstants.South, 0, 0, "fbrl", DirectionConstants.South, 0, 0)]
        [TestCase(DirectionConstants.East, 0, 0, "fblr", DirectionConstants.East, 0, 0)]
        [TestCase(DirectionConstants.East, 0, 0, "bflr", DirectionConstants.East, 0, 0)]
        [TestCase(DirectionConstants.East, 0, 0, "blfr", DirectionConstants.East, -1, 1)]
        [TestCase(DirectionConstants.East, 0, 0, "blrf", DirectionConstants.East, 0, 0)]
        [TestCase(DirectionConstants.East, 0, 0, "lbrf", DirectionConstants.East, 1, -1)]
        [TestCase(DirectionConstants.East, 0, 0, "lrbf", DirectionConstants.East, 0, 0)]
        [TestCase(DirectionConstants.East, 0, 0, "lrfb", DirectionConstants.East, 0, 0)]
        [TestCase(DirectionConstants.East, 0, 0, "rlfb", DirectionConstants.East, 0, 0)]
        [TestCase(DirectionConstants.East, 0, 0, "rflb", DirectionConstants.East, -1, -1)]
        [TestCase(DirectionConstants.East, 0, 0, "rfbl", DirectionConstants.East, 0, 0)]
        [TestCase(DirectionConstants.East, 0, 0, "frbl", DirectionConstants.East, 1, 1)]
        [TestCase(DirectionConstants.East, 0, 0, "fbrl", DirectionConstants.East, 0, 0)]
        [TestCase(DirectionConstants.North, 90266, 6, "I will not test this method O sam I am. I do not like green eggs and ham...", DirectionConstants.South, 90266, 6)]
        [TestCase(DirectionConstants.North, 57, 23000, "RLFFFBRLLFLrbbbbfbbbfbbbfbbfbbflllrrf", DirectionConstants.South, 65, 23001)]
        public void RoverFullMovement(Char initialDirection, Int32 initialXCoordinate, Int32 initialYCoordinate, String commands, Char endingDireciton, Int32 endingXCoordinate, Int32 endingYCoordinate)
        {
            var rover = new MarsRover(initialXCoordinate, initialYCoordinate, initialDirection);

            rover.RunRoverWithCommands(commands);
            Assert.That(rover.roverState.Direction, Is.EqualTo(endingDireciton));
            Assert.That(rover.XCoordinate, Is.EqualTo(endingXCoordinate));
            Assert.That(rover.YCoordinate, Is.EqualTo(endingYCoordinate));
        }
    }
}
