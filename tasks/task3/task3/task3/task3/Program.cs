using System;


namespace task3

{
    interface ITransportmittel
    {
        void Print();
    }

    class Flugzeug : ITransportmittel
    {
        public void Print()
        {
            Console.WriteLine($"Flugzeug: { GetMarke()} - {GetModell()}, Besatzung: { GetBesatzung()} Passagiere: { GetPassagiere()}");
        }

        private string Marke;
        private string Modell;
        private int Besatzung;
        private int Passagiere;

        public Flugzeug(string neueMarke, string neuesModell, int neueBesatzung, int neuePassagiere)
        {
            if (neueMarke == null || neueMarke.Length < 1)
                throw new Exception("Keine Marke");
            Marke = neueMarke;
            if (neuesModell == null || neuesModell.Length < 1)
                throw new Exception("Kein Modell");
            Modell = neuesModell;
            if (neueBesatzung < 0)
                throw new Exception("negative Besatzungsanzahl");
            Besatzung = neueBesatzung;
            if (neuePassagiere < 0)
                throw new Exception("negative Passagieranzahl");
            Passagiere = neuePassagiere;
        }
        public string GetMarke() => Marke;
        public string GetModell() => Modell;
        public int GetBesatzung() => Besatzung;
        public int GetPassagiere() => Passagiere;
    }
    class Auto : ITransportmittel
    {
        public void Print()
        {
            Console.WriteLine($"Auto: { GetMarke()}, Preis: {GetPreis()}");
        }
        
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
                Flugzeug zweites = new Flugzeug("Boeing", "747-8", 2, 605);
                eins.SetPreis(1000);
                ITransportmittel[] TranspArray = { eins, new Auto("Audi", 30000.5), new Flugzeug("Airbus", "A380", 2, 853), zweites };
                foreach (ITransportmittel Transportmitel in TranspArray)
                {
                    Transportmitel.Print();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Es ist was passiert ({e.Message})");
            }
        }
    }

}