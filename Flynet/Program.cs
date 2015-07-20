using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flynet.Personeel;
using Flynet.Vloot;

namespace Flynet
{
    partial class Program
    {
        static void Main(string[] args)
        {
            // werkt niet in de "forget-readonly-properties" branche (teveel readonly properties als je de objecten in de tekstfile van deel 2 bekijkt ... tja): 
            // TestNaVierUur();

            // oplossing opgave deel 2 dus ...
            IList<Vlucht> Vluchten = AanmakenVluchtObjecten();
            PrintOverzicht(Vluchten);

            // mooi afsluiten programma
            Console.WriteLine();
            Console.WriteLine("Druk <enter> om af te sluiten");
            Console.ReadLine();

        }                
    }
}
