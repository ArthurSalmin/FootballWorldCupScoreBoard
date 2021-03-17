using System.Collections.Generic;
using FluentAssertions;
using FootballWorldCupScoreBoard.Facts.TestUtilities;
using FootballWorldCupScoreBoard.Storages;
using FootballWorldCupScoreBoard.ValueObjects;
using Xunit;

namespace FootballWorldCupScoreBoard.Facts.Tests
{
    public class TeamStorageFacts
    {
        private readonly TeamStorage _tested;

        public TeamStorageFacts()
        {
            this._tested = new TeamStorage();
        }
        
        [Fact]
        public void ReturnsTeamOnCreateTeam()
        {
            var newTeam = new TeamVo()
            {
                TeamName = "Italy"
            };

            var result = this._tested.CreateTeam(newTeam);

            result.Should().NotBeNull();
        }

        [Fact]
        public void ReturnsTrueOnDeleteTeam()
        {
            var newTeam = new TeamVo()
            {
                TeamName = "Italy"
            };

            var createdTeam = this._tested.CreateTeam(newTeam);

            var result = this._tested.DeleteTeam(createdTeam.TeamId);
            
            result.Should().BeTrue();
        }
        
        [Fact]
        public void ReturnsFalseOnDeleteTeam_WhenTeamNotExists()
        {
            var result = this._tested.DeleteTeam(1);

            result.Should().BeFalse();
        }

        [Fact]
        public void ReturnsChangedOnUpdateTeam()
        {
            var newTeam = new TeamVo()
            {
                TeamName = "Italy"
            };

            var team = this._tested.CreateTeam(newTeam);
            team.TeamName = "Italy2";
            
            var result = this._tested.UpdateTeam(team);

            result.TeamName.Should().Be("Italy2");
        }
        
        [Fact]
        public void ReturnsNullOnUpdateTeam_WhenTeamNotExists()
        {
            var team = new TeamVo()
            {
                TeamId = 1,
                TeamName = "Italy"
            };

            var result = this._tested.UpdateTeam(team);

            result.Should().Be(null);
        }

        [Fact]
        public void ReturnsTeamOnGetTeamById()
        {
            var newTeam = new TeamVo()
            {
                TeamName = "Italy"
            };

            var team = this._tested.CreateTeam(newTeam);

            var resultTeam = this._tested.GetTeamById(team.TeamId);

            resultTeam.Should().Be(team);
        }
        
        [Fact]
        public void ReturnsTeamsOnGetTeams()
        {
            var newTeam1 = new TeamVo()
            {
                TeamName = "Italy"
            };

            var newTeam2 = new TeamVo()
            {
                TeamName = "France"
            };

            var team1 = this._tested.CreateTeam(newTeam1);
            var team2 = this._tested.CreateTeam(newTeam2);

            var expectedTeams = new List<TeamVo> {team1, team2};

            var resultTeams = this._tested.GetTeams();

            resultTeams.Should().BeEquivalentTo(expectedTeams);
        }
    }
}