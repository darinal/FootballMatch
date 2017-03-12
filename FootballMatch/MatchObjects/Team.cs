using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballMatch
{
    public delegate void MakeGoal(object sender, PlayerEventsArgs args);
    public delegate void MakeFoul(object sender, PlayerEventsArgs args);

    public class Team
    {
        string name;
        Player[] players;
        Trainer trainer;

        //первая или вторая
        public int Number { get; private set; }

        public event MakeGoal MakeGoal;
        public event MakeFoul MakeFoul;
        
        public Team(string name, Trainer trainer, int number)
        {
            this.name = name;
            this.trainer = trainer;
            Number = number;
            players = new Player[11];
            AddPlayers();
        }

        private void AddPlayers()
        {
            Random rand = new Random(DateTime.Now.Millisecond);

            for (int i = 0; i < players.Length; i++)
            {
                Player player = new Player(String.Format("Игрок " + (rand.Next() % 30 + 1)), 20 + rand.Next() % 10);
                players[i] = player;
            }
        }

        public void MakeNewGoal(object sender, SimulationEventArgs teamInfo)
        {
            if (MakeGoal != null && teamInfo.TeamNumber == Number)
            {
                Random rand = new Random(DateTime.Now.Millisecond);
                MakeGoal(this, new PlayerEventsArgs(players[rand.Next() % 11].ToString()));
            }
        }

        public void MakeNewFoul(object sender, SimulationEventArgs teamInfo)
        {
            if (MakeFoul != null && teamInfo.TeamNumber == Number)
            {
                Random rand = new Random(DateTime.Now.Millisecond);
                MakeFoul(this, new PlayerEventsArgs(players[rand.Next() % 11].ToString()));   
            }
        }
        public Player this[int index]
        {
            get
            {
                if (index >= players.Length)
                {
                    return null;
                }
                else
                    return players[index];
            }
        }

        public override string ToString()
        {
            return this.name;
        }
    }
}
