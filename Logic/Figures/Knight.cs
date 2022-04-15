using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using chess137.Chess;

namespace chess137.Figures
{
    internal class Knight : Figure
    {
        public Knight(int posX, int posY, bool isW, int id)
        {
            position = new Position(posX, posY);
            isWhite = isW;
            value = 3;
            name = Const.knightName;
            Id = id;
            moves = positionsAvailableToMove();
        }
        public override List<Position> positionsAvailableToMove()
        {
            List<Position> availableToMove = new List<Position>();
            int posX, posY;
            posX = position!.x;
            posY = position!.y;
            if (posY + 2 < Const.height && posX + 1 < Const.width) availableToMove.Add(new Position(posX + 1, posY + 2));
            if (posY + 2 < Const.height && posX - 1 >= 0) availableToMove.Add(new Position(posX - 1, posY + 2));
            if (posY + 1 < Const.height && posX + 2 < Const.width) availableToMove.Add(new Position(posX + 2, posY + 1));
            if (posY + 1 < Const.height && posX - 2 >= 0) availableToMove.Add(new Position(posX - 2, posY + 1));
            if (posY - 1 >= 0 && posX - 2 >= 0) availableToMove.Add(new Position(posX - 2, posY - 1));
            if (posY - 1 >= 0 && posX + 2 < Const.width) availableToMove.Add(new Position(posX + 2, posY - 1));
            if (posY - 2 >= 0 && posX + 1 < Const.width) availableToMove.Add(new Position(posX + 1, posY - 2));
            if (posY - 2 >= 0 && posX - 1 >= 0) availableToMove.Add(new Position(posX - 1, posY - 2));
            return availableToMove;
        }
    }
} 