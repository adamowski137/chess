using System;
using chess137.Chess;
using chess137.Figures;

namespace chess137
{
    

    internal class Program
    {
        static void Main(string[] args)
        {
            Chessboard chessboard = new Chessboard();
            int value = Functions.countValue(chessboard);
            Console.WriteLine(value);
        }
    }
}
