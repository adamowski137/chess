using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess137.Chess
{
    public class Position
    {
        public int x;
        public int y;
        public bool whiteShortCastle;
        public bool whiteLongCastle;
        public bool blackLongCastle;
        public bool blackShortCastle;

        public Position (int _x, int _y)
        {
            x = _x;
            y = _y;
            whiteLongCastle = false;
            whiteShortCastle = false;
            blackShortCastle = false;
            blackLongCastle = false;

        }
    }
}
