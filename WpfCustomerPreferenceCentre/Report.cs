using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfCustomerPreferenceCentre
{
    public class Report
    {
        public void RunReport(PersonMarketingPreference personPreference, ListBox textListBox)
        {
            for (int day = 0; day <= 90; day++)
            {
                if (personPreference.MarketingPreference == "Never") // No need to go through all 90 days
                    return;
                
                DateTime currentDate = DateTime.Now.AddDays(day); // Get current date + n
                currentDate = currentDate.Date; // Date Only

                if (ReportLogic(currentDate, personPreference) != "") // Don't print if string is empty
                    textListBox.Items.Add(ReportLogic(currentDate, personPreference));
            }
        }

        public string ReportLogic(DateTime dateCalculation, PersonMarketingPreference personPreferenceType)
        {
            if (personPreferenceType.MarketingPreference == "Everyday")
                return dateCalculation.ToString("ddd, dd-MMM-yyyy") + " - " + personPreferenceType.Person.PersonName;

            if (dateCalculation.DayOfWeek.ToString() == personPreferenceType.MarketingPreference)
                return dateCalculation.ToString("ddd, dd-MMM-yyyy") + " - " + personPreferenceType.Person.PersonName;

            if (dateCalculation.Date.ToShortDateString() == personPreferenceType.MarketingPreference)
                return dateCalculation.ToString("ddd, dd-MMM-yyyy") + " - " + personPreferenceType.Person.PersonName;

            return "";
        }
    }
}
