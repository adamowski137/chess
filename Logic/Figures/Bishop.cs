using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using chess137.Chess;


namespace chess137.Figures
{
    class Bishop : Figure
    {
    
        public Bishop (int x, int y, bool isW, int id)
        {
            position = new Position (x, y);
            isWhite = isW;
            value = 3;
            name = Const.bishopName;
            Id = id;
        }
        public List<Position> positionsAvailableToMove()
        {
            List<Position> availableToMove = new List<Position>();
            int posX, posY;
            posX = position!.x;
            posY = position!.y;
            while (posX >= 0 && posY >= 0)
            {
                posY--;
                posX--;
                availableToMove.Add (new Position (posX, posY));
            }
            posX = position.x;
            posY = position.y;
            while (posX >= 0 && posY < Const.height)
            {
                posY++;
                posX--;
                availableToMove.Add(new Position (posX, posY));
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
