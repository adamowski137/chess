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
            chessboard.whiteFigures.ForEach(x => value += x.getValue());
            chessboard.blackFigures.ForEach(x => value -= x.getValue());

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
            List<Position> positions = new List<Position>();
            for (int i = 0; i < availablePositions.Count; i++)
            {
                Chessboard chessboard1 = alternativeChessboard(figure, availablePositions[i], chessboard);
                if (!isCheck(isWhite, chessboard1, availablePositions[i])) positions.Add(availablePositions[i]);
            }
            return positions;
        }

        public static Chessboard alternativeChessboard(Figure figure, Position position, Chessboard chessboard)
        {
            Chessboard newChesboard = chessboard;
            if (figure.getColor())
            {
                newChesboard.whiteFigures.SingleOrDefault(x => x == figure).setPosition(position);
            }
            if (!figure.getColor())
            {
                newChesboard.blackFigures.SingleOrDefault(x => x == figure).setPosition(position);
            }
            return newChesboard;
        }
    }

}
