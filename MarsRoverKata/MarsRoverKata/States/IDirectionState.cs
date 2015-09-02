using System;

namespace MarsRoverKata
{
    public interface IDirectionState
    {
        Char Direction { get; }
        Int32 VerticalDistance();
        Int32 HorizontalDistance();
        IDirectionState rightTurn();
        IDirectionState leftTurn();
    }
}
