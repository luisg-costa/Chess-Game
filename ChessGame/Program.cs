using System;
using GameBoard;

namespace ChessGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Position p = new Position(3, 4);

            Console.WriteLine("Position: " + p);

            Board board = new Board(8, 8);
            
            Console.WriteLine(board);
        } 
    }
}
