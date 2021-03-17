using System;
using System.Collections.Generic;
using FluentAssertions;
using FootballWorldCupScoreBoard.Facts.TestUtilities;
using FootballWorldCupScoreBoard.Storages;
using FootballWorldCupScoreBoard.ValueObjects;

using Xunit;

namespace FootballWorldCupScoreBoard.Facts.Tests
{
    public class GameStorageFacts
    {
        private readonly GameStorage _tested;
        
        private readonly DateTime _now = new DateTime(2021, 03, 16);
        
        public GameStorageFacts()
        {
            this._tested = new GameStorage();
        }
        
        [Fact]
        public void ReturnsGameOnCreateGame()
        {
            var newGame = new GameVo()
            {
                HomeTeamId = 1,
                HomeTeamScore = 1,
                AwayTeamId = 2,
                AwayTeamScore = 2,
                Started = this._now
            };

            var result = this._tested.CreateGame(newGame);

            result.Should().NotBeNull();
        }

        [Fact]
        public void ReturnsTrueOnDeleteGame()
        {
            var newGame = new GameVo()
            {
                HomeTeamId = 1,
                HomeTeamScore = 1,
                AwayTeamId = 2,
                AwayTeamScore = 2,
                Started = this._now
            };

            var game = this._tested.CreateGame(newGame);

            var result = this._tested.DeleteGame(game.GameId);

            result.Should().BeTrue();
        }
        
        [Fact]
        public void ReturnsFalseOnDeleteGame_WhenGameNotExists()
        {
            var result = this._tested.DeleteGame(1.ToGuid());

            result.Should().BeFalse();
        }

        [Fact]
        public void ReturnsChangedOnUpdateGame()
        {
            var newGame = new GameVo()
            {
                HomeTeamId = 1,
                HomeTeamScore = 1,
                AwayTeamId = 2,
                AwayTeamScore = 2,
                Started = this._now
            };

            var game = this._tested.CreateGame(newGame);

            game.AwayTeamScore = 2;

            var result = this._tested.UpdateGame(game);

            result.AwayTeamScore.Should().Be(2);
        }
        
        [Fact]
        public void ReturnsNullOnUpdateGame_WhenGameNotExists()
        {
            var game = new GameVo()
            {
                GameId = 2.ToGuid(),
                HomeTeamId = 1,
                HomeTeamScore = 1,
                AwayTeamId = 2,
                AwayTeamScore = 2,
                Started = this._now
            };

            var result = this._tested.UpdateGame(game);

            result.Should().Be(null);
        }

        [Fact]
        public void ReturnsGameOnGetGameById()
        {
            var newGame = new GameVo()
            {
                HomeTeamId = 1,
                HomeTeamScore = 1,
                AwayTeamId = 2,
                AwayTeamScore = 2,
                Started = this._now
            };

            var game = this._tested.CreateGame(newGame);

            var resultGame = this._tested.GetGameById(game.GameId);

            resultGame.Should().Be(game);
        }
        
        [Fact]
        public void ReturnsGamesOnGetGames()
        {
            var newGame1 = new GameVo()
            {
                HomeTeamId = 1,
                HomeTeamScore = 1,
                AwayTeamId = 2,
                AwayTeamScore = 2,
                Started = this._now
            };
            
            var newGame2 = new GameVo()
            {
                HomeTeamId = 1,
                HomeTeamScore = 1,
                AwayTeamId = 2,
                AwayTeamScore = 2,
                Started = this._now
            };

            var game1 = this._tested.CreateGame(newGame1);
            var game2 = this._tested.CreateGame(newGame2);
            var expectedGames = new List<GameVo> {game1, game2};

            var resultGames = this._tested.GetGames();

            resultGames.Should().BeEquivalentTo(expectedGames);
        }
    }
}