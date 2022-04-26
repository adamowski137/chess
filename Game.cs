using chess137.Chess;
using chess137;
using chess137.Figures;

namespace ChessApi
{
    public class Game
    {
        private static Chessboard? chessboard = new Chessboard();

        public static Chessboard getChessboard()
        {
            chessboard.blackFigures.ForEach(x => x.moves = x.updateMoves(chessboard));
            chessboard.whiteFigures.ForEach(x => x.moves = x.updateMoves(chessboard));

            return chessboard!;
        }
        public static void makeMove(Figure f, Position move)
        {
            if (f.getColor())
            {
                f.setPosition(move);
                chessboard.blackFigures.RemoveAll(x => x.getPosition().x == move.x && x.getPosition().y == move.y);
                chessboard.blackFigures.ForEach(x => x.moves = x.updateMoves(chessboard));
                chessboard.whiteFigures.ForEach(x => x.moves = x.updateMoves(chessboard));
                return;
            }
            f.setPosition(move);
            chessboard.whiteFigures.RemoveAll(x => x.getPosition().x == move.x && x.getPosition().y == move.y);
            chessboard.blackFigures.ForEach(x => x.moves = x.updateMoves(chessboard));
            chessboard.whiteFigures.ForEach(x => x.moves = x.updateMoves(chessboard));
        }
    }
}
