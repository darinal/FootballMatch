using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballMatch
{
    public class Game
    {
        Team team1;
        Team team2;

        Refery refery;

        int scoreTeam1;
        int scoreTeam2;
        
        public Game(Team team1, Team team2, Refery refery)
        {
            this.team1 = team1;
            this.team2 = team2;
            this.refery = refery;
            scoreTeam1 = 0;
            scoreTeam2 = 0;
        }

        public void AddPoint(object sender, FixGoalEventArgs goalInfo)
        {
            if (goalInfo.Team == team1)
            {
                scoreTeam1++;
            }
            if (goalInfo.Team == team2)
            {
                scoreTeam2++;
            }
        }
        
        public void GetScoreResult(object sender, EventArgs args)
        {
            string result = String.Format("{0} : {1}", scoreTeam1, scoreTeam2);
            Console.WriteLine("Матч окончен. Финальный счёт: {0}", result);
        }
    }
}
