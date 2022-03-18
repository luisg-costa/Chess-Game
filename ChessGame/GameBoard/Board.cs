using System;
using System.Collections.Generic;
using System.Text;
using GameBoard.Exceptions;

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

        public Piece piece(Position pos)
        {
            return pieces[pos.Rank, pos.Column];
        }

        public void AddPiece(Piece piece, Position position)
        {
            if (ExistsPiece(position))
            {
                throw new PositionException("Already have a piece in that position");
            }
            pieces[position.Rank,position.Column] = piece;
            piece.Position = position;
        }

        private bool TestPosition(Position pos)
        {
            return Rank > pos.Rank && Column > pos.Column  ? true : false;
        }

        public void ValidPosition(Position pos)
        {
            if (!TestPosition(pos))
            {
                throw new PositionException("Invalid position");
            }
        }

        public bool ExistsPiece(Position pos)
        {
            ValidPosition(pos);
            return piece(pos) != null;
        }

    }
}
