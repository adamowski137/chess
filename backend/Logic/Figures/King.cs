using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using chess137.Chess;

namespace chess137.Figures
{
    internal class King : Figure
    {
        public King(int posX, int posY, bool isW)
        {
            position = new Position(posX, posY);
            isWhite = isW;
            name = Const.kingName;
            ableTocastle = true;
            moves = positionsAvailableToMove();
            firstMove = true;

        }

        public void setUnableToCastle()
        {
            ableTocastle = false;
        }

        public bool isAbleToCastle()
        {
            return ableTocastle;
        }

        public override List <Position> positionsAvailableToMove()
        {
            List <Position> availableToMove = new List <Position>();
            int posX, posY;
            posX = position!.x;
            posY = position!.y;
            if (posX - 1 >= 0 && posY - 1 >= 0)                     availableToMove.Add(new Position(posX - 1, posY - 1));
            if (posX >= 0 && posY - 1 >= 0)                         availableToMove.Add(new Position(posX,posY - 1));
            if (posX + 1 < Const.height && posY - 1 >= 0)           availableToMove.Add (new Position(posX + 1, posY - 1));
            if (posX + 1 < Const.height && posY >= 0)               availableToMove.Add (new Position(posX + 1, posY));
            if (posX - 1 >= 0 && posY >= 0)                         availableToMove.Add (new Position(posX - 1, posY));
            if (posX - 1 >= 0 && posY + 1 < Const.width)            availableToMove.Add (new Position(posX - 1, posY +  1));
            if (posX >= 0 && posY + 1 < Const.width)                availableToMove.Add(new Position (posX, posY + 1));
            if (posX + 1 < Const.height && posY + 1 < Const.width)  availableToMove.Add(new Position(posX + 1, posY + 1));

            return availableToMove;
        }
        public override King copyFigure()
        {
            King copy = new King(this.position.x, this.position.y, isWhite);
            if (getMoves() != null)
            {
                copy.moves = new List<Position>();
                getMoves().ForEach(x => copy.moves.Add(new Position(x.x, x.y)));

            }
            return copy;
        }
    }
}