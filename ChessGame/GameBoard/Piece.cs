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

        public bool canMovePiece()
        {
            bool[,] temp = PossibleMoves();
            for(int i = 0; i < temp.GetLength(0); i++)
            {
                for(int j = 0; j < temp.GetLength(1); j++)
                {
                    if(temp[i,j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public abstract bool[,] PossibleMoves();


    }
}
