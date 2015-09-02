using System;

namespace MarsRoverKata.States
{
    public class North : IDirectionState
    {
        public Char Direction { get { return 'N'; } }

        public Int32 VerticalDistance()
        {
            return 1;
        }

        public Int32 HorizontalDistance()
        {
            return 0;
        }

        public IDirectionState rightTurn()
        {
            return new East();
        }

        public IDirectionState leftTurn()
        {
            return new West();
        }
    }
}
