using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace MimersView.Desktop.Views
{
    public partial class ClassmatesView : UserControl
    {
        public ObservableCollection<Classmate> Classmates { get; set; } = new ObservableCollection<Classmate>();

        public ClassmatesView()
        {
            InitializeComponent();

            // Add sample data
            for (int i = 1; i <= 20; i++)
            {
                Classmates.Add(new Classmate { Name = $"Student {i}" });
            }

            // Bind the class list to the ListView
            ClassmatesListView.ItemsSource = Classmates;
        }

        private void DirectMessage_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is Classmate classmate)
            {
                MessageBox.Show($"Start a direct message with {classmate.Name}.", "Direct Message", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void StartChannel_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is Classmate classmate)
            {
                MessageBox.Show($"Start a channel with {classmate.Name}.", "Start Channel", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is Classmate classmate)
            {
                MessageBox.Show($"Open settings for {classmate.Name}.", "Settings", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }

    public class Classmate
    {
        public required string Name { get; set; } // Student name
    }
}
