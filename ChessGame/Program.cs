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
                    try
                    {
                        Console.Clear();
                        BoardPrinter.PrintBoard(game.Board);
                        Console.WriteLine("Turn: " + game.Turn);
                        Console.WriteLine($"Waiting for {game.CurrentPlayer.ToString().ToUpper()} to play");

                        Console.Write("Enter the starting position: ");
                        Position origin = BoardPrinter.ReadPosition();
                        game.validateOriginPosition(origin);
                        bool[,] possibleMoves = game.Board.piece(origin).PossibleMoves();
                        Console.Clear();
                        BoardPrinter.PrintBoard(game.Board, possibleMoves);

                        Console.Write("Enter the final position: ");
                        Position destination = BoardPrinter.ReadPosition();
                        game.validateDestinationPosition(possibleMoves, destination);
                        game.Move(origin, destination);

                    }
                    catch (PositionException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                    catch (PieceException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }

            }
            catch (PositionException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (PieceException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
