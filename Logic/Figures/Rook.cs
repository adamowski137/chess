using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using chess137.Chess;

namespace chess137.Figures
{
    internal class Rook : Figure
    {
        private bool ableTocastle;
        public Rook(int posX, int posY, bool isW, int id)
        {
            position = new Position(posX, posY);
            isWhite = isW;
            value = 5;
            name = Const.rookName;
            ableTocastle = true;
            Id = id;
            moves = positionsAvailableToMove();
        }
        public void setUnableToCastle()
        {
            ableTocastle = false;
        }

        public bool isAbleToCastle()
        {
            return ableTocastle;
        }

        public override List<Position> positionsAvailableToMove()
        {
            List<Position> positionsAvailableToMove = new List<Position>();
            
            int i = 1;

            while (position!.x + i < Const.height)
            {
                positionsAvailableToMove.Add(new Position(position.x + i, position.y));
                i++;
            }
            i = 1;
            while (position.x - i >= 0)
            {
                positionsAvailableToMove.Add(new Position(position.x - i, position.y));
                i++;
            }
            i = 1;
            while (position.y - i >= 0)
            {
                positionsAvailableToMove.Add(new Position(position.x, position.y - i));
                i++;
            }
            i = 1;
            while (position.y + i < Const.width)
            { 
                positionsAvailableToMove.Add(new Position(position.x, position.y + i));
                i++;
            }

            return positionsAvailableToMove;
        }
    }
}
