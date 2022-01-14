using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using chess137.Figures;
using chess137.Chess;

namespace chess137.Figures
{
    class Figure
    {
        protected Position position;
        protected bool isWhite;
        protected int value;

        public Position getPosition()
        {
            return position;
        }
        public bool getColor()
        {
            return isWhite;
        }
        public int getValue()
        {
            return value;
        }
    }
}
