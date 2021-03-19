using System.Collections.Generic;
using FootballWorldCupScoreBoard.ValueObjects;

namespace FootballWorldCupScoreBoard.Interfaces
{
    public interface ITeamStorage
    {
        TeamVo CreateTeam(TeamVo team);
        bool DeleteTeam(int teamId);
        TeamVo UpdateTeam(TeamVo team);

        TeamVo GetTeamById(int teamId);

        List<TeamVo> GetTeams();

        TeamVo GetTeamByName(string teamName);
    }
}