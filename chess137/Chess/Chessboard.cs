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
        public Figure [,] chessBoard = new Figure [Const.height, Const.width];
        public Chessboard()
        {
            chessBoard[0, 0] = new Rook(0, 0, true);
            chessBoard[0, 1] = new Knight(0, 1, true);
            chessBoard[0, 2] = new Bishop(0, 2, true);
            chessBoard[0, 3] = new Queen(0, 3, true);
            chessBoard[0, 4] = new King(0, 4, true);
            chessBoard[0, 5] = new Bishop(0, 5, true);
            chessBoard[0, 6] = new Knight(0, 6, true);
            chessBoard[0, 7] = new Rook(0, 7, true);
            chessBoard[1, 0] = new Pawn(1, 0, true);
            chessBoard[1, 1] = new Pawn(1, 1, true);
            chessBoard[1, 2] = new Pawn(1, 2, true);
            chessBoard[1, 3] = new Pawn(1, 3, true);
            chessBoard[1, 4] = new Pawn(1, 4, true);
            chessBoard[1, 5] = new Pawn(1, 5, true);
            chessBoard[1, 6] = new Pawn(1, 6, true);
            chessBoard[1, 7] = new Pawn(1, 7, true);
            chessBoard[7, 0] = new Rook(7, 0, false);
            chessBoard[7, 1] = new Knight(7, 1, false);
            chessBoard[7, 2] = new Bishop(7, 2, false);
            chessBoard[7, 3] = new Queen(7, 3, false);
            chessBoard[7, 4] = new King(7, 4, false);
            chessBoard[7, 5] = new Bishop(7, 5, false);
            chessBoard[7, 6] = new Knight(7, 6, false);
            chessBoard[7, 7] = new Rook(7, 7, false);
            chessBoard[6, 0] = new Pawn(6, 0, false);
            chessBoard[6, 1] = new Pawn(6, 1, false);
            chessBoard[6, 2] = new Pawn(6, 2, false);
            chessBoard[6, 3] = new Pawn(6, 3, false);
            chessBoard[6, 4] = new Pawn(6, 4, false);
            chessBoard[6, 5] = new Pawn(6, 5, false);
            chessBoard[6, 6] = new Pawn(6, 6, false);
            chessBoard[6, 7] = new Pawn(6, 7, false);
        }
    }
}
