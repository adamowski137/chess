using chess137.Chess;
using chess137.Figures;
using System.Collections;

namespace ChessApi.Converters
{
    public class GameConverter
    {
        public static PositionView getPosition(Position position)
        {
            PositionView x = new PositionView();
            x.XPos = position.x;
            x.YPos = position.y;
            return x;
        }
        public static FiguresView getFigure(Figure figure)
        {
            FiguresView x = new FiguresView();
            x.XPos = figure.getPosition().x;
            x.YPos = figure.getPosition().y;
            x.Color = figure.getColor() ? "white" : "black";
            x.Name = figure.getName();
            x.AvailablePos = new List<PositionView>();
            if (figure.getMoves() != null)
            for (int i = 0; i < figure.getMoves()!.Count; i++)
            {
                x.AvailablePos.Add(getPosition(figure.getMoves()[i]));
            }
            return x;
        }
  
        public static ChessGame getChessGame(Chessboard chessboard)
        {
            if (chessboard == null) return null;



            ChessGame chess = new ChessGame();
            chess.Figures = new List<FiguresView>();
            for (int i = 0; i < chessboard.blackFigures.Count; i++)
            {
                chess.Figures.Add(getFigure(chessboard.blackFigures[i]));
                chess.Figures.Add(getFigure(chessboard.whiteFigures[i]));
            }
            return chess;
        }

    }
}
