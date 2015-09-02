using System;

namespace MarsRoverKata.States
{
    public class South : IDirectionState
    {
        public Char Direction { get { return 'S'; } }

        public Int32 VerticalDistance()
        {
            return -1;
        }

        public Int32 HorizontalDistance()
        {
            return 0;
        }

        public IDirectionState rightTurn()
        {
            return new West();
        }

        public IDirectionState leftTurn()
        {
            return new East();
        }
    }
}
