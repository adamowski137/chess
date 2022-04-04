using chess137.Chess;

namespace ChessApi
{
    public class Game
    {
        private static Chessboard? chessboard =new Chessboard();

        public static Chessboard getChessboard()
        {
            return chessboard!;
        }

        public static void setChessboard(Chessboard board)
        {
            chessboard = board;
        }
    }
}
