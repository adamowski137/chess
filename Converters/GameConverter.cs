using chess137.Chess;

namespace ChessApi.Converters
{
    public class GameConverter
    {
        public static ChessGame getChessGame (Chessboard chessboard)
        {
            if (chessboard == null) return null;

            return new ChessGame()
            {
                BlackFigures = chessboard.blackFigures,
                whiteFigures = chessboard.whiteFigures
            };

        }
    }
}
