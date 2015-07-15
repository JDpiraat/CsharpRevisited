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

        public int Laadvermogen { get; private set; } // ton

        public override decimal BasisKostprijsPerDag { get; set; }

        public VrachtVliegtuig(string type, int kruissnelheid, int vliegbereik, decimal basisKostprijsPerDag, int laadvermogen) : base(type, kruissnelheid, vliegbereik, basisKostprijsPerDag)
        {
            this.Laadvermogen = laadvermogen;
        }

        public override decimal BerekenTotaleKostprijsPerDag()
        {
            return BasisKostprijsPerDag + Laadvermogen * KostPerTon;
        }

        // overrides LuchtVaartuig.ToString()
        public override string ToString()
        {
            return base.ToString() + " laadvermogen = " + Laadvermogen;
        }
    }
}
