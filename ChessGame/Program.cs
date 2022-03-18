using System;
using GameBoard;
using GameBoard.Enum;
using ChessPieces;

namespace ChessGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board(8, 8);
            board.AddPiece(new King(Color.Black, board), new Position(0,1));
            board.ValidPosition(new Position(9, 6));
            
            BoardPrinter.PrintBoard(board);


            Console.WriteLine();
        } 
    }
}
