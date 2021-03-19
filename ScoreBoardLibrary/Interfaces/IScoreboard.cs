using System;
using System.Collections.Generic;
using FootballWorldCupScoreBoard.ValueObjects;

namespace FootballWorldCupScoreBoard.Interfaces
{
    public interface IScoreboard
    {
        GameVo StartGame(TeamVo homeTeam, TeamVo awayTeam);
        IEnumerable<string> GetSummaryByAddedDate();
        void UpdateScore(Guid gameId, int homeTeamScore, int awayTeamScore);
        void FinishGame(Guid gameId);

        int GetTeamScore(string name);
    }
}