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
            Personeelslid PersoneelNietVliegend = new NietVliegendpersoneelslid("id", "Johan")
            {
                Adres = new Adres("5", "5000A", "Ergens"),
                Afdeling = Afdeling.Logistiek,
                UrenPerWeek = 37,
                BasisKostprijsPerDag = 350m
            };
            Console.WriteLine(PersoneelNietVliegend);
            Console.WriteLine(((IKost)PersoneelNietVliegend).BerekenTotaleKostprijsPerDag());

            Console.WriteLine("* CockpitCrew:");
            Personeelslid PersoneelCockpit = new CockpitCrew("id", "Johan", Graad.Captain,
                new List<Certificaat> { new Certificaat("PPL", "Private Pilot Licence"), new Certificaat("CPL", "Commercial Pilot Licence") }, 20470)
            {
                Adres = new Adres("6", "6000B", "Nergens"),
                BasisKostprijsPerDag = 500m
            };
            Console.WriteLine(PersoneelCockpit);
            Console.WriteLine(((IKost)PersoneelCockpit).BerekenTotaleKostprijsPerDag());

            Console.WriteLine("* CabineCrew:");
            Personeelslid PersoneelCabine = new CabineCrew("id", "Johan", Graad.Purser,
                new List<Certificaat> { new Certificaat("PPL", "Private Pilot Licence"), new Certificaat("CPL", "Commercial Pilot Licence") }, "deur 1")
            {
                Adres = new Adres("7", "7000C", "Overal"),
                BasisKostprijsPerDag = 200m
            };
            Console.WriteLine(PersoneelCabine);
            Console.WriteLine(((IKost)PersoneelCabine).BerekenTotaleKostprijsPerDag());

            Console.WriteLine("* PassagierVliegtuig:");
            LuchtVaartuig PassagiersVliegtuig = new PassagiersVliegtuig("Boeing A730", 500, 25000, 2000m, 270);
            Console.WriteLine(PassagiersVliegtuig);
            Console.WriteLine(PassagiersVliegtuig.BerekenTotaleKostprijsPerDag());

            Console.WriteLine("* VrachtVliegtuig:");
            LuchtVaartuig VrachtVliegtuig = new VrachtVliegtuig("Loadking", 400, 2000, 1500m, 800);
            Console.WriteLine(VrachtVliegtuig);
            Console.WriteLine(VrachtVliegtuig.BerekenTotaleKostprijsPerDag());

            Console.WriteLine("* VliegMaatschappij:");            
            VliegMaatschappij VliegMaatschappij = new VliegMaatschappij(1, "Sabena", new List<LuchtVaartuig> { PassagiersVliegtuig, VrachtVliegtuig });
            Console.WriteLine(VliegMaatschappij);

            Console.WriteLine("* Vlucht OK:");
            Vlucht VluchtOK = null;            
            try
            {
                VluchtOK = new Vlucht(1, "Hier", 5, VliegMaatschappij, PassagiersVliegtuig,
                        new List<VliegendPersoneelslid> { (VliegendPersoneelslid)PersoneelCabine, (VliegendPersoneelslid)PersoneelCockpit });
            }
            catch (ToestelBehoortNietTotVlootException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine(VluchtOK);

            Console.WriteLine("* Vlucht niet OK:");
            VliegMaatschappij.RemoveLuchtVaartuig(PassagiersVliegtuig);
            Vlucht VluchtNietOK = null;
            try
            {
                VluchtNietOK = new Vlucht(1, "Hier", 5, VliegMaatschappij, PassagiersVliegtuig,
                        new List<VliegendPersoneelslid> { (VliegendPersoneelslid)PersoneelCabine, (VliegendPersoneelslid)PersoneelCockpit });
            }
            catch (ToestelBehoortNietTotVlootException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine(VluchtNietOK);
        }
    }
}
