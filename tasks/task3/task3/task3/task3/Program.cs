using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
    class Program
    {
       


        static double apply(Func<double,double>f, double x)
        {
            return f(x);
        }

       

        static void Main(string[] args)
        {
            /*
            Func<double, double> f =  x => 2 * x; 
            Func<string, int, bool, byte> g;
            Console.WriteLine(f(1.0)); 
            Console.WriteLine(apply(f,1.0));*/

            var xs = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            //xs ist ein Kunden array -> verdoppeln
             

        }
    }
}
