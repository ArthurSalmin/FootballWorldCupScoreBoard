using System;
using System.Collections.Generic;

namespace FootballWorldCupScoreBoard
{
    public interface IScoreboard
    {
        GameVo StartGame(TeamVo homeTeam, TeamVo awayTeam);
        List<string> GetSummaryByAddedDate();
        void UpdateScore(Guid gameId, int homeTeamScore, int awayTeamScore);
        void FinishGame(Guid gameId);
    }
}