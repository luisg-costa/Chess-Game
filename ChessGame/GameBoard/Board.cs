using System;
using System.Collections.Generic;
using System.Text;

namespace GameBoard
{
    internal class Board
    {
        public int Rank { get; set; }
        public int Column { get; set; }

        private Piece[,] pieces;

        public Board(int ranks, int columns)
        {
            Rank = ranks;
            Column = columns;
            pieces = new Piece[ranks, columns];
        }

        public Piece piece(int rank, int column)
        {
            return pieces[rank, column];
        }

        public void AddPiece(Piece piece, Position position)
        {
            pieces[position.Rank,position.Column] = piece;
            piece.Position = position;
        }
    }
}
