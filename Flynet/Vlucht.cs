using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flynet.Vloot;
using Flynet.Personeel;

namespace Flynet
{
    delegate decimal BerekenTotaleKostprijsPerDag(List<IKost> iKostLijst);

    class Vlucht
    {
        public int VluchtID { get; private set; }

        public string Bestemming { get; private set; }

        public int Duurtijd { get; private set; }

        public VliegMaatschappij VliegMaatschappij { get; private set; }

        private LuchtVaartuig toestel;

        public LuchtVaartuig Toestel
        {
            get
            {
                return toestel;
            }
            set
            {
                if (VliegMaatschappij.Vloot.Contains(value)) toestel = value;
                else throw new ToestelBehoortNietTotVlootException(" De vliegmaatschappij " + VliegMaatschappij.VliegMaatschappijNaam + "  heeft geen toestel(len) van dit type (" + value + "). ");
            }
        }

        /* algemene opmerking maar hier specifiek 'uitgewerkt':
         * OOP 'zegt' programmeren naar interfaces ... 
         * mss hier toch gewoon List? Het zou minder cast-ings geven in de PrintVlucht methode in ProgramAangepastAanTekstFileInhoud:
         * (List<VliegendPersoneelslid>)vlucht.Personeel omdat Ilist die ForEach niet kent ...
         */
        public IList<VliegendPersoneelslid> Personeel { get; private set; }

        public Vlucht(int vluchtID, string bestemming, int duurtijd, VliegMaatschappij vliegMaatschappij, LuchtVaartuig toestel, IList<VliegendPersoneelslid> personeel)
        {
            this.VluchtID = vluchtID;
            this.Bestemming = bestemming;
            this.Duurtijd = duurtijd;
            this.VliegMaatschappij = vliegMaatschappij;
            this.Toestel = toestel;
            this.Personeel = personeel;
        }

        public decimal BerekenVluchtKost()
        {
            decimal KostprijsPerDag = Personeel.Sum(vliegendPersoneelslid => ((IKost)vliegendPersoneelslid).BerekenTotaleKostprijsPerDag());
            KostprijsPerDag += toestel.BerekenTotaleKostprijsPerDag();
            return KostprijsPerDag * Duurtijd;
        }

        // overrides Object.ToString
        public override string ToString()
        {
            return string.Format("{0}: {1} ({2}) - {3} ({4}) - vluchtprijs: {5}", VluchtID, Bestemming, VliegMaatschappij.VliegMaatschappijNaam, Toestel.Type, Toestel.BerekenTotaleKostprijsPerDag() * Duurtijd, BerekenVluchtKost());
        }
    }

    public class ToestelBehoortNietTotVlootException : System.Exception
    {
        public ToestelBehoortNietTotVlootException(String message)
            : base(message)
        {
        }
    }
}
