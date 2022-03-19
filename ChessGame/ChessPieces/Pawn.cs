using System;
using System.Collections.Generic;
using System.Text;
using GameBoard;
using GameBoard.Enum;

namespace ChessPieces
{
    internal class Pawn : Piece
    {
        public Pawn(Color color, Board board) : base(color, board)
        {

        }

        public override string ToString()
        {
            return "P";
        }

        public override bool[,] PossibleMoves() { return null; }
    }
}
