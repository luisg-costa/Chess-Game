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

        public Piece RemovePiece(Position position)
        {
            if (piece(position) == null) return null;
            Piece tPiece = piece(position);
            tPiece.Position = null;
            pieces[position.Rank,position.Column] = null;
            return tPiece;
        }

        private bool TestPosition(Position position)
        {
            return Rank > position.Rank && Column > position.Column  ? true : false;
        }

        public void ValidPosition(Position position)
        {
            if (!TestPosition(position))
            {
                throw new PositionException("Invalid position");
            }
        }

        public bool ExistsPiece(Position position)
        {
            ValidPosition(position);
            return piece(position) != null;
        }

    }
}
