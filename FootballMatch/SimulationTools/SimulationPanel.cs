using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballMatch
{
    public delegate void SimulateGoal(object sender, SimulationEventArgs args);
    public delegate void SimulateFoul(object sender, SimulationEventArgs args);


    public static class SimulationPanel
    {
        public static SimulateGoal SimulateGoal;
        public static SimulateFoul SimulateFoul;

        public static void KeeboardMonitoring()
        {
            char userChoise = Console.ReadKey().KeyChar;
            Console.WriteLine();
            switch (userChoise)
            {
                case '1': 
                    if (SimulateGoal != null)
                    {
                        SimulateGoal(null, new SimulationEventArgs(1)); // что нужно вместо this поставить?
                    }
                    break;
                case 'q':
                case 'Q':
                    if (SimulateGoal != null)
                    {
                        SimulateGoal(null, new SimulationEventArgs(2)); // что нужно вместо this поставить?
                    }
                    break;
                case '2':
                    if (SimulateFoul != null)
                    {
                        SimulateFoul(null, new SimulationEventArgs(1));
                    }
                    break;
                case 'w':
                case 'W':
                    if (SimulateFoul != null)
                    {
                        SimulateFoul(null, new SimulationEventArgs(2));
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
