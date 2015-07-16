using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flynet.Personeel
{
    class Certificaat
    {
        public string CertificaatAfkorting { get; set; }

        public string CertificaatOmschrijving { get; set; }        

        // override object.Equals
        public override bool Equals(object obj)
        {   
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }            
            return (this.CertificaatAfkorting.Equals(((Certificaat)obj).CertificaatAfkorting));
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {            
            return CertificaatAfkorting.GetHashCode();
        }

        // overrides Object.ToString()
        public override string ToString()
        {
            return CertificaatAfkorting + " (" + CertificaatOmschrijving + ")";
        }
    }
}
