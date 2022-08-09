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

        public static Chessboard copyChessboard(Chessboard chessboard)
        {
            Chessboard c1 = new Chessboard();
            c1.blackFigures.Clear();
            c1.whiteFigures.Clear();
            chessboard.whiteFigures.ForEach(x => c1.whiteFigures.Add(x.copyFigure()));
            chessboard.blackFigures.ForEach(x => c1.blackFigures.Add(x.copyFigure()));

            return c1;
        }
        public static bool alternativeChessboard(Figure f, Position move, Chessboard chessboard)
        {
            Chessboard c = copyChessboard(chessboard);
            Figure? f2 = null;
            if (f.getColor())
            {
                c.blackFigures.RemoveAll(x => x != null && x.getPosition().x == move.x && x.getPosition().y == move.y);
                f2 = c.whiteFigures.Find(x => x != null && x.getPosition().x == f.getPosition().x && x.getPosition().y == f.getPosition().y);
                f2!.setPosition(move);
            }
             
            if (!f.getColor())
            {
                c.whiteFigures.RemoveAll(x => x != null && x.getPosition().x == move.x && x.getPosition().y == move.y);
                f2 = c.blackFigures.Find(x => x != null && x.getPosition().x == f.getPosition().x && x.getPosition().y == f.getPosition().y);
                f2!.setPosition(move);
            }
            c.blackFigures.ForEach(x => x.moves = x.positionsAvailableToMove());
            c.whiteFigures.ForEach(x => x.moves = x.positionsAvailableToMove());
            c.blackFigures.ForEach(x => x.moves = removeOccupiedMoves(x, c));
            c.whiteFigures.ForEach(x => x.moves = removeOccupiedMoves(x, c));
            if (f2 == null) return false;
            return isCheck(f2.getColor(), c);
        }
        public static List<Position> removeOccupiedMoves(Figure figure, Chessboard chessboard)
        {
            if(chessboard.blackFigures == null || chessboard.whiteFigures == null || figure.getMoves() == null) return null;
            if(figure.getName() == Const.rookName)
            {
                if (figure.getColor())
                {
                    for (int i = 0; i < chessboard.whiteFigures.Count; i++)
                    {
                        Position? pos = figure.getMoves().Find(x => x != null && chessboard.whiteFigures[i].getPosition().x == x.x && chessboard.whiteFigures[i].getPosition().y == x.y);
                        if (pos == null) continue;
                        if (pos.x > figure.getPosition().x) figure.getMoves().RemoveAll(x => x != null && x.x > pos.x);
                        if (pos.x < figure.getPosition().x) figure.getMoves().RemoveAll(x => x != null && x.x < pos.x);
                        if (pos.y < figure.getPosition().y) figure.getMoves().RemoveAll(x => x != null && x.y < pos.y);
                        if (pos.y > figure.getPosition().y) figure.getMoves().RemoveAll(x => x != null && x.y > pos.y);

                        figure.getMoves().Remove(pos);
                    }
                    if (chessboard.blackFigures.Count == 0 || chessboard.whiteFigures.Count == 0 || figure.getMoves().Count == 0) return null;
                    for (int i = 0; i < chessboard.blackFigures.Count; i++)
                    {
                        Position? pos = figure.getMoves().Find(x => x != null && chessboard.blackFigures[i].getPosition().x == x.x && chessboard.blackFigures[i].getPosition().y == x.y);
                        if (pos == null) continue;
                        if (pos.x > figure.getPosition().x) figure.getMoves().RemoveAll(x => x != null && x.x > pos.x);
                        if (pos.x < figure.getPosition().x) figure.getMoves().RemoveAll(x => x != null && x.x < pos.x);
                        if (pos.y < figure.getPosition().y) figure.getMoves().RemoveAll(x => x != null && x.y < pos.y);
                        if (pos.y > figure.getPosition().y) figure.getMoves().RemoveAll(x => x != null && x.y > pos.y);
                    }
                    return figure.getMoves();
                }
             
                for (int i = 0; i < chessboard.whiteFigures.Count; i++)
                {

                    Position? pos = figure.getMoves().Find(x => chessboard.whiteFigures[i].getPosition().x == x.x && chessboard.whiteFigures[i].getPosition().y == x.y);
                    if (pos == null) continue;
                    if (pos.x > figure.getPosition().x) figure.getMoves().RemoveAll(x => x != null && x.x > pos.x);
                    if (pos.x < figure.getPosition().x) figure.getMoves().RemoveAll(x => x != null && x.x < pos.x);
                    if (pos.y < figure.getPosition().y) figure.getMoves().RemoveAll(x => x != null && x.y < pos.y);
                    if (pos.y > figure.getPosition().y) figure.getMoves().RemoveAll(x => x != null && x.y > pos.y);

                }
                if (chessboard.blackFigures.Count == 0 || chessboard.whiteFigures.Count == 0 || figure.getMoves().Count == 0) return null;
                for (int i = 0; i < chessboard.blackFigures.Count; i++)
                {
                    Position? pos = figure.getMoves().Find(x => x != null && chessboard.blackFigures[i].getPosition().x == x.x && chessboard.blackFigures[i].getPosition().y == x.y);
                    if (pos == null) continue;
                    if (pos.x > figure.getPosition().x) figure.getMoves().RemoveAll(x => x != null && x.x > pos.x);
                    if (pos.x < figure.getPosition().x) figure.getMoves().RemoveAll(x => x != null && x.x < pos.x);
                    if (pos.y < figure.getPosition().y) figure.getMoves().RemoveAll(x => x != null && x.y < pos.y);
                    if (pos.y > figure.getPosition().y) figure.getMoves().RemoveAll(x => x != null && x.y > pos.y);

                    figure.getMoves().Remove(pos);
                }
            }
            if (figure.getName() == Const.bishopName)
            {
                if (figure.getColor())
                {
                    for (int i = 0; i < chessboard.whiteFigures.Count; i++)
                    {
                        Position? pos = figure.getMoves().Find(x => x != null && chessboard.whiteFigures[i].getPosition().x == x.x && chessboard.whiteFigures[i].getPosition().y == x.y);
                        if (pos == null) continue;
                        if (pos.x > figure.getPosition().x && pos.y > figure.getPosition().y) figure.getMoves().RemoveAll(x => x != null && x.x > pos.x && x.y > pos.y);
                        if (pos.x > figure.getPosition().x && pos.y < figure.getPosition().y) figure.getMoves().RemoveAll(x => x != null && x.x > pos.x && x.y < pos.y);
                        if (pos.x < figure.getPosition().x && pos.y < figure.getPosition().y) figure.getMoves().RemoveAll(x => x != null && x.x < pos.x && x.y < pos.y);
                        if (pos.x < figure.getPosition().x && pos.y > figure.getPosition().y) figure.getMoves().RemoveAll(x => x != null && x.x < pos.x && x.y > pos.y);

                        figure.getMoves().Remove(pos);
                    }
                    if (chessboard.blackFigures.Count == 0 || chessboard.whiteFigures.Count == 0 || figure.getMoves().Count == 0) return null;
                    for (int i = 0; i < chessboard.blackFigures.Count; i++)
                    {
                        Position? pos = figure.getMoves().Find(x => x != null && chessboard.blackFigures[i].getPosition().x == x.x && chessboard.blackFigures[i].getPosition().y == x.y);
                        if (pos == null) continue;
                        if (pos.x > figure.getPosition().x && pos.y > figure.getPosition().y) figure.getMoves().RemoveAll(x => x != null && x.x > pos.x && x.y > pos.y);
                        if (pos.x > figure.getPosition().x && pos.y < figure.getPosition().y) figure.getMoves().RemoveAll(x => x != null && x.x > pos.x && x.y < pos.y);
                        if (pos.x < figure.getPosition().x && pos.y < figure.getPosition().y) figure.getMoves().RemoveAll(x => x != null && x.x < pos.x && x.y < pos.y);
                        if (pos.x < figure.getPosition().x && pos.y > figure.getPosition().y) figure.getMoves().RemoveAll(x => x != null && x.x < pos.x && x.y > pos.y);
                    }
                    return figure.getMoves();
                }
                for (int i = 0; i < chessboard.whiteFigures.Count; i++)
                {
                    Position? pos = figure.getMoves().Find(x => x != null && chessboard.whiteFigures[i].getPosition().x == x.x && chessboard.whiteFigures[i].getPosition().y == x.y);
                    if (pos == null) continue;
                    if (pos.x > figure.getPosition().x && pos.y > figure.getPosition().y) figure.getMoves().RemoveAll(x => x != null && x.x > pos.x && x.y > pos.y);
                    if (pos.x > figure.getPosition().x && pos.y < figure.getPosition().y) figure.getMoves().RemoveAll(x => x != null && x.x > pos.x && x.y < pos.y);
                    if (pos.x < figure.getPosition().x && pos.y < figure.getPosition().y) figure.getMoves().RemoveAll(x => x != null && x.x < pos.x && x.y < pos.y);
                    if (pos.x < figure.getPosition().x && pos.y > figure.getPosition().y) figure.getMoves().RemoveAll(x => x != null && x.x < pos.x && x.y > pos.y);
                }
                if (chessboard.blackFigures.Count == 0 || chessboard.whiteFigures.Count == 0 || figure.getMoves().Count == 0) return null;
                for (int i = 0; i < chessboard.blackFigures.Count; i++)
                {
                    Position? pos = figure.getMoves().Find(x => x != null && chessboard.blackFigures[i].getPosition().x == x.x && chessboard.blackFigures[i].getPosition().y == x.y);
                    if (pos == null) continue;
                    if (pos.x > figure.getPosition().x && pos.y > figure.getPosition().y) figure.getMoves().RemoveAll(x => x != null && x.x > pos.x && x.y > pos.y);
                    if (pos.x > figure.getPosition().x && pos.y < figure.getPosition().y) figure.getMoves().RemoveAll(x => x != null && x.x > pos.x && x.y < pos.y);
                    if (pos.x < figure.getPosition().x && pos.y < figure.getPosition().y) figure.getMoves().RemoveAll(x => x != null && x.x < pos.x && x.y < pos.y);
                    if (pos.x < figure.getPosition().x && pos.y > figure.getPosition().y) figure.getMoves().RemoveAll(x => x != null && x.x < pos.x && x.y > pos.y);

                    figure.getMoves().Remove(pos);
                }
            }
            if (figure.getName() == Const.kingName)
            {
                if (figure.getColor())
                {
                    for (int i = 0; i < chessboard.whiteFigures.Count; i++)
                    {
                        Position? pos = figure.getMoves().Find(x => x != null && chessboard.whiteFigures[i].getPosition().x == x.x && chessboard.whiteFigures[i].getPosition().y == x.y);
                        if (pos == null) continue;

                        figure.getMoves().Remove(pos);
                    }
                    return figure.getMoves();
                }
                for (int i = 0; i < chessboard.blackFigures.Count; i++)
                {
                    Position? pos = figure.getMoves().Find(x => x != null && chessboard.blackFigures[i].getPosition().x == x.x && chessboard.blackFigures[i].getPosition().y == x.y);
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
                        Position? pos = figure.getMoves().Find(x => x != null && chessboard.whiteFigures[i].getPosition().x == x.x && chessboard.whiteFigures[i].getPosition().y == x.y);
                        if (pos == null) continue;

                        figure.getMoves().Remove(pos);
                    }
                    return figure.getMoves();
                }
                for (int i = 0; i < chessboard.blackFigures.Count; i++)
                {
                    Position? pos = figure.getMoves().Find(x => x != null && chessboard.blackFigures[i].getPosition().x == x.x && chessboard.blackFigures[i].getPosition().y == x.y);
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
                        Position? pos = figure.getMoves().Find(x => x != null &&  chessboard.whiteFigures[i].getPosition().x == x.x && chessboard.whiteFigures[i].getPosition().y == x.y);
                        if (pos == null) continue;
                        if (pos.x > figure.getPosition().x && pos.y > figure.getPosition().y) figure.getMoves().RemoveAll(x => x != null && x.x > pos.x && x.y > pos.y);
                        if (pos.x > figure.getPosition().x && pos.y < figure.getPosition().y) figure.getMoves().RemoveAll(x => x != null && x.x > pos.x && x.y < pos.y);
                        if (pos.x < figure.getPosition().x && pos.y < figure.getPosition().y) figure.getMoves().RemoveAll(x => x != null && x.x < pos.x && x.y < pos.y);
                        if (pos.x < figure.getPosition().x && pos.y > figure.getPosition().y) figure.getMoves().RemoveAll(x => x != null && x.x < pos.x && x.y > pos.y);
                        if (pos.x < figure.getPosition().x && pos.y == figure.getPosition().y) figure.getMoves().RemoveAll(x => x != null && x.x < pos.x && x.y == pos.y);
                        if (pos.x > figure.getPosition().x && pos.y == figure.getPosition().y) figure.getMoves().RemoveAll(x => x != null && x.x > pos.x && x.y == pos.y);
                        if (pos.x == figure.getPosition().x && pos.y > figure.getPosition().y) figure.getMoves().RemoveAll(x => x != null && x.x == pos.x && x.y > pos.y);
                        if (pos.x == figure.getPosition().x && pos.y < figure.getPosition().y) figure.getMoves().RemoveAll(x => x != null && x.x == pos.x && x.y < pos.y);

                        figure.getMoves().Remove(pos);
                    }
                    for (int i = 0; i < chessboard.blackFigures.Count; i++)
                    {
                        Position? pos = figure.getMoves().Find(x => x != null && chessboard.blackFigures[i].getPosition().x == x.x && chessboard.blackFigures[i].getPosition().y == x.y);
                        if (pos == null) continue;
                        if (pos.x > figure.getPosition().x && pos.y > figure.getPosition().y) figure.getMoves().RemoveAll(x => x != null && x.x > pos.x && x.y > pos.y);
                        if (pos.x > figure.getPosition().x && pos.y < figure.getPosition().y) figure.getMoves().RemoveAll(x => x != null && x.x > pos.x && x.y < pos.y);
                        if (pos.x < figure.getPosition().x && pos.y < figure.getPosition().y) figure.getMoves().RemoveAll(x => x != null && x.x < pos.x && x.y < pos.y);
                        if (pos.x < figure.getPosition().x && pos.y > figure.getPosition().y) figure.getMoves().RemoveAll(x => x != null && x.x < pos.x && x.y > pos.y);
                        if (pos.x < figure.getPosition().x && pos.y == figure.getPosition().y) figure.getMoves().RemoveAll(x => x != null && x.x < pos.x && x.y == pos.y);
                        if (pos.x > figure.getPosition().x && pos.y == figure.getPosition().y) figure.getMoves().RemoveAll(x => x != null && x.x > pos.x && x.y == pos.y);
                        if (pos.x == figure.getPosition().x && pos.y > figure.getPosition().y) figure.getMoves().RemoveAll(x => x != null && x.x == pos.x && x.y > pos.y);
                        if (pos.x == figure.getPosition().x && pos.y < figure.getPosition().y) figure.getMoves().RemoveAll(x => x != null && x.x == pos.x && x.y < pos.y);
                    }
                    return figure.getMoves();
                }
                for (int i = 0; i < chessboard.whiteFigures.Count; i++)
                {
                    Position? pos = figure.getMoves().Find(x => x != null && chessboard.whiteFigures[i].getPosition().x == x.x && chessboard.whiteFigures[i].getPosition().y == x.y);
                    if (pos == null) continue;
                    if (pos.x > figure.getPosition().x && pos.y > figure.getPosition().y) figure.getMoves().RemoveAll(x =>x != null && x.x > pos.x && x.y > pos.y);
                    if (pos.x > figure.getPosition().x && pos.y < figure.getPosition().y) figure.getMoves().RemoveAll(x => x != null && x.x > pos.x && x.y < pos.y);
                    if (pos.x < figure.getPosition().x && pos.y < figure.getPosition().y) figure.getMoves().RemoveAll(x => x != null && x.x < pos.x && x.y < pos.y);
                    if (pos.x < figure.getPosition().x && pos.y > figure.getPosition().y) figure.getMoves().RemoveAll(x => x != null && x.x < pos.x && x.y > pos.y);
                    if (pos.x < figure.getPosition().x && pos.y == figure.getPosition().y) figure.getMoves().RemoveAll(x => x != null && x.x < pos.x && x.y == pos.y);
                    if (pos.x > figure.getPosition().x && pos.y == figure.getPosition().y) figure.getMoves().RemoveAll(x => x != null && x.x > pos.x && x.y == pos.y);
                    if (pos.x == figure.getPosition().x && pos.y > figure.getPosition().y) figure.getMoves().RemoveAll(x => x != null && x.x == pos.x && x.y > pos.y);
                    if (pos.x == figure.getPosition().x && pos.y < figure.getPosition().y) figure.getMoves().RemoveAll(x => x != null && x.x == pos.x && x.y < pos.y);

                }
                if (chessboard.blackFigures.Count == 0 || chessboard.whiteFigures.Count == 0 || figure.getMoves().Count == 0) return null;
                for (int i = 0; i < chessboard.blackFigures.Count; i++)
                {
                    Position? pos = figure.getMoves().Find(x => x != null && chessboard.blackFigures[i].getPosition().x == x.x && chessboard.blackFigures[i].getPosition().y == x.y);
                    if (pos == null) continue;
                    if (pos.x > figure.getPosition().x && pos.y > figure.getPosition().y) figure.getMoves().RemoveAll(x => x != null && x.x > pos.x && x.y > pos.y);
                    if (pos.x > figure.getPosition().x && pos.y < figure.getPosition().y) figure.getMoves().RemoveAll(x => x != null && x.x > pos.x && x.y < pos.y);
                    if (pos.x < figure.getPosition().x && pos.y < figure.getPosition().y) figure.getMoves().RemoveAll(x => x != null && x.x < pos.x && x.y < pos.y);
                    if (pos.x < figure.getPosition().x && pos.y > figure.getPosition().y) figure.getMoves().RemoveAll(x => x != null && x.x < pos.x && x.y > pos.y);
                    if (pos.x < figure.getPosition().x && pos.y == figure.getPosition().y) figure.getMoves().RemoveAll(x => x != null && x.x < pos.x && x.y == pos.y);
                    if (pos.x > figure.getPosition().x && pos.y == figure.getPosition().y) figure.getMoves().RemoveAll(x => x != null && x.x > pos.x && x.y == pos.y);
                    if (pos.x == figure.getPosition().x && pos.y > figure.getPosition().y) figure.getMoves().RemoveAll(x => x != null && x.x == pos.x && x.y > pos.y);
                    if (pos.x == figure.getPosition().x && pos.y < figure.getPosition().y) figure.getMoves().RemoveAll(x => x != null && x.x == pos.x && x.y < pos.y);

                    figure.getMoves().Remove(pos);
                }
            }
            if (figure.getName() == Const.pawnName)
            {
                if (figure.getColor())
                {
                    for (int i = 0; i < chessboard.whiteFigures.Count; i++)
                    {

                        Position? pos = figure.getMoves().Find(x => x != null && x.x == chessboard.whiteFigures[i].getPosition().x && x.y == chessboard.whiteFigures[i].getPosition().y);
                        if (pos == null) continue;
                        figure.getMoves().Remove(pos);
                        figure.getMoves().RemoveAll(x => x != null && x.x == pos.x+1 && x.y == pos.y);
                     }
                    List<Position> toRemove = new List<Position>();
                    for (int i = 0; i < figure.getMoves().Count; i++)
                    {

                        if (figure.getMoves()[i] == null) continue;

                        if (figure.getMoves()[i].x == figure.getPosition().x + 1 && figure.getMoves()[i].y == figure.getPosition().y)
                        {
                            Figure? f = chessboard.blackFigures.Find(x => x != null && x.getPosition().x == figure.getMoves()[i].x && x.getPosition().y == figure.getMoves()[i].y);
                            if (f == null) continue;
                            toRemove.Add(figure.getMoves()[i]);
                            toRemove.Add(new Position(figure.getMoves()[i].x + 1, figure.getMoves()[i].y));
                        }

                        if (figure.getMoves()[i].x == figure.getPosition().x + 2 && figure.getMoves()[i].y == figure.getPosition().y)
                        {
                            Figure? f = chessboard.blackFigures.Find(x => x != null && x.getPosition().x == figure.getMoves()[i].x && x.getPosition().y == figure.getMoves()[i].y);
                            if (f == null) continue;
                            toRemove.Add(figure.getMoves()[i]);
                        }
                        
                        if (figure.getMoves()[i].x == figure.getPosition().x + 1 && figure.getMoves()[i].y != figure.getPosition().y)
                        {
                            Figure? f = chessboard.blackFigures.Find(x => x != null && x.getPosition().x == figure.getMoves()[i].x && x.getPosition().y == figure.getMoves()[i].y);
                            if (f != null) continue;
                            toRemove.Add(figure.getMoves()[i]);
                        }
                    }
                    if (chessboard.blackFigures.Count == 0 || chessboard.whiteFigures.Count == 0 || figure.getMoves().Count == 0) return null;
                    toRemove.ForEach(x => figure.getMoves().RemoveAll(y => x != null && x.x == y.x && x.y == y.y));
                    if (chessboard.enPassant != null && chessboard.whiteEnPassant)
                        if (chessboard.enPassant.x == figure.getPosition().x + 1 && (chessboard.enPassant.y == figure.getPosition().y + 1 || chessboard.enPassant.y == figure.getPosition().y - 1))
                            figure.getMoves().Add(chessboard.enPassant);
                }
                if (!figure.getColor())
                {
                    for (int i = 0; i < chessboard.blackFigures.Count; i++)
                    {
                        Position? pos = figure.getMoves().Find(x => x != null && x.x == chessboard.blackFigures[i].getPosition().x && x.y == chessboard.blackFigures[i].getPosition().y);
                        if (pos == null) continue;
                        figure.getMoves().Remove(pos);
                    }
                    List<Position> toRemove = new List<Position>();
                    for (int i = 0; i < figure.getMoves().Count; i++)
                    {
                        if (figure.getMoves()[i] == null) continue;

                        if (figure.getMoves()[i].x == figure.getPosition().x - 1 && figure.getMoves()[i].y == figure.getPosition().y)
                        {
                            Figure? f = chessboard.whiteFigures.Find(x => i < figure.getMoves().Count && x != null && x.getPosition().x == figure.getMoves()[i].x && x.getPosition().y == figure.getMoves()[i].y);
                            if (i < figure.getMoves().Count && f == null) continue;
                            toRemove.Add(figure.getMoves()[i]);
                            toRemove.Add(new Position(figure.getMoves()[i].x - 1, figure.getMoves()[i].y));
                        }

                        if (figure.getMoves()[i].x == figure.getPosition().x - 2 && figure.getMoves()[i].y == figure.getPosition().y)
                        {
                            Figure? f = chessboard.whiteFigures.Find(x => i < figure.getMoves().Count && x != null && x.getPosition().x == figure.getMoves()[i].x && x.getPosition().y == figure.getMoves()[i].y);
                            if (i < figure.getMoves().Count && f == null) continue;
                            toRemove.Add(figure.getMoves()[i]);
                        }
                        if (figure.getMoves()[i].x == figure.getPosition().x - 1 && figure.getMoves()[i].y != figure.getPosition().y)
                        {
                            Figure? f = chessboard.whiteFigures.Find(x => i < figure.getMoves().Count && x != null && x.getPosition().x == figure.getMoves()[i].x && x.getPosition().y == figure.getMoves()[i].y);
                            if (i < figure.getMoves().Count && f != null) continue;
                            toRemove.Add(figure.getMoves()[i]);
                        }
                    }
                    
                    toRemove.ForEach(x => figure.getMoves().RemoveAll(y => x != null && x.x == y.x && x.y == y.y));
                    if (chessboard.enPassant != null && !chessboard.whiteEnPassant)
                        if (chessboard.enPassant.x == figure.getPosition().x - 1 && (chessboard.enPassant.y == figure.getPosition().y + 1 || chessboard.enPassant.y == figure.getPosition().y - 1))
                            figure.getMoves().Add(chessboard.enPassant);
                }
                return figure.getMoves();

            }
            return figure.getMoves();
        }
  
        public static bool isCheck(bool whiteKing, Chessboard chessboard)
      {
            Position? position;
            Figure? f;
            if (whiteKing)
            {
                position = chessboard.whiteFigures.Find(x => x.getName() == Const.kingName)!.getPosition();
                f = chessboard.blackFigures.Find(x => x != null && x!.getMoves() != null && x!.getMoves()!.Find(y => y!.x == position.x && y!.y == position.y) != null);
                if (f == null) return false;
                return true;
            }
            position = chessboard.blackFigures.Find(x => x.getName() == Const.kingName)!.getPosition();
            f = chessboard.whiteFigures.Find(x => x != null && x!.getMoves() != null &&  x!.getMoves()!.Find(y => y!.x == position.x && y!.y == position.y) != null);
            if (f == null) return false;
            return true;
            
        }

        public static List<Position> removeIllegalMoves(Figure figure, Chessboard chessboard)
        {
            if(figure.getMoves() == null) return figure.getMoves();
            figure.getMoves().RemoveAll(x => x != null && alternativeChessboard(figure, x, chessboard));
            return figure.getMoves();
        }
        public static void promotePawn(Figure pawn, string figure, Chessboard chessboard)
        {
            if(figure == Const.bishopName)
            {
                Bishop bishop = new Bishop(pawn.getPosition().x, pawn.getPosition().y, pawn.getColor());
                if (pawn.getColor())
                {
                    chessboard.whiteFigures.Remove(pawn);
                    chessboard.whiteFigures.Add(bishop);
                }
                else
                {
                    chessboard.blackFigures.Remove(pawn);
                    chessboard.blackFigures.Add(bishop);
                }
                return;
            }
            if (figure == Const.rookName)
            {
                Rook rook = new Rook(pawn.getPosition().x, pawn.getPosition().y, pawn.getColor());
                if (pawn.getColor())
                {
                    chessboard.whiteFigures.Remove(pawn);
                    chessboard.whiteFigures.Add(rook);
                }
                else
                {
                    chessboard.blackFigures.Remove(pawn);
                    chessboard.blackFigures.Add(rook);
                }
                return;
            }
            if (figure == Const.queenName)
            {
                Queen queen = new Queen(pawn.getPosition().x, pawn.getPosition().y, pawn.getColor());
                if (pawn.getColor())
                {
                    chessboard.whiteFigures.Remove(pawn);
                    chessboard.whiteFigures.Add(queen);
                }
                else
                {
                    chessboard.blackFigures.Remove(pawn);
                    chessboard.blackFigures.Add(queen);
                }
                return;
            }
            if (figure == Const.knightName)
            {
                Knight knight = new Knight(pawn.getPosition().x, pawn.getPosition().y, pawn.getColor());
                if (pawn.getColor())
                {
                    chessboard.whiteFigures.Remove(pawn);
                    chessboard.whiteFigures.Add(knight);
                }
                else
                {
                    chessboard.blackFigures.Remove(pawn);
                    chessboard.blackFigures.Add(knight);
                }
                return;
            }
        }
        public static void castleMoves(Chessboard chessboard)
        {
            Figure? wk = chessboard.whiteFigures.Find(x => x.getName() == Const.kingName);
            Figure? bk = chessboard.blackFigures.Find(x => x.getName() == Const.kingName);
            Figure? shortWhiteRook = chessboard.whiteFigures.Find(x => x.getName() == Const.rookName && x.getPosition().x == 0 && x.getPosition().y == 0);
            Figure? longWhiteRook = chessboard.whiteFigures.Find(x => x.getName() == Const.rookName && x.getPosition().x == 0 && x.getPosition().y == 7);
            Figure? shortBlackRook = chessboard.blackFigures.Find(x => x.getName() == Const.rookName && x.getPosition().x == 7 && x.getPosition().y == 0);
            Figure? longBlackRook = chessboard.blackFigures.Find(x => x.getName() == Const.rookName && x.getPosition().x == 7 && x.getPosition().y == 7);
            
            if(wk != null && wk.isFirstMove() && !isCheck(wk.getColor(), chessboard))
            {
                Position kingPos = new Position(0, 1);
                Position rookPos = new Position(0, 2);
                kingPos.whiteShortCastle = true;
                Figure? f, f2;
                f = chessboard.blackFigures.Find(x => x.getMoves().Find(y => (y.x == kingPos.x && y.y == kingPos.y) || (y.x == rookPos.x && y.y == rookPos.y)) != null);
                f2 = chessboard.whiteFigures.Find(x => (x.getPosition().x == kingPos.x && x.getPosition().y == kingPos.y) || (x.getPosition().x == rookPos.x && x.getPosition().y == rookPos.y));
                if (f == null && f2 == null) wk.getMoves().Add(kingPos);
                kingPos = new Position(0, 5);
                rookPos = new Position(0, 4);
                Position? rookPass = new Position(0, 6);
                kingPos.whiteLongCastle = true;
                f = null;
                f2 = null;
                f = chessboard.blackFigures.Find(x => x.getMoves().Find(y => (y.x == kingPos.x && y.y == kingPos.y) || (y.x == rookPos.x && y.y == rookPos.y)) != null);
                f2 = chessboard.whiteFigures.Find(x => (x.getPosition().x == kingPos.x && x.getPosition().y == kingPos.y) || (x.getPosition().x == rookPos.x && x.getPosition().y == rookPos.y) || (x.getPosition().x == rookPass.x && x.getPosition().y == rookPass.y));
                if (f == null && f2 == null) wk.getMoves().Add(kingPos);
            }
            if (bk != null && bk.isFirstMove() && !isCheck(bk.getColor(), chessboard))
            {
                Position kingPos = new Position(7, 1);
                Position rookPos = new Position(7, 2);
                kingPos.blackShortCastle = true;
                Figure? f, f2;
                f = chessboard.whiteFigures.Find(x => x.getMoves() != null && x.getMoves().Find(y => (y.x == kingPos.x && y.y == kingPos.y) || (y.x == rookPos.x && y.y == rookPos.y)) != null);
                f2 = chessboard.blackFigures.Find(x => (x.getPosition().x == kingPos.x && x.getPosition().y == kingPos.y) || (x.getPosition().x == rookPos.x && x.getPosition().y == rookPos.y));
                if (f == null && f2 == null) bk.getMoves().Add(kingPos);
                kingPos = new Position(7, 5);
                rookPos = new Position(7, 4);
                Position? rookPass = new Position(7, 6);
                kingPos.blackLongCastle = true;
                f = null;
                f2 = null;
                f = chessboard.whiteFigures.Find(x => x.getMoves() != null && x.getMoves().Find(y => (y.x == kingPos.x && y.y == kingPos.y) || (y.x == rookPos.x && y.y == rookPos.y)) != null);
                f2 = chessboard.blackFigures.Find(x => (x.getPosition().x == kingPos.x && x.getPosition().y == kingPos.y) || (x.getPosition().x == rookPos.x && x.getPosition().y == rookPos.y) || (x.getPosition().x == rookPass.x && x.getPosition().y == rookPass.y));
                if (f == null && f2 == null) bk.getMoves().Add(kingPos);
            }
        }
        public static void makeCastle(Position position, Chessboard chessboard)
        {
            if (position == null) return;
            if(position.blackLongCastle)
            {
                Figure? f = chessboard.blackFigures.Find(x => x.getName() == Const.rookName && x.getPosition().x == 7 && x.getPosition().y == 7);
                if (f != null) f.setPosition(new Position(7, 4));
                return;
            }
            if (position.blackShortCastle)
            {
                Figure? f = chessboard.blackFigures.Find(x => x.getName() == Const.rookName && x.getPosition().x == 7 && x.getPosition().y == 0);
                if (f != null) f.setPosition(new Position(7, 2));
                return;
            }
            if (position.whiteLongCastle)
            {
                Figure? f = chessboard.whiteFigures.Find(x => x.getName() == Const.rookName && x.getPosition().x == 0 && x.getPosition().y == 7);
                if (f != null) f.setPosition(new Position(0, 4));
                return;
            }
            if (position.whiteShortCastle)
            {
                Figure? f = chessboard.whiteFigures.Find(x => x.getName() == Const.rookName && x.getPosition().x == 0 && x.getPosition().y == 0);
                if (f != null) f.setPosition(new Position(0, 2));
                return;
            }
        }
        
        public static bool isMate(Chessboard chessboard, bool color)
        {
            int total = 0;
            if (color) chessboard.whiteFigures.ForEach(x => total += x.moves.Count);
            if (!color) chessboard.blackFigures.ForEach(x => total += x.moves.Count);

            return total == 0;
        }
    }  
}
