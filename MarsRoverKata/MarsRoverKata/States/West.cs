using System;

namespace MarsRoverKata.States
{
    public class West : IDirectionState
    {
        public Char Direction { get { return 'W'; } }

        public Int32 VerticalDistance()
        {
            return 0;
        }

        public Int32 HorizontalDistance()
        {
            return -1;
        }

        public IDirectionState rightTurn()
        {
            return new North();
        }

        public IDirectionState leftTurn()
        {
            return new South();
        }
    }
}
