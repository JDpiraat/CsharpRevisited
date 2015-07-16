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
            TestNaVierUur();

            // mooi afsluiten programma
            Console.WriteLine();
            Console.WriteLine("Druk <enter> om af te sluiten");
            Console.ReadLine();

        }        
    }
}
