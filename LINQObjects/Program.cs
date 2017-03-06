using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("Titanic.csv").Skip(1);
            var persons = lines.Select((line) =>
            {
                var words = line.Split(',');
                return new Person(
                    words[2]+words[1], 
                    words[3],
                    words[4] == "NA" ?  -1 : (int)Math.Floor(Double.Parse(words[4], CultureInfo.InvariantCulture)),
                    words[5] == "male" ? Sex.Male : Sex.Female,
                    Int32.Parse(words[6]) == 1
                    );
            });
            

            // 1. Hányan utaztak össz
            Console.WriteLine(persons.Count());
           // 2. Mennyi volt az átlagéletkor (vigyázz a -1-re)
            Console.WriteLine(persons.Where(person => person.Age>0).Select(person => person.Age).Average());
            // 3. Túlélési arány férfi / nő
            Console.WriteLine(
                (double)persons.Where(person => person.Survived).Count(person => person.Sex==Sex.Male)/
                persons.Where(person => person.Survived).Count()
                );
            // 4. Túlélési arány osztályonként
            var osztalyok = persons.Select(person => person.PClass).Distinct();
            var aranyok = osztalyok.Select(osztaly => {
                return osztaly+":"+
                (double)persons.Count(person => person.PClass == osztaly && person.Survived) /
                persons.Count(person => person.PClass == osztaly);
            });
            Console.WriteLine(string.Join("\n", aranyok));

            Console.ReadKey();
        }
    }
}
