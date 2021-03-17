using System.Collections.Generic;
using System.Linq;

namespace FootballWorldCupScoreBoard.Storages
{
    public class TeamStorage : ITeamStorage
    {
        private List<TeamVo> teams = new List<TeamVo>();
        public TeamVo CreateTeam(TeamVo team)
        {
            var teamId = teams.Count;
            team.TeamId = teamId;
            this.teams.Add(team);
            return team;
        }

        public bool DeleteTeam(int teamId)
        {
            var team = this.teams.FirstOrDefault(_ => _.TeamId == teamId);
            if (team == null) return false;

            return this.teams.Remove(team);
        }

        public TeamVo UpdateTeam(TeamVo team)
        {
            var existedTeam = this.teams.FirstOrDefault(_ => _.TeamId == team.TeamId);
            if (existedTeam == null) return null;

            existedTeam.TeamName = team.TeamName;

            return existedTeam;
        }

        public TeamVo GetTeamById(int teamId)
        {
            return this.teams.FirstOrDefault(_ => _.TeamId == teamId);
        }

        public List<TeamVo> GetTeams()
        {
            return this.teams;
        }
    }
}