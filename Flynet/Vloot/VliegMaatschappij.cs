using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flynet.Vloot
{
    class VliegMaatschappij
    {
        public int VliegMaatschappijID { get; private set; }

        public string VliegMaatschappijNaam { get; private set; }

        public IList<LuchtVaartuig> Vloot { get; private set; }

        public VliegMaatschappij(int vliegMaatschappjiID, string vliegMaatschappijNaam, IList<LuchtVaartuig> vloot)
        {
            this.VliegMaatschappijID = vliegMaatschappjiID;
            this.VliegMaatschappijNaam = vliegMaatschappijNaam;
            this.Vloot = vloot;
        }

        public void AddLuchtVaartuig(LuchtVaartuig luchtVaartuig)
        {
            if (!Vloot.Contains(luchtVaartuig)) Vloot.Add(luchtVaartuig);
        }

        public void RemoveLuchtVaartuig(LuchtVaartuig luchtVaartuig)
        {
            Vloot.Remove(luchtVaartuig);
        }

        // override object.Equals
        // wederom toch wel quick en zeker dirty
        public override bool Equals(object obj)
        {
            if (obj is VliegMaatschappij)
            {
                return this.VliegMaatschappijID == ((VliegMaatschappij)obj).VliegMaatschappijID;
            }
            return false;
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {            
            return this.VliegMaatschappijID.GetHashCode();
        }

        // overrides Object.ToString
        public override string ToString()
        {
            return VliegMaatschappijNaam + " (" + VliegMaatschappijID + ")";
        }
    }
}
