using System;
using System.Collections.Generic;
using System.Text;
using GameBoard;
using GameBoard.Enum;
using Game;

namespace ChessPieces
{
    internal class King : Piece
    {
        private GameLogic game;
        public King(Color color, Board board, GameLogic game) : base(color, board)
        {
            this.game = game;
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

        private bool existsPiece(Position position)
        {
            Piece p = Board.piece(position);
            return p == null;
        }

        private bool PossibleCastleKingside(Position position)
        {
            Piece rook = Board.piece(position.Rank, position.Column + 3);
            return rook != null && rook is Rook && rook.Color == Color && rook.QtdMov == 0
                && Board.piece(rook.Position.Rank, rook.Position.Column - 1) == null && Board.piece(rook.Position.Rank, rook.Position.Column - 2) == null;
        }

        private bool PossibleCastleQueenside(Position position)
        {
            Piece rook = Board.piece(position.Rank, position.Column - 4);
            return rook != null && rook is Rook && rook.Color == Color && rook.QtdMov == 0
                && Board.piece(rook.Position.Rank, rook.Position.Column + 1) == null && Board.piece(rook.Position.Rank, rook.Position.Column + 2) == null
                && Board.piece(rook.Position.Rank, rook.Position.Column + 3) == null;
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

            if (!game.Check && QtdMov == 0)
            {
                //Castle Kingside
                Console.WriteLine("Positionking: " + Position.Rank + " " + Position.Column );
                if (PossibleCastleKingside(Position))
                {
                    possiblePositions[Position.Rank, Position.Column + 2] = true;
                }

                //Castle Queenside
                if (PossibleCastleQueenside(Position))
                {
                    possiblePositions[Position.Rank, Position.Column - 2] = true;
                }
            }

            return possiblePositions;
        }
    }
}
