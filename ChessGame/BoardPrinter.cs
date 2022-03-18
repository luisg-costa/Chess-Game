using System;
using System.Collections.Generic;
using System.Text;
using GameBoard;

namespace ChessGame
{
    internal class BoardPrinter
    {
        public static void PrintBoard(Board board)
        {
            for (int i = 0; i < board.Rank; i++)
            {
                for (int j = 0; j < board.Column; j++)
                {   
                    if(board.piece(i,j) == null)
                    {
                        Console.Write("- ");
                    }
                    else {
                        Console.Write(board.piece(i, j) + " ");
                    }
                    
                }
                Console.WriteLine();
            }

        }
    }
}
