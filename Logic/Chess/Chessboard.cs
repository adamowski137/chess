using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using chess137.Figures;

namespace chess137.Chess
{
     public class Chessboard
    {
        int move;
        bool whiteMove;
        public  List<Figure> whiteFigures = new List<Figure>();
        public List<Figure> blackFigures = new List<Figure>();
        public Figure? selectedFigure;

        public List <Position>? whitePositions;
        public List <Position>? blackPositions;

        public Chessboard()
        {

            whiteFigures.Add(new Rook(0, 0, true, 0));
            whiteFigures.Add(new Knight(0, 1, true, 1));
            whiteFigures.Add(new Bishop(0, 2, true, 2));
            whiteFigures.Add(new Queen(0, 3, true, 3));
            whiteFigures.Add(new King(0, 4, true, 4));
            whiteFigures.Add(new Bishop(0, 5, true, 5));
            whiteFigures.Add(new Knight(0, 6, true, 6));
            whiteFigures.Add(new Rook(0, 7, true, 7));
            whiteFigures.Add(new Pawn(1, 0, true, 8));
            whiteFigures.Add(new Pawn(1, 1, true, 9));
            whiteFigures.Add(new Pawn(1, 2, true, 10));
            whiteFigures.Add(new Pawn(1, 3, true, 11));
            whiteFigures.Add(new Pawn(1, 4, true, 12));
            whiteFigures.Add(new Pawn(1, 5, true, 13));
            whiteFigures.Add(new Pawn(1, 6, true, 14));
            whiteFigures.Add(new Pawn(1, 7, true, 15));


            blackFigures.Add(new Rook(7, 0, false, 16));
            blackFigures.Add(new Knight(7, 1, false, 17));
            blackFigures.Add(new Bishop(7, 2, false, 18));
            blackFigures.Add(new Queen(7, 3, false, 19));
            blackFigures.Add(new King(7, 4, false, 20));
            blackFigures.Add(new Bishop(7, 5, false, 21));
            blackFigures.Add(new Knight(7, 6, false, 22));
            blackFigures.Add(new Rook(7, 7, false, 23));
            blackFigures.Add(new Pawn(6, 0, false, 24));
            blackFigures.Add(new Pawn(6, 1, false, 25));
            blackFigures.Add(new Pawn(6, 2, false, 26));
            blackFigures.Add(new Pawn(6, 3, false, 27));
            blackFigures.Add(new Pawn(6, 4, false, 28));
            blackFigures.Add(new Pawn(6, 5, false, 29));
            blackFigures.Add(new Pawn(6, 6, false, 30));
            blackFigures.Add(new Pawn(6, 7, false, 31));
            
            move = 0;
            whiteMove = true;
        }

        public Position getKingPosition(bool isWhite) {

            if (isWhite) return whiteFigures.Find(x => x.getName() == Const.kingName)!.getPosition();

            return blackFigures.Find(x => x.getName() == Const.kingName)!.getPosition();
        }

        private void clearPositions()
        {
            whitePositions!.Clear();
            blackPositions!.Clear();
        }
        
        private void setPositions()
        {
            whiteFigures.ForEach(x => whitePositions!.AddRange(x.Positions!));
            blackFigures.ForEach(x => blackPositions!.AddRange(x.Positions!));
        }

        public void nextTurn()
        {
            this.move++;
            this.whiteMove = !this.whiteMove;
            clearPositions();
        }
    }
}
