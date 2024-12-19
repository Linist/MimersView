using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using MimersView.Desktop.Views;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MimersView.Desktop
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<Channel> Channels { get; set; } = new ObservableCollection<Channel>();
        private string _username;

        public MainWindow(string username)
        {
            InitializeComponent();
            _username = username;

            // Populate sample channels
            Channels.Add(new Channel { Name = "General" });
            Channels.Add(new Channel { Name = "Development" });
            Channels.Add(new Channel { Name = "Design" });

            // Bind the channel list
            ChannelList.ItemsSource = Channels;

            // Set the default content to the ProfileView
            MainContent.Content = new Views.Profile.Profileview();
        }

        private void ChannelList_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (ChannelList.SelectedItem is Channel selectedChannel)
            {
                // Open the selected channel and pass the username
                MainContent.Content = new Views.Channels.ChannelView(_username)
                {
                    DataContext = selectedChannel
                };
            }
        }
    }

    // Sample Channel model
    public class Channel
    {
        public required string Name { get; set; }
    }
}