using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using chess137.Chess;

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
                    if (chessboard.chessBoard[i,j].getColor())   value += chessboard.chessBoard[i,j].getValue();
                    if (chessboard.chessBoard[i,j].getColor() == false)   value -= chessboard.chessBoard[i,j].getValue();
                }
            }
            return value;
        }
    }
}
