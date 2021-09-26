using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_DataGrid
{
    public class Person
    {

        public static List<Person> list;

        public string Name { get; set; }
        //public string Name;
        public string SurName { get; set; }
        //public string SurName;

        public int Age { get; set; }

        public DateTime BirthDate { get; set; }
        public Person()
        {

        }

        public Person(string name, string surname, int age)
        {
            Name = name;
            SurName = surname;
            Age = age;
        }
    }
}
