using System;
using System.Collections.Generic;
using System.Text;
using GameBoard;
using GameBoard.Enum;
using Game;

namespace ChessGame
{
    class BoardPrinter
    {
        public static void PrintGame(GameLogic game)
        {
            PrintBoard(game.Board);
            Console.WriteLine();
            Console.WriteLine("Captured Pieces:");
            Console.Write("White: ");
            PrintOffPieceSet(game.OffGamePiecesByColor(Color.White));
            Console.Write("Black: ");
            PrintOffPieceSet(game.OffGamePiecesByColor(Color.Black));
            Console.WriteLine();
            Console.WriteLine("Turn: " + game.Turn);
            if (!game.GameEnded) { 
            Console.WriteLine($"Waiting for {game.CurrentPlayer.ToString().ToUpper()} to play");
            }
            else
            {
                Console.WriteLine("CHECK-MATE!");
                Console.WriteLine("Winner: " + game.CurrentPlayer);
            }

        }

        private static void PrintOffPieceSet(HashSet<Piece> p)
        {
            Console.Write(" [ ");
            foreach (Piece piece in p)
            {
                Console.Write(piece.ToString() + " ");
            }
            Console.WriteLine("] ");
        }


        public static void PrintBoard(Board board)
        {
            for (int i = 0; i < board.Rank; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.Column; j++)
                {
                    Printer(board.piece(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");

        }

        public static void PrintBoard(Board board, bool[,] possibleMoves)
        {
            for (int i = 0; i < board.Rank; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.Column; j++)
                {
                    PrintPossibleMoves(possibleMoves[i, j]);
                    Printer(board.piece(i, j));
                }
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");

        }

        private static void Printer(Piece p)
        {
            if (p == null)
            {
                Console.Write("- ");
            }
            else
            {
                PrintPiece(p);

            }
        }

        private static void PrintPossibleMoves(bool move)
        {
            if (!move)
            {
                Console.BackgroundColor = ConsoleColor.Black;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Yellow;
            }

        }

        private static void PrintPiece(Piece piece)
        {
            if (piece.Color == Color.White)
            {
                Console.Write(piece + " ");
            }
            else
            {
                ConsoleColor temp = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(piece + " ");
                Console.ForegroundColor = temp;
            }
        }

        public static Position ReadPosition()
        {
            string positionReal = Console.ReadLine();
            char column = positionReal[0];
            int rank = int.Parse(positionReal[1] + "");
            return Position.RealToMatrixPosition(column, rank);
        }
    }
}
