using chess137.Chess;
using System.Collections;

namespace ChessApi.Converters
{
    public class GameConverter
    {
        public static ChessGame getChessGame(Chessboard chessboard)
        {
            if (chessboard == null) return null;



            return new ChessGame()
            {
                BlackFigures = chessboard.blackFigures.ToArray(),
                WhiteFigures = chessboard.whiteFigures.ToArray(),
                
                x = chessboard.whiteFigures[1].getPosition()
            };

        }

        public static FiguresView getGame(Chessboard chessboard)
        {
            if (chessboard == null) return null;
            
            chessboard.whiteFigures[1].positionsAvailableToMove().ForEach(x => pom[1].SetValue(x.toArray(), 1));

            return new FiguresView()
            {
                x = chessboard.blackFigures[1].getPosition().x,
                y = chessboard.whiteFigures[1].getPosition().y,
                color = "white",
            };
        }
    }
}
