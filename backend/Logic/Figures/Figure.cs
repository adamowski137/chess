﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using chess137.Figures;
using chess137.Chess;

namespace chess137.Figures
{
    public class Figure
    {
        protected bool ableTocastle;
        protected Position? position;
        protected bool isWhite;
        protected int value;
        protected string? name;
        public List<Position> moves;
        protected bool firstMove;

        public Position getPosition()
        {
            return position!;
        }
        public bool isFirstMove()
        {
            return firstMove;
        }
        public bool getColor()
        {
            return isWhite;
        }
        public int getValue()
        {
            return value;
        }

        public void setPosition(Position position)
        {
            this.position = position;
        }
        public void setColor(bool isW)
        {
            this.isWhite = isW;
        }

        public string getName()
        {
            return name!;
        }
        public void setMoved() { this.firstMove = false; }

        public virtual Figure copyFigure() { return null; }
        public virtual List<Position> positionsAvailableToMove() { return null; }
        public List<Position> getMoves() { return moves; }
        public List <Position> updateMoves(Chessboard chessboard)
        {
            moves = positionsAvailableToMove();
            moves = Functions.removeOccupiedMoves(this, chessboard);
            int i = 1;
            if (moves != null) i = moves.Count;
            moves = Functions.removeIllegalMoves(this, chessboard);
            if (i != null && moves != null && i > moves.Count)
                i = 1;
           return moves;
        }
    }
}
