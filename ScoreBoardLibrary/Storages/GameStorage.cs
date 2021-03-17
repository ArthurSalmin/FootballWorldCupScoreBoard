using System;
using System.Collections.Generic;
using System.Linq;
using FootballWorldCupScoreBoard.Interfaces;
using FootballWorldCupScoreBoard.ValueObjects;

namespace FootballWorldCupScoreBoard.Storages
{
    public class GameStorage : IGameStorage
    {
        private readonly List<GameVo> _games = new List<GameVo>();

        public GameVo CreateGame(GameVo game)
        {
            var teamId = Guid.NewGuid();
            game.GameId = teamId;
            _games.Add(game);
            return game;
        }

        public bool DeleteGame(Guid gameId)
        {
            var team = _games.FirstOrDefault(_ => _.GameId == gameId);
            if (team == null)
            {
                return false;
            }

            return _games.Remove(team);
        }

        public GameVo UpdateGame(GameVo game)
        {
            var existedGame = _games.FirstOrDefault(_ => _.GameId == game.GameId);
            if (existedGame == null)
            {
                return null;
            }

            existedGame.HomeTeamId = game.HomeTeamId;
            existedGame.AwayTeamId = game.AwayTeamId;
            existedGame.HomeTeamScore = game.HomeTeamScore;
            existedGame.AwayTeamScore = game.AwayTeamScore;
            existedGame.Started = game.Started;

            return existedGame;
        }

        public GameVo GetGameById(Guid gameId)
        {
            return _games.FirstOrDefault(_ => _.GameId == gameId);
        }

        public List<GameVo> GetGames()
        {
            return _games;
        }
    }
}