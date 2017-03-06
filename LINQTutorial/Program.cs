using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQTutorial
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 5, 10, 8, 3, 6, 12 };

            var query = from n in numbers
                where (n > 8)
                select n * n;
            Console.WriteLine(query.Sum());

            Console.WriteLine(numbers.Where(n => n > 8).Select(n => n * n).Sum());

            Console.WriteLine(numbers.First(n => n > 8));

            Console.WriteLine(numbers.Where(n => (n * n > 70)).Count());

            Console.ReadKey();
        }
    }
}
