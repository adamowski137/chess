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
            moves = positionsAvailableToMove();
            firstMove = true;
        }
        public override List<Position> positionsAvailableToMove()
        {
            List<Position> availableToMove = new List<Position>();
            int posX, posY;
            posX = position!.x;
            posY = position!.y;
            while (posX >= 0 && posY >= 0)
            {
                posY--;
                posX--;
                if(posX >= 0 && posY >= 0)
                availableToMove.Add (new Position (posX, posY));
            }
            posX = position.x;
            posY = position.y;
            while (posX >= 0 && posY < Const.width)
            {
                posY++;
                posX--;
                if (posX >= 0 && posY < Const.width)
                availableToMove.Add(new Position (posX, posY));
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
        public override Bishop copyFigure()
        {
            Bishop copy = new Bishop(this.position.x, this.position.y, isWhite, Id);
            if (getMoves() != null)
            copy.moves = new List<Position>(getMoves());
            return copy;
        }

    }
}
