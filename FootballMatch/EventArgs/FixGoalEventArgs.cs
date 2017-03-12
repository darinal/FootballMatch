using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballMatch
{
    public class FixGoalEventArgs : EventArgs
    {
        public Team Team {get; private set;}
        public int Minute { get; private set; }

        public FixGoalEventArgs(Team team, int minute)
        {
            Team = team;
            Minute = minute;
        }
    }
}
