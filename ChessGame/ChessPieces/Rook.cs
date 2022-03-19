using System;
using System.Collections.Generic;
using System.Text;
using GameBoard;
using GameBoard.Enum;

namespace ChessPieces
{
    internal class Rook : Piece
    {
        public Rook(Color color, Board board) : base(color, board)
        {

        }

        public override string ToString()
        {
            return "R";
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
            while (Board.TestPosition(tester) && canMove(tester))
            {
                possiblePositions[tester.Rank, tester.Column] = true;
                if (Board.ExistsPiece(tester) && Board.piece(tester).Color != Color) {
                    break;
                }
                tester.Rank--;
            }

            //down
            tester = PossiblePosition("down");
            while (Board.TestPosition(tester) && canMove(tester))
            {
                possiblePositions[tester.Rank, tester.Column] = true;
                if (Board.ExistsPiece(tester) && Board.piece(tester).Color != Color)
                {
                    break;
                }
                tester.Rank++;
            }

            //left
            tester = PossiblePosition("left");
            while (Board.TestPosition(tester) && canMove(tester))
            {
                possiblePositions[tester.Rank, tester.Column] = true;
                if (Board.ExistsPiece(tester) && Board.piece(tester).Color != Color)
                {
                    break;
                }
                tester.Column--;
            }

            //rigth
            tester = PossiblePosition("right");
            while (Board.TestPosition(tester) && canMove(tester))
            {
                possiblePositions[tester.Rank, tester.Column] = true;
                if (Board.ExistsPiece(tester) && Board.piece(tester).Color != Color)
                {
                    break;
                }
                tester.Column++;
            }

            return possiblePositions;
        }
    }
}
