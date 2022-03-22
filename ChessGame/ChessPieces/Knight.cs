using System;
using System.Collections.Generic;
using System.Text;
using GameBoard;
using GameBoard.Enum;

namespace ChessPieces
{
    internal class Knight : Piece
    {
        public Knight(Color color, Board board) : base(color, board)
        {

        }

        public override string ToString()
        {
            return "N";
        }

        private Position PossiblePosition(string move)
        {
            switch (move)
            {
                case "up-right":
                    return new Position(Position.Rank - 1, Position.Column + 2);
                case "up-left":
                    return new Position(Position.Rank - 1, Position.Column - 2);
                case "down-right":
                    return new Position(Position.Rank + 1, Position.Column + 2);
                case "down-left":
                    return new Position(Position.Rank + 1, Position.Column - 2);
                case "2up-right":
                    return new Position(Position.Rank - 2, Position.Column + 1);
                case "2up-left":
                    return new Position(Position.Rank - 2, Position.Column - 1);
                case "2down-right":
                    return new Position(Position.Rank + 2, Position.Column + 1);
                case "2down-left":
                    return new Position(Position.Rank + 2, Position.Column - 1);
                default:
                    return null;
            }
        }

        private bool canMove(Position position)
        {
            Piece p = Board.piece(position);
            return p == null || p.Color != Color;
        }


        public override bool[,] PossibleMoves()
        {
            bool[,] possiblePositions = new bool[Board.Rank, Board.Column];

            Position tester = PossiblePosition("up-right");
            if (Board.TestPosition(tester) && canMove(tester))
            {
                possiblePositions[tester.Rank, tester.Column] = true;
            }

            tester = PossiblePosition("up-left");
            if (Board.TestPosition(tester) && canMove(tester))
            {
                possiblePositions[tester.Rank, tester.Column] = true;
            }

            tester = PossiblePosition("down-right");
            if (Board.TestPosition(tester) && canMove(tester))
            {
                possiblePositions[tester.Rank, tester.Column] = true;
            }

            tester = PossiblePosition("down-left");
            if (Board.TestPosition(tester) && canMove(tester))
            {
                possiblePositions[tester.Rank, tester.Column] = true;
            }

            tester = PossiblePosition("2up-right");
            if (Board.TestPosition(tester) && canMove(tester))
            {
                possiblePositions[tester.Rank, tester.Column] = true;
            }

            tester = PossiblePosition("2up-left");
            if (Board.TestPosition(tester) && canMove(tester))
            {
                possiblePositions[tester.Rank, tester.Column] = true;
            }

            tester = PossiblePosition("2down-right");
            if (Board.TestPosition(tester) && canMove(tester))
            {
                possiblePositions[tester.Rank, tester.Column] = true;
            }

            tester = PossiblePosition("2down-left");
            if (Board.TestPosition(tester) && canMove(tester))
            {
                possiblePositions[tester.Rank, tester.Column] = true;
            }

            return possiblePositions;
        }
    }
}

