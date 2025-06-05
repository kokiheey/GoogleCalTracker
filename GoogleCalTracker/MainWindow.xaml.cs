using System.Windows;

namespace GoogleCalTracker
{
    public partial class MainWindow : Window
    {

        EventType? selectedEventType;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnEventTypeAdd_Click(object sender, RoutedEventArgs e)
        {
            //Show dialogue
            var dialog = new AddEventDialog();
            dialog.ShowDialog();
        }

    }
}
