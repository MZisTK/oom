using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
    class Program
    {
        static double MalZwei (double x)
        {
            return 2 * x;
        }


        static double apply(Func<double,double>f, double x)
        {
            return f(x);

        }
         
        static void Main(string[] args)
        {
            Func<double, double> f = MalZwei;
            Func<string, int, bool, byte> g;
             
            Console.WriteLine(f(1.0));
            Console.WriteLine(apply(f,1.0));
        }
    }
}
