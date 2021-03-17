using System.Collections.Generic;

namespace FootballWorldCupScoreBoard
{
    public interface ITeamStorage
    {
        TeamVo CreateTeam(TeamVo team);
        bool DeleteTeam(int teamId);
        TeamVo UpdateTeam(TeamVo team);

        TeamVo GetTeamById(int teamId);

        List<TeamVo> GetTeams();
    }
}