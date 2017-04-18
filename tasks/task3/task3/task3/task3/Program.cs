using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading.Tasks;


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
            Console.WriteLine($"Flugzeug: { m_Marke} - {m_Modell}, Besatzung: { b_Besatzung} Passagiere: { b_Passagiere}");
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
        public string m_Marke => Marke;
        public string m_Modell => Modell;
        public int b_Besatzung => Besatzung;
        public int b_Passagiere => Passagiere;

  

        private readonly Subject<Flugzeug> ist_beladen = new Subject<Flugzeug>();
        public IObservable<Flugzeug> beladen { get { return ist_beladen.AsObservable(); } }
      
    }
    class Auto : ITransportmittel
    {
        public void Print()
        {
            Console.WriteLine($"Auto: { a_marke}, Preis: {a_preis}");
        }
        
        private string mMarke;
        private double Preis;

        public Auto(string dieMarke, double derPreis) 
        {
            if (dieMarke == null || dieMarke.Length < 1)
                throw new Exception("Keine Marke");
            mMarke = dieMarke;
            if (derPreis < 0)
                throw new Exception("negativer Preis");
            Preis = derPreis;
        }
        public string a_marke => mMarke;
        public double a_preis => Preis;
        public void SetPreis(double neuerPreis)
        {
            if (neuerPreis < 0)
                throw new Exception("negativer Preis");
            Preis = neuerPreis;
        }
    }

    
    class Program
    {
        private DateTime CountToAsync(int num)
        {
            DateTime a;
            a = DateTime.Now.AddDays(num); 
            return a;
        }
        static void Main(string[] args)
        {
            DateTime Zeitpunkt = Task.Run(CountToAsync(10));
            try
            {
                Auto eins = new Auto("Mazda", 20000);
                Flugzeug zweites = new Flugzeug("Boeing", "747-8", 2, 605);
                eins.SetPreis(1000);

                var flightmachine = new Flugzeug("Nikki", "ersteMaschine", 6, 300);
                flightmachine.beladen.Subscribe(_ => Console.WriteLine("Vollbeladen"));

                ITransportmittel[] TranspArray = { flightmachine,eins, new Auto("Audi", 30000.5), new Flugzeug("Airbus", "A380", 2, 853), zweites };

                string maschine = JsonConvert.SerializeObject(TranspArray, Formatting.Indented);
                System.IO.File.WriteAllText(@"C:\temp\task4.json", maschine);
                using (StreamReader file = File.OpenText(@"C:\temp\task4.json"))
                {
                    using (JsonTextReader read = new JsonTextReader(file))
                    {
                        JArray reader = (JArray)JToken.ReadFrom(read);
                        foreach( var variable in reader )
                        {
                            Console.WriteLine(variable.ToString());
                        }
                    }
                }
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