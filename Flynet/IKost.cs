using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flynet
{
    interface IKost
    {
        decimal BasisKostprijsPerDag
        {
            // get is mss overbodig ... aan de andere kant, het kan geen kwaad.
            get;
            set;
        }

        decimal BerekenTotaleKostprijsPerDag();
    }
}
