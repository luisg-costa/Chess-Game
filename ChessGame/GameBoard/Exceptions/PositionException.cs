using System;


namespace GameBoard.Exceptions
{
    internal class PositionException : ApplicationException
    {
        public PositionException(string message) : base(message) { }
    }
}
