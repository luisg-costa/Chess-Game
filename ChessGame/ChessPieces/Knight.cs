using System;
using System.Collections.Generic;
using System.Text;
using GameBoard;
using GameBoard.Enum;

namespace ChessPieces
{
    internal class Knight : Piece
    {
        public Knight(Color color, Board board) : base(color, board)
        {

        }

        public override string ToString()
        {
            return "N";
        }
        public override bool[,] PossibleMoves() { return null; }
    }
}

