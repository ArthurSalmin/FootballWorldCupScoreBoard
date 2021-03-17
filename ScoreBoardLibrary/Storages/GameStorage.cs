using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballWorldCupScoreBoard.Storages
{
    public class GameStorage : IGameStorage
    {
        private List<GameVo> games = new List<GameVo>();
        public GameVo CreateGame(GameVo game)
        {
            var teamId = Guid.NewGuid();
            game.GameId = teamId;
            this.games.Add(game);
            return game;
        }

        public bool DeleteGame(Guid gameId)
        {
            var team = this.games.FirstOrDefault(_ => _.GameId == gameId);
            if (team == null) return false;

            this.games.Remove(team);
            return true;
        }

        public GameVo UpdateGame(GameVo game)
        {
            var existedGame = this.games.FirstOrDefault(_ => _.GameId == game.GameId);
            if (existedGame == null) return null;

            existedGame.HomeTeamId = game.HomeTeamId;
            existedGame.AwayTeamId = game.AwayTeamId;
            existedGame.HomeTeamScore = game.HomeTeamScore;
            existedGame.AwayTeamScore = game.AwayTeamScore;
            existedGame.Started = game.Started;
            
            return existedGame;
        }

        public GameVo GetGameById(Guid gameId)
        {
            return this.games.FirstOrDefault(_ => _.GameId == gameId);
        }

        public List<GameVo> GetGames()
        {
            return this.games;
        }
    }
}