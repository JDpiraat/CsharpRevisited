using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flynet.Personeel
{
    class Adres
    {
        public string StraatNr { get; private set; }

        public string Postcode { get; private set; }

        public string Gemeente { get; private set; }

        public Adres(string straatNr, string postcode, string gemeente)
        {
            // TODO: Complete member initialization
            this.StraatNr = straatNr;
            this.Postcode = postcode;
            this.Gemeente = gemeente;
        }

        // override object.Equals
        public override bool Equals(object obj)
        {
            if (obj is Adres)
            {
                Adres other = (Adres)obj;
                return this.StraatNr == other.StraatNr && this.Gemeente == other.Gemeente && this.Postcode == other.Postcode;
            } 
            return false;
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {          
            // wie hier een Tuple.create(..., ...).getHashCode() gebruik is wel goed (maar extreem) bezig en zo zijn er wel nog meerdere technieken 
            // (leve Java en IDE's met auto-generated stuff op het gebied van equals en hashCode)
            // ik smijt er even wat priemgetallen tegen ... KISS?
            return this.StraatNr.GetHashCode()*3 + this.Gemeente.GetHashCode()*7 + this.Postcode.GetHashCode()*11;
        }
    }
}
