using System;
using System.Collections.Generic;
using System.Text;
using GameBoard;
using GameBoard.Enum;

namespace ChessPieces
{
    internal class King : Piece
    {
        public King(Color color, Board board) : base(color, board)
        {

        }

        public override string ToString()
        {
            return "K";
        }
    }
}
