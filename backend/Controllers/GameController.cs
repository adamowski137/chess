﻿using Microsoft.AspNetCore.Mvc;
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
            //Game.getChessboard().blackFigures.ForEach(x => x.moves  = x.updateMoves(Game.getChessboard()));
            //Game.getChessboard().whiteFigures.ForEach(x => x.moves  = x.updateMoves(Game.getChessboard()));
            //int i = Game.getChessboard().whiteFigures.Count;
            return GameConverter.getChessGame(Game.newGame());
        }

        [HttpGet("start")]
        public ChessGame StartGame()
        {
            return GameConverter.getChessGame(Game.getChessboard());
        }

        [HttpPost("move")]
        public ChessGame MakeMove([FromBody] Move rec)
        {
            Figure? f;
            Position? Move = new Position(rec.MoveX, rec.MoveY);
            f = Game.getChessboard().whiteFigures.Find(x => x.getPosition().x == rec.PosX && x.getPosition().y == rec.PosY);
            if (f == null)
                f = Game.getChessboard().blackFigures.Find(x => x.getPosition().x == rec.PosX && x.getPosition().y == rec.PosY);
            if (f == null) return null;
            Move = f.getMoves().Find(x => x.x == Move.x && x.y == Move.y);
            if (Move == null) return null;
            Game.makeMove(f, Move);
            return GameConverter.getChessGame(Game.getChessboard());
        }
        [HttpPost("promote")]
        public ChessGame Promote([FromBody] Move rec)
        {
            
            Figure? f;
            Position? Move = new Position(rec.MoveX, rec.MoveY);
            f = Game.getChessboard().whiteFigures.Find(x => x.getPosition().x == rec.PosX && x.getPosition().y == rec.PosY);
            if (f == null)
                f = Game.getChessboard().blackFigures.Find(x => x.getPosition().x == rec.PosX && x.getPosition().y == rec.PosY);
            if (f == null) return null;
            Move = f.getMoves().Find(x => x.x == Move.x && x.y == Move.y);
            if (Move == null) return null;
            Game.makeMove(f, Move);
            if (rec.promote == null) return null;
            Functions.promotePawn(f, rec.promote, Game.getChessboard());
            return GameConverter.getChessGame(Game.getChessboard());
        }


    }
}
