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
         private static void CopyPasteAlleObjectenUitTekstFile()
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

         }
    }
}
