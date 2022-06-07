using chess137.Chess;
using chess137;
using chess137.Figures;

namespace ChessApi
{
    public class Game
    {
        private static Chessboard chessboard = new Chessboard();
        public static Chessboard newGame() 
        {
            chessboard = new Chessboard();
            return getChessboard();
        }

        public static Chessboard getChessboard()
        {
            chessboard.blackFigures.ForEach(x => x.moves = x.updateMoves(chessboard));
            chessboard.whiteFigures.ForEach(x => x.moves = x.updateMoves(chessboard));

            return chessboard!;
        }
        public static void makeMove(Figure f, Position move)
        {
            f.setMoved();
            if(chessboard.enPassant != null && move.x == chessboard.enPassant.x && move.y == chessboard.enPassant.y && f.getName() == Const.pawnName)
            {
                chessboard.blackFigures.Remove(chessboard.lastFigure);
                chessboard.whiteFigures.Remove(chessboard.lastFigure);
            }
            if (f.getColor())
            {
                if (f.getName() == Const.pawnName && Math.Abs(move.x - f.getPosition().x) == 2)
                {
                    chessboard.enPassant = new Position(move.x - 1, move.y);
                    chessboard.whiteEnPassant = false;
                }
                else chessboard.enPassant = null;
                    chessboard.blackFigures.RemoveAll(x => x.getPosition().x == move.x && x.getPosition().y == move.y);
                f.setPosition(move);
                chessboard.blackFigures.ForEach(x => x.moves = x.updateMoves(chessboard));
                chessboard.whiteFigures.ForEach(x => x.moves = x.updateMoves(chessboard));
                chessboard.lastFigure = f;
                chessboard.makeTurn();
                return;
            }
            if (f.getName() == Const.pawnName && Math.Abs(move.x - f.getPosition().x) == 2)
            {
                chessboard.enPassant = new Position(move.x + 1, move.y);
                chessboard.whiteEnPassant = true;
            }
            else chessboard.enPassant = null;
            chessboard.whiteFigures.RemoveAll(x => x.getPosition().x == move.x && x.getPosition().y == move.y);
            f.setPosition(move);
            chessboard.blackFigures.ForEach(x => x.moves = x.updateMoves(chessboard));
            chessboard.whiteFigures.ForEach(x => x.moves = x.updateMoves(chessboard));
            chessboard.lastFigure = f;
            chessboard.makeTurn();
        }
    }
}
