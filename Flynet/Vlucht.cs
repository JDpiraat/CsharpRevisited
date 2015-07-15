using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flynet.Vloot;

namespace Flynet
{
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

        public Vlucht(int vluchtID, string bestemming, int duurtijd, VliegMaatschappij vliegMaatschappij, LuchtVaartuig toestel)
        {
            this.VluchtID = vluchtID;
            this.Bestemming = bestemming;
            this.Duurtijd = duurtijd;
            this.VliegMaatschappij =  vliegMaatschappij;
            this.Toestel= toestel;
        }
    }   

    public class ToestelBehoortNietTotVlootException : System.Exception
    {
        public ToestelBehoortNietTotVlootException(String message) : base(message)
        {
        }
    }
}
