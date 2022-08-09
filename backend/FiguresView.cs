using chess137.Chess;

namespace ChessApi
{
    public class FiguresView
    {
        public int XPos { get; set; }
        public int YPos { get; set; }
        public string? Color { get; set; }
        public string? Name { get; set; }
        public List <PositionView>? AvailablePos { get; set; }
    }
}
