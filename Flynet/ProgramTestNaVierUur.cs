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
        private static void TestNaVierUur()
        {
            Console.WriteLine("* NietVliegendpersoneelslid:");
            Personeelslid personeelNietVliegend = new NietVliegendpersoneelslid("id", "Johan")
            {
                Adres = new Adres("5", "5000A", "Ergens"),
                Afdeling = Afdeling.Logistiek,
                UrenPerWeek = 37,
                BasisKostprijsPerDag = 350m
            };
            Console.WriteLine(personeelNietVliegend);
            Console.WriteLine(((IKost)personeelNietVliegend).BerekenTotaleKostprijsPerDag());

            Console.WriteLine("* CockpitCrew:");
            Personeelslid personeelCockpit = new CockpitCrew("id", "Johan", Graad.Captain,
                new List<Certificaat> { new Certificaat("PPL", "Private Pilot Licence"), new Certificaat("CPL", "Commercial Pilot Licence") }, 20470)
            {
                Adres = new Adres("6", "6000B", "Nergens"),
                BasisKostprijsPerDag = 500m
            };
            Console.WriteLine(personeelCockpit);
            Console.WriteLine(((IKost)personeelCockpit).BerekenTotaleKostprijsPerDag());

            Console.WriteLine("* CabineCrew:");
            Personeelslid personeelCabine = new CabineCrew("id", "Johan", Graad.Purser,
                new List<Certificaat> { new Certificaat("PPL", "Private Pilot Licence"), new Certificaat("CPL", "Commercial Pilot Licence") }, "deur 1")
            {
                Adres = new Adres("7", "7000C", "Overal"),
                BasisKostprijsPerDag = 200m
            };
            Console.WriteLine(personeelCabine);
            Console.WriteLine(((IKost)personeelCabine).BerekenTotaleKostprijsPerDag());

            Console.WriteLine("* PassagierVliegtuig:");
            LuchtVaartuig passagiersVliegtuig = new PassagiersVliegtuig("Boeing A730", 500, 25000, 2000m, 270);
            Console.WriteLine(passagiersVliegtuig);
            Console.WriteLine(passagiersVliegtuig.BerekenTotaleKostprijsPerDag());

            Console.WriteLine("* VrachtVliegtuig:");
            LuchtVaartuig vrachtVliegtuig = new VrachtVliegtuig("Loadking", 400, 2000, 1500m, 800);
            Console.WriteLine(vrachtVliegtuig);
            Console.WriteLine(vrachtVliegtuig.BerekenTotaleKostprijsPerDag());

            Console.WriteLine("* VliegMaatschappij:");            
            VliegMaatschappij vliegMaatschappij = new VliegMaatschappij(1, Maatschappij.BrusselsAirlines, new List<LuchtVaartuig> { passagiersVliegtuig, vrachtVliegtuig });
            Console.WriteLine(vliegMaatschappij);

            Console.WriteLine("* Vlucht OK:");
            Vlucht vluchtOK = null;            
            try
            {
                vluchtOK = new Vlucht(1, "Hier", 5, vliegMaatschappij, passagiersVliegtuig,
                        new List<VliegendPersoneelslid> { (VliegendPersoneelslid)personeelCabine, (VliegendPersoneelslid)personeelCockpit });
            }
            catch (ToestelBehoortNietTotVlootException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine(vluchtOK);

            Console.WriteLine("* Vlucht niet OK:");
            vliegMaatschappij.RemoveLuchtVaartuig(passagiersVliegtuig);
            Vlucht vluchtNietOK = null;
            try
            {
                vluchtNietOK = new Vlucht(1, "Hier", 5, vliegMaatschappij, passagiersVliegtuig,
                        new List<VliegendPersoneelslid> { (VliegendPersoneelslid)personeelCabine, (VliegendPersoneelslid)personeelCockpit });
            }
            catch (ToestelBehoortNietTotVlootException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine(vluchtNietOK);
        }
    }
}
