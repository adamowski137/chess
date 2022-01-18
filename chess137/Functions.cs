using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using chess137.Chess;
using chess137.Figures;

namespace chess137
{
    class Functions
    {
        public static int countValue(Chessboard chessboard)
        {
            int value = 0;
            for (int i = 0; i < Const.width; i++)
            {
                for (int j = 0; j < Const.height; j++)
                {
                    if (chessboard.chessBoard[i, j] == null) continue;
                    if (chessboard.chessBoard[i, j].getColor()) value += chessboard.chessBoard[i, j].getValue();
                    if (chessboard.chessBoard[i, j].getColor() == false) value -= chessboard.chessBoard[i, j].getValue();
                }
            }
            return value;
        }

        public static bool isCheck(bool isWhite, Chessboard chessboard, Position position)
        {
            Position kingPosition = chessboard.getKingPosition(isWhite);
            if (position != kingPosition)
            {
                return false;
            }
            else return true;
        }
        public static List<Position> removeIllegalMoves(bool isWhite, Chessboard chessboard, List<Position> availablePositions, Figure figure)
        {
            List<Position> positions = new List<Position>;
            for (int i = 0; i < availablePositions.Count; i++)
            {
                Chessboard chessboard1 = alternativeChessboard(figure, availablePositions[i], chessboard);
                if (isCheck(isWhite, chessboard1, ))
            }

        }

        public static Chessboard alternativeChessboard(Figure figure, Position position, Chessboard chessboard)
        {
            Chessboard newChesboard = chessboard;
            newChesboard.figures.Find(x => x == figure).position = position;
            return newChesboard;
        }
    }

}
