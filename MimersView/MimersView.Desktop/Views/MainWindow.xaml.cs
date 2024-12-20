using System.Collections.ObjectModel;
using System.Windows;
using MimersView.Desktop.Views;

namespace MimersView.Desktop
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<Channel> Channels { get; set; } = new ObservableCollection<Channel>();
        private readonly string _username;

        public MainWindow(string username)
        {
            InitializeComponent();
            _username = username;

            // Populate sample channels
            PopulateChannels();

            // Bind the channel list
            ChannelList.ItemsSource = Channels;

            // Set the default content to the ProfileView with the username
            var profileView = new Views.Profile.Profileview
            {
                Username = _username,
            };

            MainContent.Content = profileView;
        }

        // Populate the channel list with sample data
        private void PopulateChannels()
        {
            Channels.Add(new Channel { Name = "General" });
            Channels.Add(new Channel { Name = "Development" });
            Channels.Add(new Channel { Name = "Design" });
        }

        // Handle channel selection changes
        private void ChannelList_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (ChannelList.SelectedItem is Channel selectedChannel)
            {
                // Open the selected channel view and pass the username
                var channelView = new Views.Channels.ChannelView(_username)
                {
                    DataContext = selectedChannel
                };

                MainContent.Content = channelView;
            }
        }

        private void ProfileBtn_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new Views.Profile.Profileview();
        }

        private void ChannelsBtn_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new Views.ChannelOverview();
        }

        private void SettingsBtn_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new Views.SettingsView();
        }

        private void ClassesBtn_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new Views.ClassesView();
        }

        private void SchoolBtn_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new Views.SchoolView();
        }

        private void ClassmatesButton_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new Views.ClassmatesView();
        }


    }

    // Sample Channel model
    public class Channel
    {
        public string Name { get; set; } = string.Empty;
    }
}
