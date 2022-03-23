using System;
using System.Collections.Generic;
using System.Text;
using GameBoard;
using GameBoard.Enum;

namespace ChessPieces
{
    internal class Pawn : Piece
    {
        public Pawn(Color color, Board board) : base(color, board)
        {

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
            }

            return possiblePositions;
        }
    }
}
