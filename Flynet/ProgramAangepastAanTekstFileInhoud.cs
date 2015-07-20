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
        private static IList<Vlucht> AanmakenVluchtObjecten()
        {
            //****************************************************************************************
            //Vliegtuigen
            //****************************************************************************************

            //Passagiersvliegtuigen
            //****************************************************************************************
            PassagiersVliegtuig airbusA319 = new PassagiersVliegtuig
            {
                Type = "AirbusA319",
                AantalPassagiers = 141,
                Vliegbereik = 6850,
                Kruissnelheid = 880,
                BasisKostprijsPerDag = 1000m
            };

            PassagiersVliegtuig boeing737 = new PassagiersVliegtuig
            {
                Type = "Boeing737 ",
                AantalPassagiers = 190,
                Vliegbereik = 12500,
                Kruissnelheid = 850,
                BasisKostprijsPerDag = 1500m
            };

            PassagiersVliegtuig boeing787 = new PassagiersVliegtuig
            {
                Type = "Boeing787",
                AantalPassagiers = 330,
                Vliegbereik = 15700,
                Kruissnelheid = 913,
                BasisKostprijsPerDag = 2000m
            };

            //VrachtVliegtuigen
            //****************************************************************************************

            VrachtVliegtuig antonovAn30 = new VrachtVliegtuig
            {
                Type = "AntonovAn-30",
                LaadVermogen = 8,
                Vliegbereik = 1600,
                Kruissnelheid = 430,
                BasisKostprijsPerDag = 300m
            };

            VrachtVliegtuig britishAerospace146 = new VrachtVliegtuig
            {
                Type = "BritishAerospace146",
                LaadVermogen = 42,
                Vliegbereik = 1600,
                Kruissnelheid = 750,
                BasisKostprijsPerDag = 600m
            };

            VrachtVliegtuig antonovAn225 = new VrachtVliegtuig
            {
                Type = "AntonovAn-225",
                LaadVermogen = 425,
                Vliegbereik = 15400,
                Kruissnelheid = 800,
                BasisKostprijsPerDag = 1500m
            };

            //****************************************************************************************
            //Personeel
            //****************************************************************************************

            //Certificaten
            //****************************************************************************************
            Certificaat PPL = new Certificaat
            {
                CertificaatAfkorting = "PPL",
                CertificaatOmschrijving = "Private Pilot License"
            };

            Certificaat ATPL = new Certificaat
            {
                CertificaatAfkorting = "ATPL",
                CertificaatOmschrijving = "Airline Transport Pilot License"
            };

            Certificaat IR = new Certificaat
            {
                CertificaatAfkorting = "IR",
                CertificaatOmschrijving = "Instrument Rating"
            };

            Certificaat CPL = new Certificaat
            {
                CertificaatAfkorting = "CPL",
                CertificaatOmschrijving = "Commercial Pilot License"
            };

            Certificaat ME = new Certificaat
            {
                CertificaatAfkorting = "ME",
                CertificaatOmschrijving = "Multi Engine"
            };

            Certificaat MCC = new Certificaat
            {
                CertificaatAfkorting = "MCC",
                CertificaatOmschrijving = "Multi Crew Concept"
            };

            Certificaat EHBO = new Certificaat
            {
                CertificaatAfkorting = "EHBO",
                CertificaatOmschrijving = "First Aid"
            };

            Certificaat EVAC = new Certificaat
            {
                CertificaatAfkorting = "EVAC",
                CertificaatOmschrijving = "Evacution Procedures"
            };

            Certificaat FIRE = new Certificaat
            {
                CertificaatAfkorting = "FIRE",
                CertificaatOmschrijving = "Fire Fighting"
            };

            Certificaat SURV = new Certificaat
            {
                CertificaatAfkorting = "SURV",
                CertificaatOmschrijving = "Survival"
            };

            Certificaat IFS = new Certificaat
            {
                CertificaatAfkorting = "IFS",
                CertificaatOmschrijving = "In Flight Service"
            };

            //Adressen
            //****************************************************************************************
            Adres Europalaan = new Adres("Europalaan 37", "3600", "Genk");

            Adres Keizerslaan = new Adres("Keizerslaan 11", "1000", "Brussel");

            //VliegendPersoneel
            //****************************************************************************************

            //Cockpit

            CockpitCrew CaptianKirk = new CockpitCrew("001", "Captain Kirk", Graad.Captain, new List<Certificaat> { PPL, ATPL, CPL, SURV }, 5000)
            {
                Adres = Europalaan,
                BasisKostprijsPerDag = 500m
            };

            CockpitCrew Spock = new CockpitCrew("002", "Spock", Graad.SecondOfficer, new List<Certificaat> { PPL, ATPL, CPL, IFS }, 4500)
            {
                Adres = Keizerslaan,
                BasisKostprijsPerDag = 400m
            };

            CockpitCrew McCoy = new CockpitCrew("003", "McCoy", Graad.SeniorFlightOfficer, new List<Certificaat> { PPL, ME, MCC, EHBO }, 4500)
            {
                Adres = Europalaan,
                BasisKostprijsPerDag = 400m
            };

            //Cabine

            CabineCrew PavelCehekov = new CabineCrew("004", "Pavel Cehekov", Graad.Purser, new List<Certificaat> { ME, MCC, EHBO, IFS }, "deur1")
            {
                Adres = Europalaan,
                BasisKostprijsPerDag = 300m
            };

            CabineCrew HikaruSulu = new CabineCrew("005", "Hikaru Sulu", Graad.Steward, new List<Certificaat> { ME, MCC, FIRE, SURV, IFS }, "deur2")
            {
                Adres = Europalaan,
                BasisKostprijsPerDag = 300m
            };

            CabineCrew SkyWalker = new CabineCrew("006", "SkyWalker", Graad.Steward, new List<Certificaat> { FIRE, SURV, IFS, EHBO }, "nooduitgang")
            {
                Adres = Keizerslaan,
                BasisKostprijsPerDag = 300m
            };

            //****************************************************************************************
            //Vliegmaatschappijen
            //****************************************************************************************

            VliegMaatschappij BrusselsAirlines = new VliegMaatschappij(1, "BrusselsAirlines", new List<LuchtVaartuig> { airbusA319, boeing737, boeing787, britishAerospace146 });

            VliegMaatschappij TNTAirways = new VliegMaatschappij(2, "TNTAirways", new List<LuchtVaartuig> { antonovAn30, antonovAn225, antonovAn30 });

            VliegMaatschappij JetairFly = new VliegMaatschappij(3, "JetairFly", new List<LuchtVaartuig> { boeing737, boeing787 });

            VliegMaatschappij ThomasCook = new VliegMaatschappij(4, "ThomasCook", new List<LuchtVaartuig> { airbusA319, boeing787 });

            //****************************************************************************************
            //Vluchten
            //****************************************************************************************

            IList<Vlucht> Vluchten = new List<Vlucht>();

            Vlucht NewYork = new Vlucht(1, "New York", 2, BrusselsAirlines, boeing787, new List<VliegendPersoneelslid> { CaptianKirk, Spock, PavelCehekov, HikaruSulu });
            NewYork.ToString();

            Vlucht Bejing = new Vlucht(2, "Bejing", 1, TNTAirways, antonovAn225, new List<VliegendPersoneelslid> { CaptianKirk, SkyWalker });

            Vlucht Sydney = new Vlucht(3, "Sydney", 3, ThomasCook, airbusA319, new List<VliegendPersoneelslid> { CaptianKirk, Spock, PavelCehekov, HikaruSulu });

            Vlucht Signapore = new Vlucht(4, "Singnapore", 2, BrusselsAirlines, britishAerospace146, new List<VliegendPersoneelslid> { McCoy, HikaruSulu, SkyWalker });

            Vlucht Malta = new Vlucht(5, "Malta", 1, JetairFly, boeing737, new List<VliegendPersoneelslid> { CaptianKirk, Spock, SkyWalker });

            Vluchten.Add(NewYork);
            Vluchten.Add(Bejing);
            Vluchten.Add(Sydney);
            Vluchten.Add(Signapore);
            Vluchten.Add(Malta);

            return Vluchten;
        }

        private static void PrintOverzicht(IList<Vlucht> vluchten)
        {
            IList<Vlucht> PassagiersVluchten = (IList<Vlucht>)vluchten.Where(vlucht => (vlucht.Toestel is PassagiersVliegtuig)).ToList();
            IList<Vlucht> VrachtVluchten = (IList<Vlucht>)vluchten.Where(vlucht => (vlucht.Toestel is VrachtVliegtuig)).ToList();

            Console.WriteLine("+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-");
            Console.WriteLine("PASSAGIERSVLUCHTEN:");
            Console.WriteLine("+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-");
            foreach (Vlucht vlucht in PassagiersVluchten)
            {
                PrintVlucht(vlucht);
            }
            Console.WriteLine();
            Console.WriteLine("+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-");
            Console.WriteLine("VRACHTVLUCHTEN:");
            Console.WriteLine("+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-");
            Console.WriteLine();
            foreach (Vlucht vlucht in VrachtVluchten)
            {
                PrintVlucht(vlucht);
            }
            Console.WriteLine();

        }

        private static void PrintVlucht(Vlucht vlucht)
        {
            Console.WriteLine();
            Console.WriteLine(vlucht.ToString());
            Console.WriteLine();
            Console.WriteLine("Totale personeelskosten: {0}", vlucht.Personeel.Sum(personeelslid => ((IKost)personeelslid).BerekenTotaleKostprijsPerDag() * vlucht.Duurtijd));
            Console.WriteLine();
            Console.WriteLine("Cockpitpersoneel:");
            ((List<VliegendPersoneelslid>)vlucht.Personeel).ForEach(personeelslid =>
            {
                if (personeelslid is CockpitCrew)
                {
                    Console.WriteLine();
                    Console.WriteLine(personeelslid.ToString());
                    Console.WriteLine("Kostprijs voor deze vlucht = " + ((IKost)personeelslid).BerekenTotaleKostprijsPerDag() * vlucht.Duurtijd);
                }
            });
            Console.WriteLine();
            Console.WriteLine("Cabinepersoneel:");
            ((List<VliegendPersoneelslid>)vlucht.Personeel).ForEach(personeelslid =>
            {
                if (personeelslid is CabineCrew)
                {
                    Console.WriteLine();
                    Console.WriteLine(personeelslid.ToString());
                    Console.WriteLine("Kostprijs voor deze vlucht = " + ((IKost)personeelslid).BerekenTotaleKostprijsPerDag() * vlucht.Duurtijd);
                }

            });
            Console.WriteLine();
        }

    }
}
