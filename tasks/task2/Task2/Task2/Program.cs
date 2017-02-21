using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{

    class Auto
    {
       private string Marke;
       private double Preis;

        public Auto(string dieMarke, double derPreis)
        {
            if (dieMarke == null || dieMarke.Length < 1)
                throw new Exception("Keine Marke");
            Marke = dieMarke;
            if (derPreis < 0)
                throw new Exception("negativer Preis");
            Preis = derPreis;
        }

        public string GetMarke() { return Marke; }
        public double GetPreis() { return Preis; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Auto eins = new Auto("Mazda", 20000);
            Auto zwei = new Auto("audi", 30000.5);
            Console.WriteLine($"Auto: { eins.GetMarke()} {eins.GetPreis()}");
            Console.WriteLine($"Auto: {zwei.GetMarke()} {zwei.GetPreis()}");
        }
    }
}