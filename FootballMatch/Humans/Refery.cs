using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballMatch
{
    public delegate void ChangeGameScore(object sender, FixGoalEventArgs args);
    public class Refery : Human
    {
        Team preferenceTeam;

        public event ChangeGameScore ChangeGameScore;

        public Refery(string name)
        {
            this.name = name;
            preferenceTeam = null;
        }

        public void MakePreferences(Team team)
        {
            this.preferenceTeam = team;
        }

        public void AddPoint(object sender, PlayerEventsArgs playerInfo)
        {
            Console.Write("Судья: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("{0} забивает гол! Команда {1} получает 1 очко!", playerInfo.PlayerName, sender);
            Console.ResetColor();
            if (ChangeGameScore != null)
            {
                ChangeGameScore(this, new FixGoalEventArgs((Team)sender, GameTimer.currentTime));
            }
        }

        public void MakeWarning(object sender, PlayerEventsArgs playerInfo)
        {
            if (preferenceTeam != (Team)sender)
            {
                Console.Write("Судья: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("{0} из команды {1}, не нарушайте правила!", playerInfo.PlayerName, sender);
                Console.ResetColor();
            }
        }
    }
}
