using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lession08.Task04
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public DateTime BirthDate { get; set; }

        public Person()
        {
            FirstName = "Имя";
            LastName = "Фамилия";
            MiddleName = "Отчество";
            BirthDate = DateTime.Now.Date;
        }
    }
}
