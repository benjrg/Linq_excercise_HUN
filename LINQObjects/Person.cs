using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQObjects
{
    class Person
    {
        public string Name { get; set; }

        public string PClass { get; set; }

        public int Age { get; set; }

        public Sex Sex { get; set; }

        public bool Survived { get; set; }

        public Person(string name, string pClass, int age, Sex sex, bool survived)
        {
            Name = name;
            PClass = pClass;
            Age = age;
            Sex = sex;
            Survived = survived;
        }
    }
}
