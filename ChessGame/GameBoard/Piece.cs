using System;
using System.Collections.Generic;
using System.Text;
using GameBoard.Enum;

namespace GameBoard
{
    abstract class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }

        public int QtdMov { get; protected set; }

        public Board Board { get; protected set; }

        public Piece(Color color, Board board)
        {
            Position = null;
            Color = color;
            QtdMov = 0;
            Board = board;
        }

        public void AddMovement()
        {
            QtdMov++;
        }

        public abstract bool[,] PossibleMoves();


    }
}
