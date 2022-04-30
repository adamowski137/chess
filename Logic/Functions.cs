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
        public static Chessboard alternativeChessboard(Figure figure, Position position, Chessboard chessboard)
        {
            Chessboard newChesboard = new Chessboard(chessboard);
            if (figure.getColor())
            {
                newChesboard.whiteFigures.SingleOrDefault(x => x == figure)!.setPosition(position);
            }
            if (!figure.getColor())
            {
                newChesboard.blackFigures.SingleOrDefault(x => x == figure)!.setPosition(position);
            }
            if (position.beat)
            {
                if (figure.getColor()) newChesboard.blackFigures.RemoveAll(x => x.getPosition() == position);
                else newChesboard.whiteFigures.RemoveAll(x => x.getPosition() == position);
            }
            return newChesboard;
        }

        public static List<Position> removeOccupiedMoves(Figure figure, Chessboard chessboard)
        {
            if(figure.getName() == Const.rookName)
            {
                if (figure.getColor())
                {
                    for (int i = 0; i < chessboard.whiteFigures.Count; i++)
                    {
                        Position pos = figure.getMoves().Find(x => chessboard.whiteFigures[i].getPosition().x == x.x && chessboard.whiteFigures[i].getPosition().y == x.y);
                        if (pos == null) continue;
                        if (pos.x > figure.getPosition().x) figure.getMoves().RemoveAll(x => x.x > pos.x);
                        if (pos.x < figure.getPosition().x) figure.getMoves().RemoveAll(x => x.x < pos.x);
                        if (pos.y < figure.getPosition().y) figure.getMoves().RemoveAll(x => x.y < pos.y);
                        if (pos.y > figure.getPosition().y) figure.getMoves().RemoveAll(x => x.y > pos.y);

                        figure.getMoves().Remove(pos);
                    }
                    for (int i = 0; i < chessboard.blackFigures.Count; i++)
                    {
                        Position pos = figure.getMoves().Find(x => chessboard.blackFigures[i].getPosition().x == x.x && chessboard.blackFigures[i].getPosition().y == x.y);
                        if (pos == null) continue;
                        if (pos.x > figure.getPosition().x) figure.getMoves().RemoveAll(x => x.x > pos.x);
                        if (pos.x < figure.getPosition().x) figure.getMoves().RemoveAll(x => x.x < pos.x);
                        if (pos.y < figure.getPosition().y) figure.getMoves().RemoveAll(x => x.y < pos.y);
                        if (pos.y > figure.getPosition().y) figure.getMoves().RemoveAll(x => x.y > pos.y);
                    }
                    return figure.getMoves();
                }
                for (int i = 0; i < chessboard.whiteFigures.Count; i++)
                {
                    Position pos = figure.getMoves().Find(x => chessboard.whiteFigures[i].getPosition().x == x.x && chessboard.whiteFigures[i].getPosition().y == x.y);
                    if (pos == null) continue;
                    if (pos.x > figure.getPosition().x) figure.getMoves().RemoveAll(x => x.x > pos.x);
                    if (pos.x < figure.getPosition().x) figure.getMoves().RemoveAll(x => x.x < pos.x);
                    if (pos.y < figure.getPosition().y) figure.getMoves().RemoveAll(x => x.y < pos.y);
                    if (pos.y > figure.getPosition().y) figure.getMoves().RemoveAll(x => x.y > pos.y);

                }
                for (int i = 0; i < chessboard.blackFigures.Count; i++)
                {
                    Position pos = figure.getMoves().Find(x => chessboard.blackFigures[i].getPosition().x == x.x && chessboard.blackFigures[i].getPosition().y == x.y);
                    if (pos == null) continue;
                    if (pos.x > figure.getPosition().x) figure.getMoves().RemoveAll(x => x.x > pos.x);
                    if (pos.x < figure.getPosition().x) figure.getMoves().RemoveAll(x => x.x < pos.x);
                    if (pos.y < figure.getPosition().y) figure.getMoves().RemoveAll(x => x.y < pos.y);
                    if (pos.y > figure.getPosition().y) figure.getMoves().RemoveAll(x => x.y > pos.y);

                    figure.getMoves().Remove(pos);
                }
            }
            if (figure.getName() == Const.bishopName)
            {
                if (figure.getColor())
                {
                    for (int i = 0; i < chessboard.whiteFigures.Count; i++)
                    {
                        Position pos = figure.getMoves().Find(x => chessboard.whiteFigures[i].getPosition().x == x.x && chessboard.whiteFigures[i].getPosition().y == x.y);
                        if (pos == null) continue;
                        if (pos.x > figure.getPosition().x && pos.y > figure.getPosition().y) figure.getMoves().RemoveAll(x => x.x > pos.x && x.y > pos.y);
                        if (pos.x > figure.getPosition().x && pos.y < figure.getPosition().y) figure.getMoves().RemoveAll(x => x.x > pos.x && x.y < pos.y);
                        if (pos.x < figure.getPosition().x && pos.y < figure.getPosition().y) figure.getMoves().RemoveAll(x => x.x < pos.x && x.y < pos.y);
                        if (pos.x < figure.getPosition().x && pos.y > figure.getPosition().y) figure.getMoves().RemoveAll(x => x.x < pos.x && x.y > pos.y);

                        figure.getMoves().Remove(pos);
                    }
                    for (int i = 0; i < chessboard.blackFigures.Count; i++)
                    {
                        Position pos = figure.getMoves().Find(x => chessboard.blackFigures[i].getPosition().x == x.x && chessboard.blackFigures[i].getPosition().y == x.y);
                        if (pos == null) continue;
                        if (pos.x > figure.getPosition().x && pos.y > figure.getPosition().y) figure.getMoves().RemoveAll(x => x.x > pos.x && x.y > pos.y);
                        if (pos.x > figure.getPosition().x && pos.y < figure.getPosition().y) figure.getMoves().RemoveAll(x => x.x > pos.x && x.y < pos.y);
                        if (pos.x < figure.getPosition().x && pos.y < figure.getPosition().y) figure.getMoves().RemoveAll(x => x.x < pos.x && x.y < pos.y);
                        if (pos.x < figure.getPosition().x && pos.y > figure.getPosition().y) figure.getMoves().RemoveAll(x => x.x < pos.x && x.y > pos.y);
                    }
                    return figure.getMoves();
                }
                for (int i = 0; i < chessboard.whiteFigures.Count; i++)
                {
                    Position pos = figure.getMoves().Find(x => chessboard.whiteFigures[i].getPosition().x == x.x && chessboard.whiteFigures[i].getPosition().y == x.y);
                    if (pos == null) continue;
                    if (pos.x > figure.getPosition().x && pos.y > figure.getPosition().y) figure.getMoves().RemoveAll(x => x.x > pos.x && x.y > pos.y);
                    if (pos.x > figure.getPosition().x && pos.y < figure.getPosition().y) figure.getMoves().RemoveAll(x => x.x > pos.x && x.y < pos.y);
                    if (pos.x < figure.getPosition().x && pos.y < figure.getPosition().y) figure.getMoves().RemoveAll(x => x.x < pos.x && x.y < pos.y);
                    if (pos.x < figure.getPosition().x && pos.y > figure.getPosition().y) figure.getMoves().RemoveAll(x => x.x < pos.x && x.y > pos.y);

                }
                for (int i = 0; i < chessboard.blackFigures.Count; i++)
                {
                    Position pos = figure.getMoves().Find(x => chessboard.blackFigures[i].getPosition().x == x.x && chessboard.blackFigures[i].getPosition().y == x.y);
                    if (pos == null) continue;
                    if (pos.x > figure.getPosition().x && pos.y > figure.getPosition().y) figure.getMoves().RemoveAll(x => x.x > pos.x && x.y > pos.y);
                    if (pos.x > figure.getPosition().x && pos.y < figure.getPosition().y) figure.getMoves().RemoveAll(x => x.x > pos.x && x.y < pos.y);
                    if (pos.x < figure.getPosition().x && pos.y < figure.getPosition().y) figure.getMoves().RemoveAll(x => x.x < pos.x && x.y < pos.y);
                    if (pos.x < figure.getPosition().x && pos.y > figure.getPosition().y) figure.getMoves().RemoveAll(x => x.x < pos.x && x.y > pos.y);

                    figure.getMoves().Remove(pos);
                }
            }
            if (figure.getName() == Const.kingName)
            {
                if (figure.getColor())
                {
                    for (int i = 0; i < chessboard.whiteFigures.Count; i++)
                    {
                        Position pos = figure.getMoves().Find(x => chessboard.whiteFigures[i].getPosition().x == x.x && chessboard.whiteFigures[i].getPosition().y == x.y);
                        if (pos == null) continue;

                        figure.getMoves().Remove(pos);
                    }
                    return figure.getMoves();
                }
                for (int i = 0; i < chessboard.blackFigures.Count; i++)
                {
                    Position pos = figure.getMoves().Find(x => chessboard.blackFigures[i].getPosition().x == x.x && chessboard.blackFigures[i].getPosition().y == x.y);
                    if (pos == null) continue;

                    figure.getMoves().Remove(pos);
                }
            }
            if (figure.getName() == Const.knightName)
            {
                if (figure.getColor())
                {
                    for (int i = 0; i < chessboard.whiteFigures.Count; i++)
                    {
                        Position pos = figure.getMoves().Find(x => chessboard.whiteFigures[i].getPosition().x == x.x && chessboard.whiteFigures[i].getPosition().y == x.y);
                        if (pos == null) continue;

                        figure.getMoves().Remove(pos);
                    }
                    return figure.getMoves();
                }
                for (int i = 0; i < chessboard.blackFigures.Count; i++)
                {
                    Position pos = figure.getMoves().Find(x => chessboard.blackFigures[i].getPosition().x == x.x && chessboard.blackFigures[i].getPosition().y == x.y);
                    if (pos == null) continue;

                    figure.getMoves().Remove(pos);
                }
            }
            if (figure.getName() == Const.queenName)
            {
                if (figure.getColor())
                {
                    for (int i = 0; i < chessboard.whiteFigures.Count; i++)
                    {
                        Position pos = figure.getMoves().Find(x => chessboard.whiteFigures[i].getPosition().x == x.x && chessboard.whiteFigures[i].getPosition().y == x.y);
                        if (pos == null) continue;
                        if (pos.x > figure.getPosition().x && pos.y > figure.getPosition().y) figure.getMoves().RemoveAll(x => x.x > pos.x && x.y > pos.y);
                        if (pos.x > figure.getPosition().x && pos.y < figure.getPosition().y) figure.getMoves().RemoveAll(x => x.x > pos.x && x.y < pos.y);
                        if (pos.x < figure.getPosition().x && pos.y < figure.getPosition().y) figure.getMoves().RemoveAll(x => x.x < pos.x && x.y < pos.y);
                        if (pos.x < figure.getPosition().x && pos.y > figure.getPosition().y) figure.getMoves().RemoveAll(x => x.x < pos.x && x.y > pos.y);
                        if (pos.x < figure.getPosition().x && pos.y == figure.getPosition().y) figure.getMoves().RemoveAll(x => x.x < pos.x && x.y == pos.y);
                        if (pos.x > figure.getPosition().x && pos.y == figure.getPosition().y) figure.getMoves().RemoveAll(x => x.x > pos.x && x.y == pos.y);
                        if (pos.x == figure.getPosition().x && pos.y > figure.getPosition().y) figure.getMoves().RemoveAll(x => x.x == pos.x && x.y > pos.y);
                        if (pos.x == figure.getPosition().x && pos.y < figure.getPosition().y) figure.getMoves().RemoveAll(x => x.x == pos.x && x.y < pos.y);

                        figure.getMoves().Remove(pos);
                    }
                    for (int i = 0; i < chessboard.blackFigures.Count; i++)
                    {
                        Position pos = figure.getMoves().Find(x => chessboard.blackFigures[i].getPosition().x == x.x && chessboard.blackFigures[i].getPosition().y == x.y);
                        if (pos == null) continue;
                        if (pos.x > figure.getPosition().x && pos.y > figure.getPosition().y) figure.getMoves().RemoveAll(x => x.x > pos.x && x.y > pos.y);
                        if (pos.x > figure.getPosition().x && pos.y < figure.getPosition().y) figure.getMoves().RemoveAll(x => x.x > pos.x && x.y < pos.y);
                        if (pos.x < figure.getPosition().x && pos.y < figure.getPosition().y) figure.getMoves().RemoveAll(x => x.x < pos.x && x.y < pos.y);
                        if (pos.x < figure.getPosition().x && pos.y > figure.getPosition().y) figure.getMoves().RemoveAll(x => x.x < pos.x && x.y > pos.y);
                        if (pos.x < figure.getPosition().x && pos.y == figure.getPosition().y) figure.getMoves().RemoveAll(x => x.x < pos.x && x.y == pos.y);
                        if (pos.x > figure.getPosition().x && pos.y == figure.getPosition().y) figure.getMoves().RemoveAll(x => x.x > pos.x && x.y == pos.y);
                        if (pos.x == figure.getPosition().x && pos.y > figure.getPosition().y) figure.getMoves().RemoveAll(x => x.x == pos.x && x.y > pos.y);
                        if (pos.x == figure.getPosition().x && pos.y < figure.getPosition().y) figure.getMoves().RemoveAll(x => x.x == pos.x && x.y < pos.y);
                    }
                    return figure.getMoves();
                }
                for (int i = 0; i < chessboard.whiteFigures.Count; i++)
                {
                    Position pos = figure.getMoves().Find(x => chessboard.whiteFigures[i].getPosition().x == x.x && chessboard.whiteFigures[i].getPosition().y == x.y);
                    if (pos == null) continue;
                    if (pos.x > figure.getPosition().x && pos.y > figure.getPosition().y) figure.getMoves().RemoveAll(x => x.x > pos.x && x.y > pos.y);
                    if (pos.x > figure.getPosition().x && pos.y < figure.getPosition().y) figure.getMoves().RemoveAll(x => x.x > pos.x && x.y < pos.y);
                    if (pos.x < figure.getPosition().x && pos.y < figure.getPosition().y) figure.getMoves().RemoveAll(x => x.x < pos.x && x.y < pos.y);
                    if (pos.x < figure.getPosition().x && pos.y > figure.getPosition().y) figure.getMoves().RemoveAll(x => x.x < pos.x && x.y > pos.y);
                    if (pos.x < figure.getPosition().x && pos.y == figure.getPosition().y) figure.getMoves().RemoveAll(x => x.x < pos.x && x.y == pos.y);
                    if (pos.x > figure.getPosition().x && pos.y == figure.getPosition().y) figure.getMoves().RemoveAll(x => x.x > pos.x && x.y == pos.y);
                    if (pos.x == figure.getPosition().x && pos.y > figure.getPosition().y) figure.getMoves().RemoveAll(x => x.x == pos.x && x.y > pos.y);
                    if (pos.x == figure.getPosition().x && pos.y < figure.getPosition().y) figure.getMoves().RemoveAll(x => x.x == pos.x && x.y < pos.y);

                }
                for (int i = 0; i < chessboard.blackFigures.Count; i++)
                {
                    Position pos = figure.getMoves().Find(x => chessboard.blackFigures[i].getPosition().x == x.x && chessboard.blackFigures[i].getPosition().y == x.y);
                    if (pos == null) continue;
                    if (pos.x > figure.getPosition().x && pos.y > figure.getPosition().y) figure.getMoves().RemoveAll(x => x.x > pos.x && x.y > pos.y);
                    if (pos.x > figure.getPosition().x && pos.y < figure.getPosition().y) figure.getMoves().RemoveAll(x => x.x > pos.x && x.y < pos.y);
                    if (pos.x < figure.getPosition().x && pos.y < figure.getPosition().y) figure.getMoves().RemoveAll(x => x.x < pos.x && x.y < pos.y);
                    if (pos.x < figure.getPosition().x && pos.y > figure.getPosition().y) figure.getMoves().RemoveAll(x => x.x < pos.x && x.y > pos.y);
                    if (pos.x < figure.getPosition().x && pos.y == figure.getPosition().y) figure.getMoves().RemoveAll(x => x.x < pos.x && x.y == pos.y);
                    if (pos.x > figure.getPosition().x && pos.y == figure.getPosition().y) figure.getMoves().RemoveAll(x => x.x > pos.x && x.y == pos.y);
                    if (pos.x == figure.getPosition().x && pos.y > figure.getPosition().y) figure.getMoves().RemoveAll(x => x.x == pos.x && x.y > pos.y);
                    if (pos.x == figure.getPosition().x && pos.y < figure.getPosition().y) figure.getMoves().RemoveAll(x => x.x == pos.x && x.y < pos.y);

                    figure.getMoves().Remove(pos);
                }
            }
            if (figure.getName() == Const.pawnName)
            {
                if (figure.getColor())
                {
                    for (int i = 0; i < chessboard.whiteFigures.Count; i++)
                    {
                        Position pos = figure.getMoves().Find(x => x.x == chessboard.whiteFigures[i].getPosition().x && x.y == chessboard.whiteFigures[i].getPosition().y);
                        if (pos == null) continue;
                        figure.getMoves().Remove(pos);
                     }
                    List<Position> toRemove = new List<Position>();
                    for (int i = 0; i < figure.getMoves().Count; i++)
                    {
                        if (figure.getMoves()[i].y == figure.getPosition().y)
                        {
                            Figure f = chessboard.blackFigures.Find(x => x.getPosition().x == figure.getMoves()[i].x && x.getPosition().y == figure.getMoves()[i].y);
                            if (f == null) continue;
                            toRemove.Add(f.getPosition());
                            continue;
                        }
                        Figure f2 = chessboard.blackFigures.Find(x => x.getPosition().x == figure.getMoves()[i].x && x.getPosition().y == figure.getMoves()[i].y);
                        if (f2 == null) toRemove.Add(figure.getMoves()[i]);
                    }
                    toRemove.ForEach(x => figure.getMoves().RemoveAll(y => x.x == y.x && x.y == y.y));
                }
                if (!figure.getColor())
                {
                    for (int i = 0; i < chessboard.blackFigures.Count; i++)
                    {
                        Position pos = figure.getMoves().Find(x => x.x == chessboard.blackFigures[i].getPosition().x && x.y == chessboard.blackFigures[i].getPosition().y);
                        if (pos == null) continue;
                        figure.getMoves().Remove(pos);
                    }
                    List<Position> toRemove = new List<Position>();
                    for (int i = 0; i < figure.getMoves().Count; i++)
                    {
                        if (figure.getMoves()[i].y == figure.getPosition().y)
                        {
                            Figure f = chessboard.whiteFigures.Find(x => x.getPosition().x == figure.getMoves()[i].x && x.getPosition().y == figure.getMoves()[i].y);
                            if (f == null) continue;
                            toRemove.Add(f.getPosition());
                            if (f.getPosition().x == figure.getPosition().x - 1)
                            {
                                Position pos = new Position(figure.getPosition().y, figure.getPosition().x - 2);
                                toRemove.Add(pos);
                            }
                            continue;
                        }
                        Figure f2 = chessboard.whiteFigures.Find(x => x.getPosition().x == figure.getMoves()[i].x && x.getPosition().y == figure.getMoves()[i].y);
                        if (f2 == null) toRemove.Add(figure.getMoves()[i]);
                    }
                    toRemove.ForEach(x => figure.getMoves().RemoveAll(y => x.x == y.x && x.y == y.y));
                }
                return figure.getMoves();

            }



            return figure.getMoves();
        }
        /*
        public static List<Position> removeIllegalMoves(bool isWhite, Chessboard chessboard, List<Position> availableMoves, Figure figure)
        {
            List<Position> positions = new List<Position>();
            for (int i = 0; i < availableMoves.Count; i++)
            {
                Position pos = figure.getPosition();
                Chessboard chessboard1 = alternativeChessboard(figure, availableMoves[i], chessboard);
                if (!isCheck(isWhite, chessboard1, availableMoves[i])) positions.Add(availableMoves[i]);
                chessboard1 =  alternativeChessboard(figure, pos, chessboard);
            }
            return positions;
        }

        public static Chessboard alternativeChessboard(Figure figure, Position position, Chessboard chessboard)
        {
            Chessboard newChesboard = new Chessboard(chessboard);
            if (figure.getColor())
            {
                newChesboard.whiteFigures.SingleOrDefault(x => x == figure)!.setPosition(position);
            }
            if (!figure.getColor())
            {
                newChesboard.blackFigures.SingleOrDefault(x => x == figure)!.setPosition(position);
            }
            if (position.beat)
            {
                if(figure.getColor())   newChesboard.blackFigures.RemoveAll(x => x.getPosition() == position);
                else newChesboard.whiteFigures.RemoveAll(x => x.getPosition() == position);
            }
            return newChesboard;
        }
        public static List <Position> removeOccupiedMoves(List<Position> moves, Figure figure, List<Figure> whiteFigures, List<Figure> blackFigures)
        {
            if (figure.getName() == Const.pawnName)
            {
                for (int i = 0; i < whiteFigures.Count; i++)
                {
                    Position? pos = figure.getMoves().Find(x => x.x == whiteFigures[i].getPosition().y && x.y == whiteFigures[i].getPosition().x);
                    if (pos != null) figure.getMoves().Remove(pos);
                }
                for (int i = 0; i < blackFigures.Count; i++)
                {
                    Position? pos = figure.getMoves().Find(x => x.x == blackFigures[i].getPosition().x && x.y == blackFigures[i].getPosition().y);
                    if (pos != null) figure.getMoves().Remove(pos);
                }
                if (figure.getColor())
                {
                    for (int i = 0; i < moves.Count; i++)
                    {
                        if(moves[i].x != figure.getPosition().x)
                        {
                            if (blackFigures.Find(x => x.getPosition().x == moves[i].x) == null) moves.Remove(moves[i]);
                            else moves[i].beat = true;
                        }
                    }
                }
                if (!figure.getColor())
                {
                    for (int i = 0; i < moves.Count; i++)
                    {
                        if (moves[i].x != figure.getPosition().x)
                        {
                            if (whiteFigures.Find(x => x.getPosition().x == moves[i].x) == null) moves.Remove(moves[i]);
                            else moves[i].beat = true;
                        }
                    }
                }
            }

            if (figure.getName() == Const.knightName)
            {
                if (figure.getColor())
                {
                    for (int i = 0; i < whiteFigures.Count; i++)
                    {
                        Position? pos = figure.getMoves().Find(x => x.y == whiteFigures[i].getPosition().x);
                        if (pos != null) figure.getMoves().Remove(pos);
                    }
                    for (int i = 0; i < blackFigures.Count; i++)
                    {
                        if (figure.getMoves().Find(x => x == whiteFigures[i].getPosition()) != null)
                            figure.getMoves().Find(x => x == blackFigures[i].getPosition())!.beat = true;
                    }
                }
                else
                {
                    for (int i = 0; i < blackFigures.Count; i++)
                    {
                        Position? pos = moves.Find(x => x == blackFigures[i].getPosition());
                        if (pos != null) moves.Remove(pos);
                    }
                    for (int i = 0; i < whiteFigures.Count; i++)
                    {
                        if(moves.Find(x => x == whiteFigures[i].getPosition()) != null)
                        moves.Find(x => x == whiteFigures[i].getPosition())!.beat = true;
                    }
                }
            }

            if (figure.getName() == Const.kingName)
            {
                if (figure.getColor())
                {
                    for (int i = 0; i < whiteFigures.Count; i++)
                    {
                        Position? pos = moves.Find(x => x == whiteFigures[i].getPosition());
                        if (pos != null) moves.Remove(pos);
                    }
                    for (int i = 0; i < blackFigures.Count; i++)
                    {
                        if (moves.Find(x => x == whiteFigures[i].getPosition()) != null)
                            moves.Find(x => x == blackFigures[i].getPosition())!.beat = true;
                    }
                }
                else
                {
                    for (int i = 0; i < blackFigures.Count; i++)
                    {
                        Position? pos = moves.Find(x => x == blackFigures[i].getPosition());
                        if (pos != null) moves.Remove(pos);
                    }
                    for (int i = 0; i < whiteFigures.Count; i++)
                    {
                        if (moves.Find(x => x == whiteFigures[i].getPosition()) != null)
                            moves.Find(x => x == whiteFigures[i].getPosition())!.beat = true;
                    }
                }
            }

            if (figure.getName() == Const.rookName)
            {
                for (int i = 0; i < whiteFigures.Count; i++)
                {
                    Figure x = whiteFigures[i];
                    Position? pos = moves.Find(x => x ==whiteFigures[i].getPosition());
                    if(pos != null)
                    {
                        if (figure.getColor())  moves.Remove(pos);
                        else moves.Find(x => x == pos)!.beat = true;

                        if (pos.x == figure.getPosition().x && pos.y < figure.getPosition().y)
                        {
                            moves.RemoveAll(x => x.x == figure.getPosition().x && x.y > pos.y);
                        }
                        if (pos.x == figure.getPosition().x && pos.y > figure.getPosition().y)
                        {
                            moves.RemoveAll(x => x.x == figure.getPosition().x && x.y < pos.y);
                        }
                        if (pos.x < figure.getPosition().x && pos.y == figure.getPosition().y)
                        {
                            moves.RemoveAll(x => x.x > pos.x && x.y == figure.getPosition().y);
                        }
                        if (pos.x > figure.getPosition().x && pos.y == figure.getPosition().y)
                        {
                            moves.RemoveAll(x => x.x < pos.x && x.y == figure.getPosition().y);
                        }
                    }
                }
                for (int i = 0; i < blackFigures.Count; i++)
                {
                    Position? pos = moves.Find(x => x == blackFigures[i].getPosition());
                    if (pos != null)
                    {
                        if (!figure.getColor()) moves.Remove(pos);
                        else moves.Find(x => x == pos)!.beat = true;

                        if (pos.x == figure.getPosition().x && pos.y < figure.getPosition().y)
                        {
                            moves.RemoveAll(x => x.x == figure.getPosition().x && x.y < pos.y);
                        }
                        if (pos.x == figure.getPosition().x && pos.y > figure.getPosition().y)
                        {
                            moves.RemoveAll(x => x.x == figure.getPosition().x && x.y > pos.y);
                        }
                        if (pos.x < figure.getPosition().x && pos.y == figure.getPosition().y)
                        {
                            moves.RemoveAll(x => x.x < pos.x && x.y == figure.getPosition().y);
                        }
                        if (pos.x > figure.getPosition().x && pos.y == figure.getPosition().y)
                        {
                            moves.RemoveAll(x => x.x > pos.x && x.y == figure.getPosition().y);
                        }
                    }
                }
            }

            if(figure.getName() == Const.bishopName)
            {
                for(int i = 0; i < whiteFigures.Count; i++)
                {
                    Position? pos = moves.Find(x => x == whiteFigures[i].getPosition());
                    if (pos != null)
                    {
                        if (figure.getColor())  moves.Remove(pos);
                        else moves.Find(x => x == pos)!.beat = true;

                        if (pos.x > figure.getPosition().x && pos.y > figure.getPosition().y)
                        {
                            moves.RemoveAll(x => x.x > pos.x && x.y > pos.y);
                        }
                        if (pos.x > figure.getPosition().x && pos.y < figure.getPosition().y)
                        {
                            moves.RemoveAll(x => x.x > pos.x && x.y < pos.y);
                        }
                        if (pos.x < figure.getPosition().x && pos.y > figure.getPosition().y)
                        {
                            moves.RemoveAll(x => x.x < pos.x && x.y > pos.y);
                        }
                        if (pos.x < figure.getPosition().x && pos.y < figure.getPosition().y)
                        {
                            moves.RemoveAll(x => x.x < pos.x && x.y < pos.y);
                        }
                    }
                }
                for (int i = 0; i < blackFigures.Count; i++)
                {
                    Position? pos = moves.Find(x => x == blackFigures[i].getPosition());
                    if (pos != null)
                    {
                        if (figure.getColor()) moves.Remove(pos);
                        else moves.Find(x => x == pos)!.beat = true;  

                        if (pos.x > figure.getPosition().x && pos.y > figure.getPosition().y)
                        {
                            moves.RemoveAll(x => x.x > pos.x && x.y > pos.y);
                        }
                        if (pos.x > figure.getPosition().x && pos.y < figure.getPosition().y)
                        {
                            moves.RemoveAll(x => x.x > pos.x && x.y < pos.y);
                        }
                        if (pos.x < figure.getPosition().x && pos.y > figure.getPosition().y)
                        {
                            moves.RemoveAll(x => x.x < pos.x && x.y > pos.y);
                        }
                        if (pos.x < figure.getPosition().x && pos.y < figure.getPosition().y)
                        {
                            moves.RemoveAll(x => x.x < pos.x && x.y < pos.y);
                        }
                    }
                }
            }
            if (figure.getName() == Const.queenName)
            {
                for (int i = 0; i < whiteFigures.Count; i++)
                {
                    Position? pos = moves.Find(x => x == whiteFigures[i].getPosition());
                    if (pos != null)
                    {
                        if (figure.getColor()) moves.Remove(pos);
                        else moves.Find(x => x == pos)!.beat = true;

                        if (pos.x == figure.getPosition().x && pos.y < figure.getPosition().y)
                        {
                            moves.RemoveAll(x => x.x == figure.getPosition().x && x.y > pos.y);
                        }
                        if (pos.x == figure.getPosition().x && pos.y > figure.getPosition().y)
                        {
                            moves.RemoveAll(x => x.x == figure.getPosition().x && x.y < pos.y);
                        }
                        if (pos.x < figure.getPosition().x && pos.y == figure.getPosition().y)
                        {
                            moves.RemoveAll(x => x.x > pos.x && x.y == figure.getPosition().y);
                        }
                        if (pos.x > figure.getPosition().x && pos.y == figure.getPosition().y)
                        {
                            moves.RemoveAll(x => x.x < pos.x && x.y == figure.getPosition().y);
                        }
                        if (pos.x > figure.getPosition().x && pos.y > figure.getPosition().y)
                        {
                            moves.RemoveAll(x => x.x > pos.x && x.y > pos.y);
                        }
                        if (pos.x > figure.getPosition().x && pos.y < figure.getPosition().y)
                        {
                            moves.RemoveAll(x => x.x > pos.x && x.y < pos.y);
                        }
                        if (pos.x < figure.getPosition().x && pos.y > figure.getPosition().y)
                        {
                            moves.RemoveAll(x => x.x < pos.x && x.y > pos.y);
                        }
                        if (pos.x < figure.getPosition().x && pos.y < figure.getPosition().y)
                        {
                            moves.RemoveAll(x => x.x < pos.x && x.y < pos.y);
                        }
                    }
                }
                for (int i = 0; i < blackFigures.Count; i++)
                {
                    Position? pos = moves.Find(x => x == blackFigures[i].getPosition());
                    if (pos != null)
                    {
                        if (!figure.getColor()) moves.Remove(pos);
                        else moves.Find(x => x == pos)!.beat = true;

                        if (pos.x == figure.getPosition().x && pos.y < figure.getPosition().y)
                        {
                            moves.RemoveAll(x => x.x == figure.getPosition().x && x.y > pos.y);
                        }
                        if (pos.x == figure.getPosition().x && pos.y > figure.getPosition().y)
                        {
                            moves.RemoveAll(x => x.x == figure.getPosition().x && x.y < pos.y);
                        }
                        if (pos.x < figure.getPosition().x && pos.y == figure.getPosition().y)
                        {
                            moves.RemoveAll(x => x.x > pos.x && x.y == figure.getPosition().y);
                        }
                        if (pos.x > figure.getPosition().x && pos.y == figure.getPosition().y)
                        {
                            moves.RemoveAll(x => x.x < pos.x && x.y == figure.getPosition().y);
                        }
                        if (pos.x > figure.getPosition().x && pos.y > figure.getPosition().y)
                        {
                            moves.RemoveAll(x => x.x > pos.x && x.y > pos.y);
                        }
                        if (pos.x > figure.getPosition().x && pos.y < figure.getPosition().y)
                        {
                            moves.RemoveAll(x => x.x > pos.x && x.y < pos.y);
                        }
                        if (pos.x < figure.getPosition().x && pos.y > figure.getPosition().y)
                        {
                            moves.RemoveAll(x => x.x < pos.x && x.y > pos.y);
                        }
                        if (pos.x < figure.getPosition().x && pos.y < figure.getPosition().y)
                        {
                            moves.RemoveAll(x => x.x < pos.x && x.y < pos.y);
                        }
                    }
                }

            }
            return moves;
        }
        */

        public static void promotePawn(Pawn pawn, Figure figure, Chessboard chessboard)
        {
            figure.setPosition(pawn.getPosition());
            figure.setColor(pawn.getColor());
            if (pawn.getColor())
            {
                chessboard.whiteFigures.Remove(pawn);
                chessboard.whiteFigures.Add(figure);
            }
            else
            {
                chessboard.blackFigures.Remove(pawn);
                chessboard.blackFigures.Add(figure);
            }
        }
    }  

}
