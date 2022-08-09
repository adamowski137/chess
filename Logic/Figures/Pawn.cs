using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using chess137.Chess;

namespace chess137.Figures
{
    internal class Pawn : Figure
    {
        public Pawn(int posX, int posY, bool isW)
        {
            position = new Position(posX, posY);
            isWhite = isW;
            value = 1;
            name = Const.pawnName;
            moves = positionsAvailableToMove();
            firstMove = true;
        }


        public override List<Position> positionsAvailableToMove()
        {
            List<Position> positionsAvailableToMove = new List<Position>();
            if (isWhite)
            {
                if (firstMove)
                {
                    positionsAvailableToMove.Add(new Position(position!.x + 2, position.y));
                }
                if (position!.x + 1 < Const.height)
                {
                    positionsAvailableToMove.Add(new Position(position.x + 1, position.y));
                }
                if (position.y + 1 < Const.width && position.x + 1 < Const.height)
                {
                    positionsAvailableToMove.Add(new Position(position.x + 1, position.y + 1));
                }
                if (position.x + 1 < Const.height && position.y - 1 >= 0)
                {
                    positionsAvailableToMove.Add(new Position(position.x + 1, position.y - 1));
                }
            }

            else
            {
                if (firstMove)
                {
                    positionsAvailableToMove.Add(new Position(position!.x - 2, position.y));
                }
                if (position!.x - 1 >= 0)
                {
                    positionsAvailableToMove.Add(new Position(position.x - 1, position.y));
                }
                if (position.x - 1 >= 0 && position.y + 1 < Const.width)
                {
                    positionsAvailableToMove.Add(new Position(position.x - 1, position.y + 1));
                }
                if (position.y - 1 >= 0 && position.x - 1 >= 0)
                {
                    positionsAvailableToMove.Add(new Position(position.x - 1, position.y - 1));
                }
            }
            return positionsAvailableToMove;
        }
        public override Pawn copyFigure()
        {
            Pawn copy = new Pawn(this.position.x, this.position.y, isWhite);
            if (getMoves() != null)
            {
                copy.moves = new List<Position>();
                getMoves().ForEach(x => copy.moves.Add(new Position(x.x, x.y)));

            }
            return copy;
        }
    }
}
