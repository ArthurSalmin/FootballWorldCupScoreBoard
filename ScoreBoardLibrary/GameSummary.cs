namespace FootballWorldCupScoreBoard
{
    public class GameSummary
    {
        public string HomeTeamName { get; set; }
        public string AwayTeamName { get; set; }
        public int HomeTeamScore { get; set; }
        public int AwayTeamScore { get; set; }

        public override string ToString()
        {
            return $"{HomeTeamName} {HomeTeamScore} - {AwayTeamName} {AwayTeamScore}";
        }
    }
}