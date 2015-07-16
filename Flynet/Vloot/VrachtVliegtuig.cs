using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flynet.Vloot
{
    class VrachtVliegtuig : LuchtVaartuig
    {
        public static readonly decimal KostPerTon = 100m;

        public int LaadVermogen { get; set; } // ton

        public override decimal BasisKostprijsPerDag { get; set; }

        public override decimal BerekenTotaleKostprijsPerDag()
        {
            return BasisKostprijsPerDag + LaadVermogen * KostPerTon;
        }

        // overrides LuchtVaartuig.ToString()
        public override string ToString()
        {
            return base.ToString() + " laadvermogen = " + LaadVermogen;
        }
    }
}
