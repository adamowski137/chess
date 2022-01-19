using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using chess137.Figures;

namespace chess137.Chess
{
     class Chessboard
    {
        int move;
        bool whiteMove;
        public  List<Figure> whiteFigures = new List<Figure>();
        public List<Figure> blackFigures = new List<Figure>();
        public Figure selectedFigure;
        public Chessboard()
        {

            whiteFigures.Add(new Rook(0, 0, true));
            whiteFigures.Add(new Knight(0, 1, true));
            whiteFigures.Add(new Bishop(0, 2, true));
            whiteFigures.Add(new Queen(0, 3, true));
            whiteFigures.Add(new King(0, 4, true));
            whiteFigures.Add(new Bishop(0, 5, true));
            whiteFigures.Add(new Knight(0, 6, true));
            whiteFigures.Add(new Rook(0, 7, true));
            whiteFigures.Add(new Pawn(1, 0, true));
            whiteFigures.Add(new Pawn(1, 1, true));
            whiteFigures.Add(new Pawn(1, 2, true));
            whiteFigures.Add(new Pawn(1, 3, true));
            whiteFigures.Add(new Pawn(1, 4, true));
            whiteFigures.Add(new Pawn(1, 5, true));
            whiteFigures.Add(new Pawn(1, 6, true));
            whiteFigures.Add(new Pawn(1, 7, true));


            blackFigures.Add(new Rook(7, 0, false));
            blackFigures.Add(new Knight(7, 1, false));
            blackFigures.Add(new Bishop(7, 2, false));
            blackFigures.Add(new Queen(7, 3, false));
            blackFigures.Add(new King(7, 4, false));
            blackFigures.Add(new Bishop(7, 5, false));
            blackFigures.Add(new Knight(7, 6, false));
            blackFigures.Add(new Rook(7, 7, false));
            blackFigures.Add(new Pawn(6, 0, false));
            blackFigures.Add(new Pawn(6, 1, false));
            blackFigures.Add(new Pawn(6, 2, false));
            blackFigures.Add(new Pawn(6, 3, false));
            blackFigures.Add(new Pawn(6, 4, false));
            blackFigures.Add(new Pawn(6, 5, false));
            blackFigures.Add(new Pawn(6, 6, false));
            blackFigures.Add(new Pawn(6, 7, false));
            
            move = 0;
            whiteMove = true;
        }

        public Position getKingPosition(bool isWhite) {
            King king = new King(1, 1, true);
            if (isWhite) return whiteFigures.Find(x => x.GetType() == king.GetType()).getPosition();
            return blackFigures.Find(x => x.GetType() == king.GetType()).getPosition();
        }

        public void nextTurn()
        {
            this.move++;
            this.whiteMove = !this.whiteMove;
        }
    }
}
