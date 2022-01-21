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
        public static void removeOccupiedMoves(List<Position> positions, Figure figure, List<Figure> whiteFigures, List<Figure> blackFigures)
        {
            if (figure.getName() == Const.pawnName)
            { 
                for (int i = 0; i < whiteFigures.Count; i++)
                {
                    Position pos = positions.Find(x => x == whiteFigures[i].getPosition());
                    if (pos != null) positions.Remove(pos);
                }
                for (int i = 0; i < blackFigures.Count; i++)
                {
                    Position pos = positions.Find(x => x == blackFigures[i].getPosition());
                    if (pos != null) positions.Remove(pos);
                }
            }

            if (figure.getName() == Const.knightName)
            {
                for (int i = 0; i < whiteFigures.Count; i++)
                {
                    Position pos = positions.Find(x => x == whiteFigures[i].getPosition());
                    if (pos != null) positions.Remove(pos);
                }
            }

            if (figure.getName() == Const.kingName)
            {
                for (int i = 0; i < whiteFigures.Count; i++)
                {
                    Position pos = positions.Find(x => x == whiteFigures[i].getPosition());
                    if(pos != null) positions.Remove(pos);
                }
            }

            if (figure.getName() == Const.rookName)
            {
                for (int i = 0; i < whiteFigures.Count; i++)
                {
                      Position pos = positions.Find(x => x ==whiteFigures[i].getPosition());
                        if(pos != null)
                    {
                        positions.Remove(pos);
                        if (pos.x == figure.getPosition().x && pos.y < figure.getPosition().y)
                        {
                            positions.RemoveAll(x => x.x == figure.getPosition().x && x.y > pos.y);
                        }
                        if (pos.x == figure.getPosition().x && pos.y > figure.getPosition().y)
                        {
                            positions.RemoveAll(x => x.x == figure.getPosition().x && x.y < pos.y);
                        }
                        if (pos.x < figure.getPosition().x && pos.y == figure.getPosition().y)
                        {
                            positions.RemoveAll(x => x.x > pos.x && x.y == figure.getPosition().y);
                        }
                        if (pos.x > figure.getPosition().x && pos.y == figure.getPosition().y)
                        {
                            positions.RemoveAll(x => x.x < pos.x && x.y == figure.getPosition().y);
                        }
                    }
                }
                for (int i = 0; i < blackFigures.Count; i++)
                {
                    Position pos = positions.Find(x => x == blackFigures[i].getPosition());
                    if (pos != null)
                    {
                        positions.Remove(pos);
                        if (pos.x == figure.getPosition().x && pos.y < figure.getPosition().y)
                        {
                            positions.RemoveAll(x => x.x == figure.getPosition().x && x.y < pos.y);
                        }
                        if (pos.x == figure.getPosition().x && pos.y > figure.getPosition().y)
                        {
                            positions.RemoveAll(x => x.x == figure.getPosition().x && x.y > pos.y);
                        }
                        if (pos.x < figure.getPosition().x && pos.y == figure.getPosition().y)
                        {
                            positions.RemoveAll(x => x.x < pos.x && x.y == figure.getPosition().y);
                        }
                        if (pos.x > figure.getPosition().x && pos.y == figure.getPosition().y)
                        {
                            positions.RemoveAll(x => x.x > pos.x && x.y == figure.getPosition().y);
                        }
                    }
                }
            }

            if(figure.getName() == Const.bishopName)
            {
                for(int i = 0; i < whiteFigures.Count; i++)
                {
                    Position pos = positions.Find(x => x == whiteFigures[i].getPosition());
                    if (pos != null)
                    {
                        positions.Remove(pos);
                        if(pos.x > figure.getPosition().x && pos.y > figure.getPosition().y)
                        {
                            positions.RemoveAll(x => x.x > pos.x && x.y > pos.y);
                        }
                        if (pos.x > figure.getPosition().x && pos.y < figure.getPosition().y)
                        {
                            positions.RemoveAll(x => x.x > pos.x && x.y < pos.y);
                        }
                        if (pos.x < figure.getPosition().x && pos.y > figure.getPosition().y)
                        {
                            positions.RemoveAll(x => x.x < pos.x && x.y > pos.y);
                        }
                        if (pos.x < figure.getPosition().x && pos.y < figure.getPosition().y)
                        {
                            positions.RemoveAll(x => x.x < pos.x && x.y < pos.y);
                        }
                    }
                }
                for (int i = 0; i < blackFigures.Count; i++)
                {
                    Position pos = positions.Find(x => x == blackFigures[i].getPosition());
                    if (pos != null)
                    {
                        if (pos.x > figure.getPosition().x && pos.y > figure.getPosition().y)
                        {
                            positions.RemoveAll(x => x.x > pos.x && x.y > pos.y);
                        }
                        if (pos.x > figure.getPosition().x && pos.y < figure.getPosition().y)
                        {
                            positions.RemoveAll(x => x.x > pos.x && x.y < pos.y);
                        }
                        if (pos.x < figure.getPosition().x && pos.y > figure.getPosition().y)
                        {
                            positions.RemoveAll(x => x.x < pos.x && x.y > pos.y);
                        }
                        if (pos.x < figure.getPosition().x && pos.y < figure.getPosition().y)
                        {
                            positions.RemoveAll(x => x.x < pos.x && x.y < pos.y);
                        }
                    }
                }
            }
            if (figure.getName() == Const.queenName)
            {
                for (int i = 0; i < whiteFigures.Count; i++)
                {
                    Position pos = positions.Find(x => x == whiteFigures[i].getPosition());
                    if (pos != null)
                    {
                        positions.Remove(pos);
                        if (pos.x == figure.getPosition().x && pos.y < figure.getPosition().y)
                        {
                            positions.RemoveAll(x => x.x == figure.getPosition().x && x.y > pos.y);
                        }
                        if (pos.x == figure.getPosition().x && pos.y > figure.getPosition().y)
                        {
                            positions.RemoveAll(x => x.x == figure.getPosition().x && x.y < pos.y);
                        }
                        if (pos.x < figure.getPosition().x && pos.y == figure.getPosition().y)
                        {
                            positions.RemoveAll(x => x.x > pos.x && x.y == figure.getPosition().y);
                        }
                        if (pos.x > figure.getPosition().x && pos.y == figure.getPosition().y)
                        {
                            positions.RemoveAll(x => x.x < pos.x && x.y == figure.getPosition().y);
                        }
                        if (pos.x > figure.getPosition().x && pos.y > figure.getPosition().y)
                        {
                            positions.RemoveAll(x => x.x > pos.x && x.y > pos.y);
                        }
                        if (pos.x > figure.getPosition().x && pos.y < figure.getPosition().y)
                        {
                            positions.RemoveAll(x => x.x > pos.x && x.y < pos.y);
                        }
                        if (pos.x < figure.getPosition().x && pos.y > figure.getPosition().y)
                        {
                            positions.RemoveAll(x => x.x < pos.x && x.y > pos.y);
                        }
                        if (pos.x < figure.getPosition().x && pos.y < figure.getPosition().y)
                        {
                            positions.RemoveAll(x => x.x < pos.x && x.y < pos.y);
                        }
                    }
                }

            }
        }
    }

}
