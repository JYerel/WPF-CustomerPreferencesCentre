using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfCustomerPreferenceCentre
{
    public class Person
    {

        public string PersonName { get; set; }
        public bool EveryDay { get; set; }
        public string WeekDay { get; set; }
        public DateTime SpecificDay { get; set; }
        public bool Never { get; set; }

        public Person(string personName)
        {
            PersonName = personName;
        }

        public bool HasValidPreference(Person person)
        {
            if (PersonName.Trim() != "")
            {
                if (EveryDay == true || WeekDay != "" || SpecificDay.Date.Year != 0001 || Never == true)
                    return true;
            }

            return false;
        }
    }
}
