namespace ChessApi
{
    public class Move
    {
        public int PosX { get; set; }
        public int PosY { get; set; }
        public int MoveX { get; set; }
        public int MoveY { get; set; }
        public string? promote { get; set; }
    }
}
