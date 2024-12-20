using System.Windows;
using System.Windows.Controls;

namespace MimersView.Desktop.Views
{
    public partial class SchoolView : UserControl
    {
        public SchoolView()
        {
            InitializeComponent();
        }

        private void LearnMore_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("More information about learning and wellbeing.", "Learn More", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void UNGoals_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("More information about UN goals certification.", "Learn More", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void PBL_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("More information about Project-Based Learning.", "Learn More", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void FruitProgram_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("More information about the Fruit Program.", "Learn More", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void NewStudent_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("More information for new students.", "Learn More", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Facebook_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Visit our Facebook page.", "Learn More", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}