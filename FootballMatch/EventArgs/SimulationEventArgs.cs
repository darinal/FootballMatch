using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballMatch
{
    public class SimulationEventArgs : EventArgs
    {
        public int TeamNumber;
        public SimulationEventArgs(int teamNumber)
        {
            TeamNumber = teamNumber;
        }
    }
}
