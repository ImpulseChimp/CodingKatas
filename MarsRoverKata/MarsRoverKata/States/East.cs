using System;

namespace MarsRoverKata.States
{
    public class East : IDirectionState
    {
        public Char Direction { get { return 'E'; } }

        public Int32 VerticalDistance()
        {
            return 0;
        }

        public Int32 HorizontalDistance()
        {
            return 1;
        }

        public IDirectionState rightTurn()
        {
            return new South();
        }

        public IDirectionState leftTurn()
        {
            return new North();
        }
    }
}
