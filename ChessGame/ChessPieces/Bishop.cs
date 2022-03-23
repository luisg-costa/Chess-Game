using System;
using System.Collections.Generic;
using System.Text;
using GameBoard;
using GameBoard.Enum;

namespace ChessPieces
{
    internal class Bishop : Piece
    {
        public Bishop(Color color, Board board) : base(color, board)
        {

        }

        public override string ToString()
        {
            return "B";
        }


        private Position PossiblePosition(string move)
        {
            switch (move)
            {
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

            Position tester = PossiblePosition("up-right");
            while (Board.TestPosition(tester) && canMove(tester))
            {
                possiblePositions[tester.Rank, tester.Column] = true;
                if (Board.ExistsPiece(tester) && Board.piece(tester).Color != Color)
                {
                    break;
                }
                tester.Rank--;
                tester.Column++;
            }

            tester = PossiblePosition("up-left");
            while (Board.TestPosition(tester) && canMove(tester))
            {
                possiblePositions[tester.Rank, tester.Column] = true;
                if (Board.ExistsPiece(tester) && Board.piece(tester).Color != Color)
                {
                    break;
                }
                tester.Rank--;
                tester.Column--;
            }

            tester = PossiblePosition("down-right");
            while (Board.TestPosition(tester) && canMove(tester))
            {
                possiblePositions[tester.Rank, tester.Column] = true;
                if (Board.ExistsPiece(tester) && Board.piece(tester).Color != Color)
                {
                    break;
                }
                tester.Rank++;
                tester.Column++;
            }

            tester = PossiblePosition("down-left");
            while (Board.TestPosition(tester) && canMove(tester))
            {
                possiblePositions[tester.Rank, tester.Column] = true;
                if (Board.ExistsPiece(tester) && Board.piece(tester).Color != Color)
                {
                    break;
                }
                tester.Rank++;
                tester.Column--;
            }

            return possiblePositions;
        }
    }
}
