using System;

namespace MarsRoverKata.States
{
    public class Invalid : IDirectionState
    {
        public Char Direction { get { return 'X'; } }

        public Int32 VerticalDistance()
        {
            return 0;
        }

        public Int32 HorizontalDistance()
        {
            return 0;
        }

        public IDirectionState rightTurn()
        {
            return new Invalid();
        }

        public IDirectionState leftTurn()
        {
            return new Invalid();
        }
    }
}
