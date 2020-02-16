using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfCustomerPreferenceCentre
{
    public class PersonMarketingPreference
    {
        public Person Person { get; set; }
        public string MarketingPreference { get; set; }

        public PersonMarketingPreference(Person person)
        {
            Person = person;

            if (Person.EveryDay == true)
                MarketingPreference = "Everyday";

            if (Person.WeekDay != "")
                MarketingPreference = person.WeekDay;

            if (Person.SpecificDay.Year != 0001)
                MarketingPreference = person.SpecificDay.ToShortDateString();

            if (Person.Never == true)
                MarketingPreference = "Never";
        }
    }
}
