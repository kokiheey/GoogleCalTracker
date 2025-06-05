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
using System.Windows.Shapes;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
namespace GoogleCalTracker
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class AddEventDialog : Window
    {
        public EventType createdEvent;
        Google.Apis.Calendar.v3.Data.Colors colors;
        public AddEventDialog()
        {
            InitializeComponent();
            createdEvent = new EventType();
            colors = new Google.Apis.Calendar.v3.Data.Colors();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
             colors = await GoogleCalendarApi.GetAvailableColorsAsync();
        }
    }
}
