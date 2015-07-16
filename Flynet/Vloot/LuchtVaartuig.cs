using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flynet.Vloot
{
    abstract class LuchtVaartuig : IKost
    {
        public abstract decimal BasisKostprijsPerDag
        {
            get;
            set;
        }

        public string Type { get; set; }

        public int Kruissnelheid { get; set; } // km/u

        public int Vliegbereik { get; set; } // km        

        // overrides object.Equals
        // toch wel quick en zeker dirty
        public override bool Equals(object obj)
        {
            if (obj is LuchtVaartuig)
            {
                return this.Type.Equals(((LuchtVaartuig)obj).Type);
            }
            return false;
        }

        // overrides object.GetHashCode
        public override int GetHashCode()
        {           
            return this.Type.GetHashCode();
        }

        // overrides Object.ToString
        public override string ToString()
        {
            return Type + " (" + Kruissnelheid + "km/u, " + Vliegbereik + "km)";
        }

        public abstract decimal BerekenTotaleKostprijsPerDag();
        
    }
}
