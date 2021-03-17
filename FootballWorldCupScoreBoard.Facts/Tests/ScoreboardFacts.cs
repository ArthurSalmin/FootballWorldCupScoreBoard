using System;
using System.Linq;
using FluentAssertions;
using FootballWorldCupScoreBoard.Facts.TestUtilities;
using FootballWorldCupScoreBoard.Storages;
using FootballWorldCupScoreBoard.ValueObjects;
using FootballWorldCupScoreBoard.Managers;

using Xunit;

namespace FootballWorldCupScoreBoard.Facts.Tests
{
    public class ScoreboardFacts
    {
        private readonly GameStorage _gameStorage;
        private readonly TeamStorage _teamStorage;
        private readonly ScoreBoard _tested;
        
        private readonly DateTime _now = new DateTime(2021, 03, 16);

        public ScoreboardFacts()
        {
            _gameStorage = new GameStorage();
            _teamStorage = new TeamStorage();
            _tested = new ScoreBoard(this._teamStorage, this._gameStorage);
        }

        [Fact]
        public void ReturnsGameOnStartGame()
        {
            var team1 = new TeamVo
            {
                TeamId = 1,
                TeamName = "Spain"
            };

            var team2 = new TeamVo
            {
                TeamId = 2,
                TeamName = "Italy"
            };

            var game = _tested.StartGame(team1, team2);

            game.HomeTeamId.Should().Be(team1.TeamId);
            game.AwayTeamId.Should().Be(team2.TeamId);
            game.HomeTeamScore.Should().Be(0);
            game.AwayTeamScore.Should().Be(0);
        }

        [Fact]
        public void ChangesScoreOnUpdateScore_WhenGameExists()
        {
            var team1 = new TeamVo
            {
                TeamId = 1,
                TeamName = "Spain"
            };

            var team2 = new TeamVo
            {
                TeamId = 2,
                TeamName = "Italy"
            };

            var game = new GameVo
            {
                GameId = 1.ToGuid(),
                HomeTeamId = team1.TeamId,
                AwayTeamId = team2.TeamId,
                AwayTeamScore = 0,
                HomeTeamScore = 0,
                Started = _now
            };

            _gameStorage.CreateGame(game);

            _tested.UpdateScore(game.GameId, 2, 3);

            var changedGame = _gameStorage.GetGames().FirstOrDefault(_ => _.GameId == game.GameId);

            changedGame.HomeTeamScore.Should().Be(2);
            changedGame.AwayTeamScore.Should().Be(3);
        }

        [Fact]
        public void ThrowsExceptionOnUpdateScore_WhenGameNotExists()
        {
            Action changeGame = () => _tested.UpdateScore(1.ToGuid(), 2, 3);

            changeGame.Should().Throw<Exception>();
        }

        [Fact]
        public void DeleteGameOnFinishGame()
        {
            var team1 = new TeamVo
            {
                TeamId = 1,
                TeamName = "Spain"
            };

            var team2 = new TeamVo
            {
                TeamId = 2,
                TeamName = "Italy"
            };

            var game = new GameVo
            {
                GameId = 1.ToGuid(),
                HomeTeamId = team1.TeamId,
                AwayTeamId = team2.TeamId,
                AwayTeamScore = 0,
                HomeTeamScore = 0,
                Started = _now
            };

            _gameStorage.CreateGame(game);

            _tested.FinishGame(game.GameId);

            var finishedGame = _gameStorage.GetGames().FirstOrDefault(_ => _.GameId == game.GameId);

            finishedGame.Should().BeNull();
        }

        [Fact]
        public void ThrowsExceptionOnFinishGame_WhenGameNotExists()
        {
            var gameId = 1.ToGuid();

            Action finishGame = () => _tested.FinishGame(gameId);

            finishGame.Should().Throw<Exception>();
        }

        [Fact]
        public void ReturnsGamesSummary_WhenGamesExists()
        {
            var team1 = new TeamVo
            {
                TeamId = 1,
                TeamName = "Spain"
            };

            var team2 = new TeamVo
            {
                TeamId = 2,
                TeamName = "Italy"
            };

            var team3 = new TeamVo
            {
                TeamId = 3,
                TeamName = "France"
            };

            var game1 = new GameVo
            {
                GameId = 1.ToGuid(),
                HomeTeamId = team1.TeamId,
                AwayTeamId = team2.TeamId,
                AwayTeamScore = 0,
                HomeTeamScore = 0,
                Started = _now
            };

            var game2 = new GameVo
            {
                GameId = 2.ToGuid(),
                HomeTeamId = team2.TeamId,
                AwayTeamId = team3.TeamId,
                AwayTeamScore = 0,
                HomeTeamScore = 0,
                Started = _now
            };

            var game3 = new GameVo
            {
                GameId = 3.ToGuid(),
                HomeTeamId = team3.TeamId,
                AwayTeamId = team1.TeamId,
                AwayTeamScore = 0,
                HomeTeamScore = 0,
                Started = _now
            };

            _gameStorage.CreateGame(game1);
            _gameStorage.CreateGame(game2);
            _gameStorage.CreateGame(game3);

            var gamesSummary = _tested.GetSummaryByAddedDate().ToList();

            gamesSummary.Count.Should().Be(3);
        }
    }
}