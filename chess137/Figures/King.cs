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
        }

        public List <Position> positionsAvailableToMove()
        {
            List <Position> availableToMove = new List <Position>();
            int posX, posY;
            posX = position.x;
            posY = position.y;
            if (posX - 1 >= 0 && posY - 1 >= 0) availableToMove.Add(new Position(posX - 1, posY - 1));
            if (posX >= 0 && posY - 1 >= 0) availableToMove.Add(new Position(posX,posY - 1));
            if (posX + 1 < Const.width && posY - 1 >= 0) availableToMove.Add (new Position(posX + 1, posY - 1));
            if (posX + 1 < Const.width && posY >= 0) availableToMove.Add (new Position(posX + 1, posY));
            if (posX - 1 >= 0 && posY >= 0) availableToMove.Add (new Position(posX - 1, posY));
            if (posX - 1 >= 0 && posY + 1 < Const.height) availableToMove.Add (new Position(posX - 1, posY));
            if (posX >= 0 && posY + 1 < Const.height) availableToMove.Add(new Position (posX, posY + 1));
            if (po)

            return availableToMove;
        }
    }
}
