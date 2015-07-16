using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flynet.Personeel
{
    class CockpitCrew : VliegendPersoneelslid, IKost
    {
        public static readonly ISet<Graad> ToegelatenGraden = new HashSet<Graad> { Graad.Captain, Graad.JuniorFlightOfficer, Graad.SecondOfficer, Graad.SeniorFlightOfficer };

        public static readonly decimal CaptainPercentage = 1.3m; // 30% toeslag
        public static readonly decimal SeniorFlightOfficerPercentage = 1.2m; // 20% toeslag
        public static readonly decimal SecondOfficerPercentage = 1.1m; // 10% toeslag

        public static readonly decimal extraToeslagCplCertificaat = 50m;
        public static readonly Certificaat CplCertificaat = new Certificaat
        {
            CertificaatAfkorting = "CPL",
            CertificaatOmschrijving = "Commercial Pilot License"
        };

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

        public int VliegUren { get; private set; }

        public CockpitCrew(string personeelsID, string naam, Graad graad, IList<Certificaat> certificaten, int vlieguren)
            : base(personeelsID, naam, graad, certificaten)
        {
            this.VliegUren = vlieguren;
        }

        public decimal BasisKostprijsPerDag { get; set; }

        public decimal BerekenTotaleKostprijsPerDag()
        {
            decimal TotaleKostprijs = BasisKostprijsPerDag;
            switch (graad)
            {
                case Graad.Captain:
                    TotaleKostprijs *= CaptainPercentage;
                    break;
                case Graad.SeniorFlightOfficer:
                    TotaleKostprijs *= SeniorFlightOfficerPercentage;
                    break;
                case Graad.SecondOfficer:
                    TotaleKostprijs *= SecondOfficerPercentage;
                    break;
            }
            if (Certificaten.Contains(CplCertificaat))
                TotaleKostprijs += extraToeslagCplCertificaat;
            return TotaleKostprijs;
        }

        // overrides VliegendPersoneelslid.ToString()
        public override string ToString()
        {
            return base.ToString() + ", vlieguren = " + VliegUren;
        }
    }
}
