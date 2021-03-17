using System.Collections.Generic;
using System.Linq;
using FootballWorldCupScoreBoard.Interfaces;
using FootballWorldCupScoreBoard.ValueObjects;

namespace FootballWorldCupScoreBoard.Storages
{
    public class TeamStorage : ITeamStorage
    {
        private readonly List<TeamVo> _teams = new List<TeamVo>();
        private int _scopeIdentity;

        public TeamStorage()
        {
            _scopeIdentity = 0;
        }
        public TeamVo CreateTeam(TeamVo team)
        {
            var teamId = this._scopeIdentity++;
            team.TeamId = teamId;
            _teams.Add(team);
            return team;
        }

        public bool DeleteTeam(int teamId)
        {
            var team = _teams.FirstOrDefault(_ => _.TeamId == teamId);
            if (team == null)
            {
                return false;
            }

            return _teams.Remove(team);
        }

        public TeamVo UpdateTeam(TeamVo team)
        {
            var existedTeam = _teams.FirstOrDefault(_ => _.TeamId == team.TeamId);
            if (existedTeam == null)
            {
                return null;
            }

            existedTeam.TeamName = team.TeamName;

            return existedTeam;
        }

        public TeamVo GetTeamById(int teamId)
        {
            return _teams.FirstOrDefault(_ => _.TeamId == teamId);
        }

        public List<TeamVo> GetTeams()
        {
            return _teams;
        }
    }
}