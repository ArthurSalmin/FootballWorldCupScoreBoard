using System;
using System.Collections.Generic;
using FootballWorldCupScoreBoard.ValueObjects;

namespace FootballWorldCupScoreBoard.Interfaces
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