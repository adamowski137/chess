using Microsoft.AspNetCore.Mvc;
using ChessApi.Converters;
using chess137.Chess;
using chess137;
using chess137.Figures;

namespace ChessApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : ControllerBase
    {
        [HttpGet]
        public ChessGame Get()
        {
            Game.getChessboard().blackFigures.ForEach(x => x.updateMoves(Game.getChessboard()));
            Game.getChessboard().whiteFigures.ForEach(x => x.updateMoves(Game.getChessboard()));
            return GameConverter.getChessGame(Game.getChessboard());
        }

        [HttpGet("start")]
        public ChessGame StartGame()
        {
            Game.setChessboard(new Chessboard());
            return GameConverter.getChessGame(Game.getChessboard());
        }

        [HttpPost("move")]
        public ChessGame MakeMove([FromBody]Move rec)
        {
            Figure f;
            f = Game.getChessboard().whiteFigures.Find(x => x.getPosition().x == rec.PosX && x.getPosition().y == rec.PosY);
            if (f == null) f = Game.getChessboard().blackFigures.Find(x => x.getPosition().x == rec.PosX && x.getPosition().y == rec.PosY);
            Game.setChessboard(Functions.makeMove(f, new Position(rec.MoveX, rec.MoveY), Game.getChessboard()));
            return GameConverter.getChessGame(Game.getChessboard());
        }
    }
}
