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
        public Queen(int posX, int posY, bool isW, int id)
        {
            position = new Position(posX, posY);
            isWhite = isW;
            value = 9;
            name = Const.queenName;
            Id = id;
            moves = positionsAvailableToMove();
            firstMove = true;

        }

        public override List<Position> positionsAvailableToMove()
        {
            List<Position> availableToMove = new List<Position>();
            int i = 1;

            while (position!.x + i < Const.height)
            {
                availableToMove.Add(new Position(position.x + i, position.y));
                i++;
            }
            i = 1;
            while (position.x - i >= 0)
            {
                availableToMove.Add(new Position(position.x - i, position.y));
                i++;
            }
            i = 1;
            while (position.y - i >= 0)
            {
                availableToMove.Add(new Position(position.x, position.y - i));
                i++;
            }
            i = 1;
            while (position.y + i < Const.width)
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
                if(posX >= 0 && posY >= 0)
                availableToMove.Add(new Position(posX, posY));
            }
            posX = position.x;
            posY = position.y;
            while (posX >= 0 && posY < Const.width)
            {
                posY++;
                posX--;
                if(posX >= 0 && posY < Const.width)
                availableToMove.Add(new Position(posX, posY));
            }
            posX = position.x;
            posY = position.y;
            while (posX < Const.height && posY >= 0)
            {
                posX++;
                posY--;
                if(posX < Const.height && posY >= 0)
                availableToMove.Add(new Position(posX, posY));
            }
            posX = position.x;
            posY = position.y;
            while (posX < Const.height && posY < Const.width)
            {
                posY++;
                posX++;
                if(posX < Const.height && posY < Const.width)
                availableToMove.Add(new Position(posX, posY));
            }


            return availableToMove;
        }
        public override Queen copyFigure()
        {
            Queen copy = new Queen(this.position.x, this.position.y, isWhite, Id);
            if (getMoves() != null)
                copy.moves = new List<Position>(getMoves());
            return copy;
        }
    }
}
