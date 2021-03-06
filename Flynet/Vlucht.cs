﻿using System;
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
            return string.Format("({0}) {1} duurtijd: {2}, totale kostprijs: {3}", VluchtID, Bestemming, Duurtijd, BerekenVluchtKost());
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
