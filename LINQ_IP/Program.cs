using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_IP
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] sorok = System.IO.File.ReadAllLines("ip.txt");
            Console.WriteLine(sorok.Count());
            Console.WriteLine(sorok.Min());
            Console.WriteLine(sorok.Where(sor => sor.StartsWith("2001:0db8")).Count());
            Console.WriteLine(sorok.Where(sor => sor.StartsWith("2001:0e")).Count());
            Console.WriteLine(sorok.Where(sor => {
                return sor.StartsWith("fc") || sor.StartsWith("fd");
            }).Count());
            var soknulla = sorok.Where(sor => sor.Count(c => c=='0')>18);
            
            System.IO.File.WriteAllText("sok.txt", string.Join(" ",soknulla));
            Console.ReadKey();
        }
    }
}
