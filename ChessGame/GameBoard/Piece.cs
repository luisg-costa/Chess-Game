﻿using System;
using System.Collections.Generic;
using System.Text;
using GameBoard.Enum;

namespace GameBoard
{
    internal class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }

        public int QtdMov { get; protected set; }

        public Board Board { get; protected set; }

        public Piece(Position position, Color color, Board board)
        {
            Position = position;
            Color = color;
            QtdMov = 0;
            Board = board;
        }
    }
}
