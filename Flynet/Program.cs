using Flynet.Personeel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flynet
{
    class Program
    {
        static void Main(string[] args)
        {
            TestNaVierUur();
            
            // mooi afsluiten programma
            Console.WriteLine();
            Console.WriteLine("Druk <enter> om af te sluiten");
            Console.ReadLine();

        }

        private static void TestNaVierUur()
        {
            Personeelslid personeelNV = new NietVliegendpersoneelslid("id", "Johan") { Adres = new Adres("5", "5000A", "Ergens"), Afdeling = Afdeling.Logistiek, UrenPerWeek = 37, BasisKostprijsPerDag = 350m };
            Console.WriteLine(personeelNV);

            Personeelslid personeelCockpit = new CockpitCrew("id", "Johan", Graad.Captain,
                new List<Certificaat> { new Certificaat("PPL", "Private Pilot Licence"), new Certificaat("CPL", "Commercial Pilot Licence") }, 20470) { Adres = new Adres("6", "6000B", "Nergens"), BasisKostprijsPerDag = 500m };
            Console.WriteLine(personeelCockpit);
            Console.WriteLine(((IKost)personeelCockpit).BerekenTotaleKostprijsPerDag());
        }
    }
}
