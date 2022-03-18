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
    }
}
