using System;
using System.Collections.Generic;
using System.Text;
using GameBoard;
using GameBoard.Enum;
using Game;

namespace ChessPieces
{
    internal class Pawn : Piece
    {
        private GameLogic game;
        public Pawn(Color color, Board board, GameLogic game) : base(color, board)
        {
            this.game = game;
        }

        public override string ToString()
        {
            return "P";
        }

        private Position PossiblePositionWhite(string move)
        {
            switch (move)
            {
                case "up":
                    return new Position(Position.Rank - 1, Position.Column);
                case "2up":
                    return new Position(Position.Rank - 2, Position.Column);
                case "up-right":
                    return new Position(Position.Rank - 1, Position.Column + 1);
                case "up-left":
                    return new Position(Position.Rank - 1, Position.Column - 1);
                default:
                    return null;
            }
        }

        private Position PossiblePositionBlack(string move)
        {
            switch (move)
            {
                case "up":
                    return new Position(Position.Rank + 1, Position.Column);
                case "2up":
                    return new Position(Position.Rank + 2, Position.Column);
                case "up-right":
                    return new Position(Position.Rank + 1, Position.Column - 1);
                case "up-left":
                    return new Position(Position.Rank + 1, Position.Column + 1);
                default:
                    return null;
            }
        }

        private bool canMove(Position position)
        {
            Piece p = Board.piece(position);
            return p == null;
        }

        private bool firstMove()
        {
            return QtdMov == 0;
        }

        private bool oppositePiece(Position position)
        {
            Piece p = Board.piece(position);
            return p != null && p.Color != Color;
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] possiblePositions = new bool[Board.Rank, Board.Column];

            Position tester;
            if (Color == Color.White)
            {
                tester = PossiblePositionWhite("up");
                if (Board.TestPosition(tester) && canMove(tester))
                {
                    possiblePositions[tester.Rank, tester.Column] = true;
                }

                tester = PossiblePositionWhite("2up");
                if (Board.TestPosition(tester) && canMove(tester) && firstMove())
                {
                    possiblePositions[tester.Rank, tester.Column] = true;
                }

                tester = PossiblePositionWhite("up-right");
                if (Board.TestPosition(tester) && oppositePiece(tester))
                {
                    possiblePositions[tester.Rank, tester.Column] = true;
                }

                tester = PossiblePositionWhite("up-left");
                if (Board.TestPosition(tester) && oppositePiece(tester))
                {
                    possiblePositions[tester.Rank, tester.Column] = true;
                }

                //En passant
                if(Position.Rank == 3)
                {
                    Position left = new Position(Position.Rank, Position.Column - 1);
                    if(Board.TestPosition(left) && oppositePiece(left) && Board.piece(left) == game.CanSufferEnPassant)
                    {
                        possiblePositions[Position.Rank - 1, Position.Column - 1] = true;
                    }
                    Position right = new Position(Position.Rank, Position.Column + 1);
                    if (Board.TestPosition(right) && oppositePiece(right) && Board.piece(right) == game.CanSufferEnPassant)
                    {
                        possiblePositions[Position.Rank - 1, Position.Column + 1] = true;
                    }
                }

            } else
            {
                tester = PossiblePositionBlack("up");
                if (Board.TestPosition(tester) && canMove(tester))
                {
                    possiblePositions[tester.Rank, tester.Column] = true;
                }

                tester = PossiblePositionBlack("2up");
                if (Board.TestPosition(tester) && canMove(tester) && firstMove())
                {
                    possiblePositions[tester.Rank, tester.Column] = true;
                }

                tester = PossiblePositionBlack("up-right");
                if (Board.TestPosition(tester) && oppositePiece(tester))
                {
                    possiblePositions[tester.Rank, tester.Column] = true;
                }

                tester = PossiblePositionBlack("up-left");
                if (Board.TestPosition(tester) && oppositePiece(tester))
                {
                    possiblePositions[tester.Rank, tester.Column] = true;
                }

                //En passant
                if (Position.Rank == 4)
                {
                    Position left = new Position(Position.Rank, Position.Column - 1);
                    if (Board.TestPosition(left) && oppositePiece(left) && Board.piece(left) == game.CanSufferEnPassant)
                    {
                        possiblePositions[Position.Rank + 1, Position.Column - 1] = true;
                    }
                    Position right = new Position(Position.Rank, Position.Column + 1);
                    if (Board.TestPosition(right) && oppositePiece(right) && Board.piece(right) == game.CanSufferEnPassant)
                    {
                        possiblePositions[Position.Rank + 1, Position.Column + 1] = true;
                    }
                }
            }

            return possiblePositions;
        }
    }
}
