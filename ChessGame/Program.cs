using System;
using GameBoard;
using GameBoard.Enum;
using ChessPieces;
using Game;
using GameBoard.Exceptions;

namespace ChessGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                GameLogic game = new GameLogic();

                while (!game.GameEnded)
                {
                    Console.Clear();
                    BoardPrinter.PrintBoard(game.Board);
                    Console.Write("Enter the starting position: ");
                    Position origin = BoardPrinter.ReadPosition();
                    bool[,] possibleMoves = game.Board.piece(origin).PossibleMoves();

                    Console.Clear();
                    BoardPrinter.PrintBoard(game.Board, possibleMoves);
                    Console.Write("Enter the final position: ");
                    Position destination = BoardPrinter.ReadPosition();
                    game.MakeMovement(origin, destination);
                    
                }

            }
            catch (PositionException e) {
                Console.WriteLine(e.Message);
            }
            
        } 
    }
}
