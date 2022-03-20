﻿using System;
using System.Collections.Generic;
using System.Text;
using GameBoard;
using GameBoard.Enum;
using GameBoard.Exceptions;
using ChessPieces;

namespace Game
{
    internal class GameLogic
    {
        public Board Board { get; private set; }
        public bool GameEnded { get; set; }
        public int Turn { get; private set; }
        public Color CurrentPlayer { get; private set; }

        private HashSet<Piece> OnGamePieces;

        private HashSet<Piece> OffGamePieces;

        public GameLogic()
        {
            Board = new Board(8, 8);
            Turn = 1;
            CurrentPlayer = Color.White;
            GameEnded = false;
            OnGamePieces = new HashSet<Piece>();
            OffGamePieces = new HashSet<Piece>();
            PutPiecesInPlace();
        }

        private void ChangePlayer()
        {
            if (CurrentPlayer == Color.White)
            {
                CurrentPlayer = Color.Black;
            }
            else
            {
                CurrentPlayer = Color.White;
            }
        }

        private Color OpponentColor(Color color)
        {
            if (color == Color.White)
            {
                return Color.Black;
            }
            else
            {
                return Color.White;
            }
        }

        private Piece GetKing(Color color)
        {
            foreach (Piece x in OnGamePieces)
            {
                if (x.Color == color)
                {
                    if (x is King)
                    {
                        return x;
                    }
                }
            }
            return null;
        }

        public bool CheckTest(Color color, Position destination)
        {
            bool[,] temp;
            Piece k = GetKing(color);
            if (k == null)
            {
                destination = null;
            }
            Console.WriteLine("DESTINATION" + destination);
            foreach (Piece piece in OnGamePieces)
            {
                if (piece.Color == OpponentColor(color))
                {
                    temp = piece.PossibleMoves();

                    if (destination == null)
                    {
                        if (temp[k.Position.Rank, k.Position.Column])
                        {
                            return true;
                        }
                    }
                    else
                    {
                        if (temp[destination.Rank, destination.Column])
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public HashSet<Piece> OffGamePiecesByColor(Color color)
        {
            HashSet<Piece> p = new HashSet<Piece>();
            foreach (Piece capturedP in OffGamePieces)
            {
                if (capturedP.Color == color)
                {
                    p.Add(capturedP);
                }
            }
            return p;
        }

        public bool WillMakeCheckWithMove(Position origin, Position destination)
        {
            Piece p = Board.RemovePiece(origin);
            if (!(p is King))
            {
                if (CheckTest(CurrentPlayer, null))
                {
                    Board.AddPiece(p, origin);
                    return true;
                }
            }
            else
            {
                if (CheckTest(CurrentPlayer, destination))
                {
                    Board.AddPiece(p, origin);
                    return true;
                }
            }

            Board.AddPiece(p, origin);
            return false;

        }

        public bool TestCheckMate(Color color, Position destination)
        {
            bool[,] temp;
            if (!CheckTest(color, destination))
            {
                return false;
            }
            foreach (Piece p in OnGamePieces)
            {
                if (p.Color == color)
                {
                    temp = p.PossibleMoves();
                    for (int i = 0; i < Board.Rank; i++)
                    {
                        for (int j = 0; j < Board.Column; j++)
                        {
                            if (temp[i, j])
                            {
                                if (!WillMakeCheckWithMove(p.Position, new Position(i, j)))
                                {
                                    return false;
                                }
                            }
                        }
                    }
                }
            }
            return true;
        }

        public void MakeMovement(Position origin, Position destination)
        {
            if (!TestCheckMate(CurrentPlayer, destination))
            {
                if (!WillMakeCheckWithMove(origin, destination))
                {
                    Piece inPositionPiece = Board.RemovePiece(origin);
                    inPositionPiece.AddMovement();
                    Piece capturedPiece = Board.RemovePiece(destination);
                    if (capturedPiece != null)
                    {
                        OffGamePieces.Add(capturedPiece);
                        OnGamePieces.Remove(capturedPiece);
                    }
                    Board.AddPiece(inPositionPiece, destination);
                }
                else
                {
                    throw new PositionException("You can't make that move. You would be in check");
                }
            }
            else
            {
                GameEnded = true;
            }
        }

        public void Move(Position origin, Position destination)
        {
            MakeMovement(origin, destination);
            Turn++;
            ChangePlayer();
        }

        public void validateOriginPosition(Position origin)
        {
            if (Board.piece(origin) == null)
            {
                throw new PositionException("There is no piece in that position.");
            }
            if (!Board.piece(origin).canMovePiece())
            {
                throw new PositionException("There are no possible moves for this piece.");
            }
            if (CurrentPlayer != Board.piece(origin).Color)
            {
                throw new PieceException("You can't move pieces that are not yours.");
            }

        }

        public void validateDestinationPosition(bool[,] possibleMoves, Position destination)
        {
            if (!possibleMoves[destination.Rank, destination.Column])
            {
                throw new PositionException("That move is not valid.");
            }
        }

        private void insertPiece(Piece p, char r, int c)
        {
            Board.AddPiece(p, Position.RealToMatrixPosition(r, c));
            OnGamePieces.Add(p);
        }

        private void PutPiecesInPlace()
        {
            //WHITE PIECES
            insertPiece(new Rook(Color.White, Board), 'a', 1);
            insertPiece(new Rook(Color.White, Board), 'h', 1);
            /*
            Board.AddPiece(new Knight(Color.White, Board), Position.RealToMatrixPosition('b', 1));
            Board.AddPiece(new Knight(Color.White, Board), Position.RealToMatrixPosition('g', 1));
            Board.AddPiece(new Bishop(Color.White, Board), Position.RealToMatrixPosition('c', 1));
            Board.AddPiece(new Bishop(Color.White, Board), Position.RealToMatrixPosition('f', 1));
            */
            insertPiece(new King(Color.White, Board), 'd', 1);
            /*
            Board.AddPiece(new Queen(Color.White, Board), Position.RealToMatrixPosition('e', 1));
            Board.AddPiece(new Pawn(Color.White, Board), Position.RealToMatrixPosition('a', 2));
            Board.AddPiece(new Pawn(Color.White, Board), Position.RealToMatrixPosition('b', 2));
            Board.AddPiece(new Pawn(Color.White, Board), Position.RealToMatrixPosition('c', 2));
            Board.AddPiece(new Pawn(Color.White, Board), Position.RealToMatrixPosition('d', 2));
            Board.AddPiece(new Pawn(Color.White, Board), Position.RealToMatrixPosition('e', 2));
            Board.AddPiece(new Pawn(Color.White, Board), Position.RealToMatrixPosition('f', 2));
            Board.AddPiece(new Pawn(Color.White, Board), Position.RealToMatrixPosition('g', 2));
            Board.AddPiece(new Pawn(Color.White, Board), Position.RealToMatrixPosition('h', 2));
            */

            //BLACK PIECES
            insertPiece(new Rook(Color.Black, Board), 'a', 8);
            insertPiece(new Rook(Color.Black, Board), 'h', 8);
            /*
            Board.AddPiece(new Knight(Color.Black, Board), Position.RealToMatrixPosition('b', 8));
            Board.AddPiece(new Knight(Color.Black, Board), Position.RealToMatrixPosition('g', 8));
            Board.AddPiece(new Bishop(Color.Black, Board), Position.RealToMatrixPosition('c', 8));
            Board.AddPiece(new Bishop(Color.Black, Board), Position.RealToMatrixPosition('f', 8));
            */
            insertPiece(new King(Color.Black, Board), 'd', 8);
            /*
            Board.AddPiece(new Queen(Color.Black, Board), Position.RealToMatrixPosition('e', 8));
            Board.AddPiece(new Pawn(Color.Black, Board), Position.RealToMatrixPosition('a', 7));
            Board.AddPiece(new Pawn(Color.Black, Board), Position.RealToMatrixPosition('b', 7));
            Board.AddPiece(new Pawn(Color.Black, Board), Position.RealToMatrixPosition('c', 7));
            Board.AddPiece(new Pawn(Color.Black, Board), Position.RealToMatrixPosition('d', 7));
            Board.AddPiece(new Pawn(Color.Black, Board), Position.RealToMatrixPosition('e', 7));
            Board.AddPiece(new Pawn(Color.Black, Board), Position.RealToMatrixPosition('f', 7));
            Board.AddPiece(new Pawn(Color.Black, Board), Position.RealToMatrixPosition('g', 7));
            Board.AddPiece(new Pawn(Color.Black, Board), Position.RealToMatrixPosition('h', 7));
            */
        }
    }
}
