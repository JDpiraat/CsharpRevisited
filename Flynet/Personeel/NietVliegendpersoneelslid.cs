using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flynet.Personeel
{
    class NietVliegendpersoneelslid : Personeelslid, IKost
    {
        private int urenPerWeek;

        public int UrenPerWeek
        {
            get { return urenPerWeek; }
            set { urenPerWeek = value; }
        }

        private Afdeling afdeling;

        public Afdeling Afdeling
        {
            get { return afdeling; }
            set { afdeling = value; }
        }

        public NietVliegendpersoneelslid(string personeelsID, string naam) : base(personeelsID, naam) 
        {

        }

        public decimal BasisKostprijsPerDag { get; set;}

        public decimal BerekenTotaleKostprijsPerDag()
        {
            return BasisKostprijsPerDag;
        }

        // overrides PersoneelsLid.ToString
        public override string ToString()
        {
            return base.ToString() + ", afdeling = " + afdeling + ", uren: " + urenPerWeek;
        }
    }

    public enum Afdeling
    {
        Personeelsadministratie,
        Boekhouding,
        Incheckbalie,
        Logistiek
    }
}
