using System;

namespace MarsRoverKata
{
    /*INFO: The Grid class in this program makes the following assumption
            about how the world map is understood. Each side of the map
            represents the South Pole and the center of the map represents
            the North Pole. This means that when you exit one side of the map
            you are not teleporting to a new location as much as just continuing
            your path as if the entire grid was placed over a sphere.
    */
    public class Grid
    {
        public readonly Boolean active;
        private const Char ObstacleSymbol = 'X';
        private const Char RoverSymbol = 'R';
        private const Char VisitedSymbol = '.';
        private const Int32 NegativeBoundary = -1;
        private const Int32 DefaultGridDimension = 5;
        private const Int32 GridMinimum = 0;
        private Char[,] gridMap;
        private Int32 gridWidth;
        private Int32 gridHeight;

        public Grid()
        {
            gridWidth = 0;
            gridHeight = 0;
            this.active = false;
            gridMap = new Char[0, 0];
        }

        public Grid(Int32 initialWidth, Int32 iniitalHeight)
        {
            gridWidth = initialWidth;
            gridHeight = iniitalHeight;
            this.active = true;
            gridMap = new Char[initialWidth, iniitalHeight];
        }

        public MarsRover PlaceRover(MarsRover rover, Int32 xCoordinate, Int32 yCoordinate, Char direction)
        {
            if (RoverCanBePlaced(xCoordinate, yCoordinate))
            {
                rover.XCoordinate = xCoordinate;
                rover.YCoordinate = yCoordinate;
                if (active)
                    gridMap[xCoordinate, yCoordinate] = RoverSymbol;
            }

            return rover;
        }


        public MarsRover MoveRoverTo(MarsRover rover, Int32 xCoordinate, Int32 yCoordinate)
        {
            if (!MoveIsValid(rover, xCoordinate, yCoordinate))
                return rover;

            var noObstacleFound = NoObstacleAt(xCoordinate, yCoordinate);
            
            if (RoverCanBeMoved(xCoordinate, yCoordinate, noObstacleFound))
            {
                if (active)
                { 
                    gridMap[rover.XCoordinate, rover.YCoordinate] = VisitedSymbol;
                    gridMap[xCoordinate, yCoordinate] = RoverSymbol;
                }
                rover.XCoordinate = xCoordinate;
                rover.YCoordinate = yCoordinate;
            }
            else if (XCoordinateOnOuterEdge(xCoordinate))
            {
                if (xCoordinate == -1)
                {
                    gridMap[rover.XCoordinate, rover.YCoordinate] = VisitedSymbol;
                    rover.XCoordinate = gridWidth - 1;
                    gridMap[rover.XCoordinate, yCoordinate] = RoverSymbol;
                }
                else
                {
                    gridMap[rover.XCoordinate, rover.YCoordinate] = VisitedSymbol;
                    rover.XCoordinate = 0;
                    gridMap[rover.XCoordinate, yCoordinate] = RoverSymbol;
                }
            }
            else if (YCoordinateOnOuterEdge(yCoordinate))
            {
                if (yCoordinate == -1)
                {
                    gridMap[rover.XCoordinate, rover.YCoordinate] = VisitedSymbol;
                    rover.YCoordinate = gridHeight - 1;
                    gridMap[xCoordinate, rover.YCoordinate] = RoverSymbol;
                }
                else
                {
                    gridMap[rover.XCoordinate, rover.YCoordinate] = VisitedSymbol;
                    rover.YCoordinate = 0;
                    gridMap[xCoordinate, rover.YCoordinate] = RoverSymbol;
                }
            }

            if (!noObstacleFound)
            {
                rover.AtObstacle = true;
                rover.ObstableXCoordinate = xCoordinate;
                rover.ObstableYCoordinate = yCoordinate;
            }

            return rover;
        }

        public Boolean PlaceObstacleAt(Int32 xCoordinate, Int32 yCoordinate)
        {
            var validPlacement = ValidObstacleLocation(xCoordinate, yCoordinate);

            if (validPlacement)
                gridMap[xCoordinate, yCoordinate] = ObstacleSymbol;

            return validPlacement;
        }
        
        private Boolean MoveIsValid(MarsRover rover, Int32 xCoordinate, Int32 yCoordinate)
        {
            var xDiff = rover.XCoordinate - xCoordinate;
            var yDiff = rover.YCoordinate - yCoordinate;
            var yAxisMove = xDiff == 0 && Math.Abs(yDiff) == 1;
            var xAxisMove = Math.Abs(xDiff) == 1 && yDiff == 0;

            if (xAxisMove ^ yAxisMove)
                return true;

            return false;
        }

        private Boolean RoverCanBeMoved(Int32 xCoordinate, Int32 yCoordinate, Boolean obstacleFound)
        {
            return (active && ValidGridCoordinates(xCoordinate, yCoordinate) && obstacleFound) || !active;
        }

        private Boolean RoverCanBePlaced(Int32 xCoordinate, Int32 yCoordinate)
        {
            return active && ValidGridCoordinates(xCoordinate, yCoordinate) && NoObstacleAt(xCoordinate, yCoordinate) || !active;
        }

        private Boolean ValidObstacleLocation(Int32 xCoordinate, Int32 yCoordinate)
        {
            return ValidGridCoordinates(xCoordinate, yCoordinate) && gridMap[xCoordinate, yCoordinate] != RoverSymbol;
        }

        public Boolean XCoordinateOnOuterEdge(Int32 xCoordinate)
        {
            return xCoordinate == gridWidth || xCoordinate == NegativeBoundary;
        }

        public Boolean YCoordinateOnOuterEdge(Int32 yCoordinate)
        {
            return yCoordinate == gridHeight || yCoordinate == NegativeBoundary;
        }

        private Boolean ValidGridCoordinates(Int32 xCoordinate, Int32 yCoordinate)
        {
            return xCoordinate < gridWidth && xCoordinate >= GridMinimum && yCoordinate < gridHeight && yCoordinate >= GridMinimum;
        }

        private Boolean NoObstacleAt(Int32 xCoordinate, Int32 yCoordinate)
        {
            return ValidGridCoordinates(xCoordinate, yCoordinate) && gridMap[xCoordinate, yCoordinate] != ObstacleSymbol;
        }

        public String GridToString()
        {
            var mapString = "";

            if (active)
            {
                for (var i = gridHeight - 1; i >= 0; i--)
                {
                    for (var j = 0; j < gridWidth; j++)
                    {
                        var loc = gridMap[j, i];
                        if (!loc.Equals(ObstacleSymbol) && !loc.Equals(VisitedSymbol) && !loc.Equals(RoverSymbol))
                            mapString += '_';
                        else
                            mapString += loc;
                    }
                    mapString += '\n';
                }
                    
                return mapString;
            }

            return "Cannot print map for inactive grid with no dimensions";
        }
    }
}
