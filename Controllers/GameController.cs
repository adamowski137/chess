using Microsoft.AspNetCore.Mvc;
using ChessApi.Converters;
using chess137.Chess;

namespace ChessApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : ControllerBase
    {
        [HttpGet]
        public ChessGame Get()
        { 
            return GameConverter.getChessGame(Game.getChessboard());
        }

        [HttpGet("start")]
        public ChessGame StartGame()
        {
            Game.setChessboard(new Chessboard());
            return GameConverter.getChessGame(Game.getChessboard());
        }
    }
}
