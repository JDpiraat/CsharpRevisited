using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flynet.Personeel
{
    abstract class VliegendPersoneelslid : Personeelslid
    {
        public abstract Graad Graad { get; set; }

        public IList<Certificaat> Certificaten { get; private set; }

        protected VliegendPersoneelslid(string personeelsID, string naam, Graad graad, IList<Certificaat> certificaten)
            : base(personeelsID, naam)
        {
            this.Graad = graad;
            this.Certificaten = certificaten;
        }

        // overrides PersoneelsLid.ToString()
        public override string ToString()
        {
            StringBuilder VliegendpersoneelslidToString = new StringBuilder();
            VliegendpersoneelslidToString.Append(base.ToString());
            VliegendpersoneelslidToString.Append(", graad = ");
            VliegendpersoneelslidToString.Append(Graad);
            VliegendpersoneelslidToString.Append((Certificaten.Count() > 1)?  ", certificaten: " : ", certificaat: ");            
            foreach (Certificaat certificaat in Certificaten)
            {
                VliegendpersoneelslidToString.Append(certificaat + ", ");
            }
            VliegendpersoneelslidToString.Remove(VliegendpersoneelslidToString.Length - 2, 2);
            return VliegendpersoneelslidToString.ToString();
        }
    }

    public enum Graad
    {
        Captain,
        SeniorFlightOfficer,
        SecondOfficer,
        JuniorFlightOfficer,
        Steward,
        Purser
    }

}
