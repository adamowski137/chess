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
        public Rook(int posX, int posY, bool isW)
        {
            position = new Position(posX, posY);
            isWhite = isW;
            value = 4;
        }
    }
}
