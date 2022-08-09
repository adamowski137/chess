using chess137.Figures;

namespace ChessApi
{
    public class ChessGame
    {
        public  List <FiguresView>? Figures { get; set; }
        public AdditionalView additional { get; set; }
    }
}
