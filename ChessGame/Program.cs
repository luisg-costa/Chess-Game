using System;
using GameBoard;

namespace ChessGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board(8, 8);
            BoardPrinter.PrintBoard(board);
            Console.WriteLine();
        } 
    }
}
