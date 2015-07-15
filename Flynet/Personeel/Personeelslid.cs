using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flynet.Personeel
{
    abstract class Personeelslid
    {
        public string PersoneelsID { get; private set; }

        public string Naam { get; private set; }

        // in de veronderstelling dat er ontheemden zijn (null) en dat mensen mogen verhuizen (public set)
        private Adres adres;

        public Adres Adres
        {
            get { return adres; }
            set { adres = value; }
        }

        protected Personeelslid(string personeelsID, string naam)
        {
            this.PersoneelsID = personeelsID;
            this.Naam = naam;            
        }

        // override object.Equals
        // toch wel quick en zeker dirty
        public override bool Equals(object obj)
        {
            if (obj is Personeelslid)
            {
                return this.PersoneelsID.Equals(((Personeelslid)obj).PersoneelsID);
            }
            return false;
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {            
            return this.PersoneelsID.GetHashCode();
        }

        // overrides Object.ToString
        public override string ToString()
        {
            return "ID = " + PersoneelsID + ", naam: " + Naam;
        }
    }
}
