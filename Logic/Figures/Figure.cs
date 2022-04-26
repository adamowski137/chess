using System;
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
        protected Position? position;
        protected bool isWhite;
        protected int value;
        protected string? name;
        protected int Id;
        public List<Position> moves;

        public Position getPosition()
        {
            return position!;
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
        public int getId()
        {
            return Id;
        }

        public virtual List<Position> positionsAvailableToMove() { return null; }
        public List<Position> getMoves() { return moves; }
        public List <Position> updateMoves(Chessboard chessboard)
        {
            moves = positionsAvailableToMove();
            moves = Functions.removeOccupiedMoves(this, chessboard);
           // moves = Functions.removeIllegalMoves(isWhite, chessboard, positionsAvailableToMove(), this);
           return moves;
        }
    }
}
