using System;
using System.Collections.Generic;
using System.Text;
using GameBoard;
using GameBoard.Enum;
using ChessPieces;

namespace Game
{
    internal class GameLogic
    {
        public Board Board { get; private set; }
        public bool GameEnded  { get; set; }
        private int Turn;
        private Color CurrentPlayer;


        public GameLogic()
        {
            Board = new Board(8, 8);
            Turn = 1;
            CurrentPlayer = Color.White;
            GameEnded = false;
            PutPiecesInPlace();
        }

        public void MakeMovement(Position origin, Position destination)
        {
            Piece inPositionPiece = Board.RemovePiece(origin);
            inPositionPiece.AddMovement();
            Piece capturedPiece = Board.RemovePiece(destination);
            Board.AddPiece(inPositionPiece, destination);
        }

        private void PutPiecesInPlace()
        {
            //WHITE PIECES
            Board.AddPiece(new Rook(Color.White, Board), Position.RealToMatrixPosition('a',1));
            Board.AddPiece(new Rook(Color.White, Board), Position.RealToMatrixPosition('h', 1));
            Board.AddPiece(new Knight(Color.White, Board), Position.RealToMatrixPosition('b', 1));
            Board.AddPiece(new Knight(Color.White, Board), Position.RealToMatrixPosition('g', 1));
            Board.AddPiece(new Bishop(Color.White, Board), Position.RealToMatrixPosition('c', 1));
            Board.AddPiece(new Bishop(Color.White, Board), Position.RealToMatrixPosition('f', 1));
            Board.AddPiece(new King(Color.White, Board), Position.RealToMatrixPosition('d', 1));
            Board.AddPiece(new Queen(Color.White, Board), Position.RealToMatrixPosition('e', 1));
            Board.AddPiece(new Pawn(Color.White, Board), Position.RealToMatrixPosition('a', 2));
            Board.AddPiece(new Pawn(Color.White, Board), Position.RealToMatrixPosition('b', 2));
            Board.AddPiece(new Pawn(Color.White, Board), Position.RealToMatrixPosition('c', 2));
            Board.AddPiece(new Pawn(Color.White, Board), Position.RealToMatrixPosition('d', 2));
            Board.AddPiece(new Pawn(Color.White, Board), Position.RealToMatrixPosition('e', 2));
            Board.AddPiece(new Pawn(Color.White, Board), Position.RealToMatrixPosition('f', 2));
            Board.AddPiece(new Pawn(Color.White, Board), Position.RealToMatrixPosition('g', 2));
            Board.AddPiece(new Pawn(Color.White, Board), Position.RealToMatrixPosition('h', 2));


            //BLACK PIECES
            Board.AddPiece(new Rook(Color.Black, Board), Position.RealToMatrixPosition('a', 8));
            Board.AddPiece(new Rook(Color.Black, Board), Position.RealToMatrixPosition('h', 8));
            Board.AddPiece(new Knight(Color.Black, Board), Position.RealToMatrixPosition('b', 8));
            Board.AddPiece(new Knight(Color.Black, Board), Position.RealToMatrixPosition('g', 8));
            Board.AddPiece(new Bishop(Color.Black, Board), Position.RealToMatrixPosition('c', 8));
            Board.AddPiece(new Bishop(Color.Black, Board), Position.RealToMatrixPosition('f', 8));
            Board.AddPiece(new King(Color.Black, Board), Position.RealToMatrixPosition('d', 8));
            Board.AddPiece(new Queen(Color.Black, Board), Position.RealToMatrixPosition('e', 8));
            Board.AddPiece(new Pawn(Color.Black, Board), Position.RealToMatrixPosition('a', 7));
            Board.AddPiece(new Pawn(Color.Black, Board), Position.RealToMatrixPosition('b', 7));
            Board.AddPiece(new Pawn(Color.Black, Board), Position.RealToMatrixPosition('c', 7));
            Board.AddPiece(new Pawn(Color.Black, Board), Position.RealToMatrixPosition('d', 7));
            Board.AddPiece(new Pawn(Color.Black, Board), Position.RealToMatrixPosition('e', 7));
            Board.AddPiece(new Pawn(Color.Black, Board), Position.RealToMatrixPosition('f', 7));
            Board.AddPiece(new Pawn(Color.Black, Board), Position.RealToMatrixPosition('g', 7));
            Board.AddPiece(new Pawn(Color.Black, Board), Position.RealToMatrixPosition('h', 7));
        }
    }
}
