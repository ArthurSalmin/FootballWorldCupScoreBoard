using System;

namespace FootballWorldCupScoreBoard.ValueObjects
{
    public class GameVo
    {
        public Guid GameId { get; set; }
        public int HomeTeamId { get; set; }
        public int AwayTeamId { get; set; }
        public int HomeTeamScore { get; set; }
        public int AwayTeamScore { get; set; }
        public DateTime Started { get; set; }
    }
}