using System;
using System.Collections.Generic;
using System.Text;
using GameBoard;
using GameBoard.Enum;

namespace ChessPieces
{
    internal class Queen : Piece
    {
        public Queen(Color color, Board board) : base(color, board)
        {

        }

        public override string ToString()
        {
            return "Q";
        }

        public override bool[,] PossibleMoves() { return null; }
    }
}
