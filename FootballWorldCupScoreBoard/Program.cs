using System;
using System.Collections.Generic;
using FootballWorldCupScoreBoard.Storages;

namespace FootballWorldCupScoreBoard
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var teamItaly = new TeamVo()
            {
                TeamName = "Italy"
            };
            var teamFrance = new TeamVo()
            {
                TeamName = "France"
            };
            var teamSpain = new TeamVo()
            {
                TeamName = "Spain"
            };
            var teamBrazil = new TeamVo()
            {
                TeamName = "Brazil"
            };
            
            var teamsToCreate = new List<TeamVo> {teamItaly, teamFrance, teamSpain, teamBrazil};

            var teamStorage = new TeamStorage();
            var gameStorage = new GameStorage();

            var newScoreBoard = new ScoreBoard(teamStorage, gameStorage);
            
            foreach (var team in teamsToCreate)
            {
                teamStorage.CreateTeam(team);
            }

            var teams = teamStorage.GetTeams();
            
            var game1 = newScoreBoard.StartGame(teams[0], teams[1]);
            var game2 = newScoreBoard.StartGame(teams[1], teams[2]);
            var game3 = newScoreBoard.StartGame(teams[2], teams[3]);

            newScoreBoard.UpdateScore(game1.GameId, 1, 1);
            newScoreBoard.UpdateScore(game2.GameId, 2, 0);
            newScoreBoard.UpdateScore(game3.GameId, 3, 4);

            var summaryResult = newScoreBoard.GetSummaryByAddedDate();

            Console.WriteLine("Summary results");
            foreach (var summary in summaryResult)
            {
                Console.WriteLine(summary);
            }

            newScoreBoard.FinishGame(game1.GameId);
            newScoreBoard.FinishGame(game3.GameId);
            
            summaryResult = newScoreBoard.GetSummaryByAddedDate();
            Console.WriteLine("Summary results 2");
            foreach (var summary in summaryResult)
            {
                Console.WriteLine(summary);
            }
            
            Console.ReadLine();
        }
    }
}