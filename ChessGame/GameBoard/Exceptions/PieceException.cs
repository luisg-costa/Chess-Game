using System;


namespace GameBoard.Exceptions
{
    internal class PieceException : ApplicationException
    {
        public PieceException(string message) : base(message) { }
    }
}
