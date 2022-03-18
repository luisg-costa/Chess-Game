using System;
using System.Collections.Generic;
using System.Text;


namespace GameBoard
{
    internal class RealBoardPosition
    {
        public int Rank { get; set; }
        public char Column { get; set; }

        public RealBoardPosition(char column, int rank)
        {
            Column = column; 
            Rank = rank;
        }

        public override string ToString()
        {
            return "" + Column + Rank;
        }

        public Position ToMatrixPosition()
        {
            return new Position(8 - Rank, Column - 'a');
        }
    }
}
