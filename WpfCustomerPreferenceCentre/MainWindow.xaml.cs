using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfCustomerPreferenceCentre
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<PersonMarketingPreference> personLists = new List<PersonMarketingPreference>();

        public MainWindow()
        {
            InitializeComponent();
            SetBlackOutDates();
        }

        private void RunReport_Click(object sender, RoutedEventArgs e)
        {
            displayInfo.Items.Clear(); 

            foreach (var personItemList in personLists)
            {
                Report report = new Report();
                report.RunReport(personItemList,displayInfo);
            }
        }

        private void AddPerson_Click(object sender, RoutedEventArgs e)
        {
            Person person = new Person(personName.Text) {EveryDay = everyDay.IsChecked == true,
                WeekDay = weekDay.Text,
                Never = neverDay.IsChecked == true
            };
            // Wanted to have it on the initialisation but need to check for nulls first
            if (calendarDate.SelectedDate != null) person.SpecificDay = calendarDate.SelectedDate.Value; 

            if (!person.HasValidPreference(person)) return; // Validation

            PersonMarketingPreference personMarketing = new PersonMarketingPreference(person);
            personLists.Add(personMarketing);
            displayInfo.Items.Add(personMarketing.Person.PersonName + " - " + personMarketing.MarketingPreference); // Display in ListBox
            ClearFields();
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
        }

        private void ClearAll_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
            displayInfo.Items.Clear();
        }

        private void SetBlackOutDates()
        {
            //First Date range not shown to user
            DateTime firstDateBlock = new DateTime(2019, 1, 1);
            DateTime endFirstDateBlock = DateTime.Now.AddDays(-1);

            //Second date range not shown to user
            DateTime secondDateBlock = DateTime.Now.AddDays(90);
            DateTime endSecondDateBlock = new DateTime(2021, 12, 31);

            //Show black out dates on Calendar
            calendarDate.BlackoutDates.Add(new CalendarDateRange(firstDateBlock, endFirstDateBlock));
            calendarDate.BlackoutDates.Add(new CalendarDateRange(secondDateBlock, endSecondDateBlock));
        }

        private void ClearFields()
        {
            personName.Text = string.Empty;
            weekDay.Text = string.Empty;
            everyDay.IsChecked = false;
            neverDay.IsChecked = false;
            calendarDate.SelectedDate = null;
        }
    }
}
