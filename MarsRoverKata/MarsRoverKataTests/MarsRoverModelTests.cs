using System;
using NUnit.Framework;
using MarsRoverKata;

namespace MarsRoverKataTests
{
    [TestFixture]
    public class MarsRoverModelTests
    {
        private const Int32 InitialXCoordinate = 2;
        private const Int32 InitialYCoordinate = 3;
        private const Char InitialRoverDirection = DirectionConstants.North;
        private MarsRover marsRover;

        [SetUp]
        public void Initialize()
        {
            marsRover = new MarsRover(InitialXCoordinate, InitialYCoordinate, InitialRoverDirection);
        }

        [Test]
        public void RoverXCoordinateIsTwo()
        {
            var roverXCoordinate = marsRover.XCoordinate;
            Assert.That(InitialXCoordinate, Is.EqualTo(roverXCoordinate));
        }

        [Test]
        public void RoverYCoordinateIsThree()
        {
            var roverYCoordinate = marsRover.YCoordinate;
            Assert.That(InitialYCoordinate, Is.EqualTo(roverYCoordinate));
        }

        [Test]
        public void RoverDirectionIsInitiallyNorth()
        {
            Assert.That(InitialRoverDirection, Is.EqualTo(marsRover.roverState.Direction));
        }

        [Test]
        public void RoverDirectionSetWithLowerCaseIsNorth()
        {
            var lowerCaseRover = new MarsRover(0, 0, DirectionConstants.North);
            var roverDirection = lowerCaseRover.roverState.Direction;
            Assert.That(InitialRoverDirection, Is.EqualTo(roverDirection));
        }

        [Test]
        public void RoverDoesntRunInvalidInput()
        {
            marsRover.RunRoverWithCommands("༼ つ ͡◕ Ѿ ͡◕ ༽つ");
            Assert.That(InitialYCoordinate, Is.EqualTo(marsRover.YCoordinate));
        }
    }
}
