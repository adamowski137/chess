using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using chess137.Chess;

namespace chess137.Figures
{
    internal class Queen : Figure
    {
        public Queen(int posX, int posY, bool isW)
        {
            position = new Position(posX, posY);
            isWhite = isW;
            value = 9;
            name = Const.queenName;
        }

        public List<Position> positionsAvailableToMove()
        {
            List<Position> availableToMove = new List<Position>();
            int i = 1;

            while (position.x + i < Const.width)
            {
                availableToMove.Add(new Position(position.x + i, position.y));
                i++;
            }
            i = 1;
            while (position.x - i > 0)
            {
                availableToMove.Add(new Position(position.x - i, position.y));
                i++;
            }
            i = 1;
            while (position.y - i > 0)
            {
                availableToMove.Add(new Position(position.x, position.y - i));
                i++;
            }
            i = 1;
            while (position.y + i < Const.height)
            {
                availableToMove.Add(new Position(position.x, position.y + i));
                i++;
            }

            int posX, posY;
            posX = position.x;
            posY = position.y;
            while (posX >= 0 && posY >= 0)
            {
                posY--;
                posX--;
                availableToMove.Add(new Position(posX, posY));
            }
            posX = position.x;
            posY = position.y;
            while (posX >= 0 && posY < Const.height)
            {
                posY++;
                posX--;
                availableToMove.Add(new Position(posX, posY));
            }
            posX = position.x;
            posY = position.y;
            while (posX < Const.width && posY >= 0)
            {
                posX++;
                posY--;
                availableToMove.Add(new Position(posX, posY));
            }
            posX = position.x;
            posY = position.y;
            while (posX < Const.width && posY < Const.height)
            {
                posY++;
                posX++;
                availableToMove.Add(new Position(posX, posY));
            }


            return availableToMove;
        }
    }
}
