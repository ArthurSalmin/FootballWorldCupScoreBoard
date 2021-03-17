using System;
using System.Collections.Generic;

namespace FootballWorldCupScoreBoard
{
    public interface IGameStorage
    {
        GameVo CreateGame(GameVo game);
        bool DeleteGame(Guid gameId);
        GameVo UpdateGame(GameVo game);
        GameVo GetGameById(Guid gameId);
        List<GameVo> GetGames();
    }
}