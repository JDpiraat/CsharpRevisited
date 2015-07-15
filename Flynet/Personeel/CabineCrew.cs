using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flynet.Personeel
{
    class CabineCrew : VliegendPersoneelslid, IKost
    {
        public static readonly ISet<Graad> ToegelatenGraden = new HashSet<Graad> { Graad.Purser, Graad.Steward };

        public static readonly decimal PurserPercentage = 1.2m; // 20% toeslag

        public static readonly Certificaat EhboCertificaat = new Certificaat("EHBO", "First Aid");
        public static readonly decimal EhboCertificaatToeslag = 5m;

        private Graad graad;

        public override Graad Graad
        {
            get
            {
                return graad;
            }

            set
            {
                if (ToegelatenGraden.Contains(value)) graad = value;
                else throw new ArgumentException(" Graad niet toegelaten. ");
            }
        }

        public string Werkpositie { get; private set; }

        public CabineCrew(string personeelsID, string naam, Graad graad, IList<Certificaat> certificaten, string werkpositie)
            : base(personeelsID, naam, graad, certificaten) 
        {
            this.Werkpositie = werkpositie;
        }

        public decimal BasisKostprijsPerDag { get; set; }

        public decimal BerekenTotaleKostprijsPerDag()
        {
            decimal TotaleKostprijs = BasisKostprijsPerDag;
            if (graad == Graad.Purser) TotaleKostprijs *= PurserPercentage;
            if (Certificaten.Contains(EhboCertificaat)) TotaleKostprijs += EhboCertificaatToeslag;
            return TotaleKostprijs;
        }

        // overrides VliegendPersoneelslid.ToString()
        public override string ToString()
        {
            return base.ToString() + ", werkpositie = " + Werkpositie;
        }
    }
}
