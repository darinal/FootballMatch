using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballMatch
{
    public abstract class Human
    {
        internal string name;

        public override string ToString()
        {
            return this.name;
        }
    }
}
