using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flynet.Vloot
{
    class PassagiersVliegtuig : LuchtVaartuig
    {
        public static readonly decimal KostPerZetel = 10m;

        public int AantalPassagiers { get; set; } // het totaal aantal zetels 

        public override decimal BasisKostprijsPerDag { get; set; }        

        public override decimal BerekenTotaleKostprijsPerDag()
        {
            return BasisKostprijsPerDag + AantalPassagiers * KostPerZetel;
        }

        // overrides LuchtVaartuig.ToString
        public override string ToString()
        {
            return base.ToString() + " aantal zetels = " + AantalPassagiers;
        }
    }
}
