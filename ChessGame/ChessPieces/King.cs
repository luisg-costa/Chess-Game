using System;
using System.Collections.Generic;
using System.Text;
using GameBoard;
using GameBoard.Enum;

namespace ChessPieces
{
    internal class King : Piece
    {
        public King(Color color, Board board) : base(color, board)
        {

        }

        public override string ToString()
        {
            return "K";
        }

        private Position PossiblePosition(string move)
        {
            switch (move)
            {
                case "up":
                    return new Position(Position.Rank - 1, Position.Column);
                case "down":
                    return new Position(Position.Rank + 1, Position.Column);
                case "left":
                    return new Position(Position.Rank, Position.Column - 1);
                case "right":
                    return new Position(Position.Rank, Position.Column + 1);
                case "up-right":
                    return new Position(Position.Rank - 1, Position.Column + 1);
                case "up-left":
                    return new Position(Position.Rank - 1, Position.Column - 1);
                case "down-right":
                    return new Position(Position.Rank + 1, Position.Column + 1);
                case "down-left":
                    return new Position(Position.Rank + 1, Position.Column - 1);
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

            //up
            Position tester = PossiblePosition("up");
            if (Board.TestPosition(tester) && canMove(tester))
            {
                possiblePositions[tester.Rank, tester.Column] = true;
            }

            //down
            tester = PossiblePosition("down");
            if (Board.TestPosition(tester) && canMove(tester))
            {
                possiblePositions[tester.Rank, tester.Column] = true;
            }

            //left
            tester = PossiblePosition("left");
            if (Board.TestPosition(tester) && canMove(tester))
            {
                possiblePositions[tester.Rank, tester.Column] = true;
            }

            //rigth
            tester = PossiblePosition("right");
            if (Board.TestPosition(tester) && canMove(tester))
            {
                possiblePositions[tester.Rank, tester.Column] = true;
            }

            //up - right
            tester = PossiblePosition("up-right");
            if (Board.TestPosition(tester) && canMove(tester))
            {
                possiblePositions[tester.Rank, tester.Column] = true;
            }
            //up - left
            tester = PossiblePosition("up-left");
            if (Board.TestPosition(tester) && canMove(tester))
            {
                possiblePositions[tester.Rank, tester.Column] = true;
            }
            //down - right
            tester = PossiblePosition("down-right");
            if (Board.TestPosition(tester) && canMove(tester))
            {
                possiblePositions[tester.Rank, tester.Column] = true;
            }
            //down - left
            tester = PossiblePosition("down-left");
            if (Board.TestPosition(tester) && canMove(tester))
            {
                possiblePositions[tester.Rank, tester.Column] = true;
            }

            return possiblePositions;
        }
    }
}
