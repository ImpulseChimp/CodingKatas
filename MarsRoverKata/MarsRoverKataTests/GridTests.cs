using MarsRoverKata;
using NUnit.Framework;
using System;

namespace MarsRoverKataTests
{
    [TestFixture]
    public class GridTests
    {
        private const Int32 InitialXCoordinate = 2;
        private const Int32 InitialYCoordinate = 3;
        private const Char InitialRoverDirection = DirectionConstants.North;
        private MarsRover marsRover;
        private Grid grid;

        [SetUp]
        public void SetUp()
        {
            grid = new Grid(5, 5);
            marsRover = new MarsRover(InitialXCoordinate, InitialYCoordinate, InitialRoverDirection);
        }

        [Test]
        public void RunAllInitializations()
        {
            var defaultGrid = new Grid(5, 5);
            Assert.IsNotNull(defaultGrid);
        }

        [Test]
        public void PlaceRoverOnTheGrid()
        {
            grid.PlaceRover(marsRover, 0, 0, 'N');
            Assert.AreEqual(0, marsRover.XCoordinate);
            Assert.AreEqual(0, marsRover.YCoordinate);
        }

        [Test]
        public void FailToPlaceRoverOnTheGrid()
        {
            grid.PlaceRover(marsRover, 100, 100, 'N');
            Assert.AreEqual(2, marsRover.XCoordinate);
            Assert.AreEqual(3, marsRover.YCoordinate);
        }

        [Test]
        public void VerifyRoverWrapsFromBottomOfGridToTheTop()
        {
            marsRover = new MarsRover(grid, 2, 0, DirectionConstants.South);
            marsRover.RunRoverWithCommands("f");
            Assert.AreEqual(2, marsRover.XCoordinate);
            Assert.AreEqual(4, marsRover.YCoordinate);

            var stringGrid = marsRover.PrintMap();
            System.Diagnostics.Debug.WriteLine(stringGrid);
        }

        [Test]
        public void VerifyRoverWrapsFromTopOfGridToTheBottom()
        {
            marsRover = new MarsRover(grid, 2, 4, DirectionConstants.North);
            marsRover.RunRoverWithCommands("f");
            Assert.AreEqual(2, marsRover.XCoordinate);
            Assert.AreEqual(0, marsRover.YCoordinate);

            var stringGrid = marsRover.PrintMap();
            System.Diagnostics.Debug.WriteLine(stringGrid);
        }

        [Test]
        public void VerifyRoverWrapsFromLeftOfGridToRight()
        {
            marsRover = new MarsRover(grid, 0, 0, DirectionConstants.West);
            marsRover.RunRoverWithCommands("f");
            Assert.AreEqual(4, marsRover.XCoordinate);
            Assert.AreEqual(0, marsRover.YCoordinate);

            var stringGrid = marsRover.PrintMap();
            System.Diagnostics.Debug.WriteLine(stringGrid);
        }

        [Test]
        public void VerifyRoverWrapsFromRightOfGridToLeft()
        {
            marsRover = new MarsRover(grid, 4, 0, DirectionConstants.East);
            marsRover.RunRoverWithCommands("f");
            Assert.AreEqual(0, marsRover.XCoordinate);
            Assert.AreEqual(0, marsRover.YCoordinate);
            marsRover.XCoordinate = 6;

            var stringGrid = marsRover.PrintMap();
            System.Diagnostics.Debug.WriteLine(stringGrid);
        }

        [TestCase(DirectionConstants.North)]
        [TestCase(DirectionConstants.South)]
        [TestCase(DirectionConstants.East)]
        [TestCase(DirectionConstants.West)]
        public void RoverStopsAtObstacleInPath(Char initialDirection)
        {
            grid.PlaceObstacleAt(1, 0);
            grid.PlaceObstacleAt(2, 1);
            grid.PlaceObstacleAt(0, 1);
            grid.PlaceObstacleAt(1, 2);
            marsRover = new MarsRover(grid, 1, 1, initialDirection);
            marsRover.RunRoverWithCommands("f");
            Assert.IsTrue(marsRover.AtObstacle);

            var stringGrid = marsRover.PrintMap();
            System.Diagnostics.Debug.WriteLine(stringGrid);
        }

        [Test]
        public void RoverStopsAtObstacleInMultiStepPath()
        {
            grid.PlaceObstacleAt(4, 4);
            marsRover = new MarsRover(grid, 0, 0, DirectionConstants.East);
            marsRover.RunRoverWithCommands("fflffrflffrf");
            Assert.IsTrue(marsRover.AtObstacle);

            var stringGrid = marsRover.PrintMap();
            System.Diagnostics.Debug.WriteLine(stringGrid);
        }

        [Test]
        public void GridToStringWorks()
        {
            grid.PlaceObstacleAt(4, 4);
            grid.PlaceObstacleAt(0, 0);
            marsRover = new MarsRover(grid, 0, 4, DirectionConstants.East);
            marsRover.RunRoverWithCommands("f");
            var stringGrid = marsRover.PrintMap();
            System.Diagnostics.Debug.WriteLine(stringGrid);
            Assert.AreEqual(".R__X\n_____\n_____\n_____\nX____\n", stringGrid);
        }

    }
}
