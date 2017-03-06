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

        public string GetMarke() => Marke;
        public double GetPreis() { return Preis; }

        
        
        public void SetPreis(double neuerPreis)
        {
            if (neuerPreis < 0)
                throw new Exception("negativer Preis");
            Preis = neuerPreis;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Auto eins = new Auto("Mazda", 20000);
                Auto zwei = new Auto("Audi", 30000.5);
                eins.SetPreis(1000);
                Console.WriteLine($"Auto: { eins.GetMarke()} {eins.GetPreis()}");
                Console.WriteLine($"Auto: {zwei.GetMarke()} {zwei.GetPreis()}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Es ist was passiert ({e.Message})");
            }
        }
    }
}