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
        private bool firstMove;
        public Pawn(int posX, int posY, bool isW, int id)
        {
            position = new Position(posX, posY);
            firstMove = true;
            isWhite = isW;
            value = 1;
            name = Const.pawnName;
            Id = id;
            moves = positionsAvailableToMove();
        }

        public bool isFirstMove()
        {
            return firstMove;
        }

       public override List<Position> positionsAvailableToMove()
        {
            List<Position> positionsAvailableToMove = new List<Position>();
            if (isWhite)
            {
                if (isFirstMove())
                {
                    positionsAvailableToMove.Add(new Position(position!.x + 2, position.y));
                }
                if (position!.x + 1 < Const.height)
                {
                    positionsAvailableToMove.Add(new Position(position.x + 1, position.y));
                }
                if (position.y + 1 < Const.height && position.x + 1 < Const.width)
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
                if (isFirstMove())
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
    }
}
