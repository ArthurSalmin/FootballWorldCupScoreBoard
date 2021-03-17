using System;
using System.Collections.Generic;
using System.Linq;
using FootballWorldCupScoreBoard.Storages;

namespace FootballWorldCupScoreBoard
{
    public class ScoreBoard : IScoreboard
    {
        private readonly GameStorage _gameStorage;
        private readonly TeamStorage _teamStorage;

        public ScoreBoard(TeamStorage teamStorage, GameStorage gameStorage)
        {
            _teamStorage = teamStorage;
            _gameStorage = gameStorage;
        }

        public GameVo StartGame(TeamVo homeTeam, TeamVo awayTeam)
        {
            var game = new GameVo
            {
                HomeTeamId = homeTeam.TeamId,
                AwayTeamId = awayTeam.TeamId,
                AwayTeamScore = 0,
                HomeTeamScore = 0,
                Started = new DateTime()
            };
            return _gameStorage.CreateGame(game);
        }

        public IEnumerable<string> GetSummaryByAddedDate()
        {
            var games = _gameStorage.GetGames();
            var teams = _teamStorage.GetTeams();

            var resultSummary = games
                .OrderBy(_ => _.Started)
                .Select(_ => new GameSummary
                {
                    HomeTeamName = teams.FirstOrDefault(t => t.TeamId == _.HomeTeamId)?.TeamName,
                    AwayTeamName = teams.FirstOrDefault(t => t.TeamId == _.AwayTeamId)?.TeamName,
                    HomeTeamScore = _.HomeTeamScore,
                    AwayTeamScore = _.AwayTeamScore
                }.ToString());
            return resultSummary;
        }

        public void UpdateScore(Guid gameId, int homeTeamScore, int awayTeamScore)
        {
            var game = _gameStorage.GetGames().FirstOrDefault(_ => _.GameId == gameId);
            if (game == null)
            {
                throw new KeyNotFoundException($"Game with id {gameId} not found");
            }
            
            game.HomeTeamScore = homeTeamScore;
            game.AwayTeamScore = awayTeamScore;

            _gameStorage.UpdateGame(game);
        }

        public void FinishGame(Guid gameId)
        {
            var deleted = _gameStorage.DeleteGame(gameId);

            if (!deleted)
            {
                throw new KeyNotFoundException($"Game with id {gameId} not found");
            }
        }
    }
}