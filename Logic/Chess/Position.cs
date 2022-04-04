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
        public bool beat;

        public Position (int _x, int _y)
        {
            x = _x;
            y = _y;
            beat = false;
        }
        public Array toArray()
        {
            Array res = Array.CreateInstance(Type.GetType("int"), 2);
            res.SetValue(x, 0);
            res.SetValue(y, 1);
            return res;
        }
    }
}
