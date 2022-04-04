using System.Collections;

namespace ChessApi
{
    public class FiguresView
    {
        public int x { get; set; }
        public int y { get; set; }
        public string color { get; set; }
        public Array? availablePos { get; set; }
    }
}
