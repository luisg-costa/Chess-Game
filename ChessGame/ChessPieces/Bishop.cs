using System;
using System.Collections.Generic;
using System.Text;
using GameBoard;
using GameBoard.Enum;

namespace ChessPieces
{
    internal class Bishop : Piece
    {
        public Bishop(Color color, Board board) : base(color, board)
        {

        }

        public override string ToString()
        {
            return "B";
        }


        public override bool[,] PossibleMoves()
        {
            bool[,] possibleMoves = new bool[Board.Rank, Board.Column];
            

            return possibleMoves;
        }
    }
}
