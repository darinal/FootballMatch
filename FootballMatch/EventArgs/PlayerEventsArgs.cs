using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballMatch
{
    public class PlayerEventsArgs
    {
        public string PlayerName { get; private set; }

        public PlayerEventsArgs(string playerName)
        {
            PlayerName = playerName;
        }
    }
}
