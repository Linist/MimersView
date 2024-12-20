using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MimersView.Desktop
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<Channel> Channels { get; set; } = [];
        private readonly ObservableCollection<Channel> _allChannels = []; // Backup for filtering

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

        // Event handler for the Exit button
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            // Close the application
            Application.Current.Shutdown();
        }
        // Populate the channel list with sample data
        private void PopulateChannels()
        {
            _allChannels.Add(new Channel { Name = "General" });
            _allChannels.Add(new Channel { Name = "Development" });
            _allChannels.Add(new Channel { Name = "Design" });

            // Assign the master list to Channels
            Channels = new ObservableCollection<Channel>(_allChannels);
        }

        // Add a new channel
        private void AddChannel_Click(object sender, RoutedEventArgs e)
        {
            string newChannelName = $"Channel {Channels.Count + 1}";
            var newChannel = new Channel { Name = newChannelName };
            _allChannels.Add(newChannel);
            UpdateChannelList();
        }

        // Remove the selected channel
        private void RemoveChannel_Click(object sender, RoutedEventArgs e)
        {
            if (ChannelList.SelectedItem is Channel selectedChannel)
            {
                _allChannels.Remove(selectedChannel);
                UpdateChannelList();
            }
            else
            {
                MessageBox.Show("Please select a channel to remove.", "No Channel Selected", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        // Update the displayed channel list
        private void UpdateChannelList()
        {
            Channels = new ObservableCollection<Channel>(_allChannels);
            ChannelList.ItemsSource = Channels;
        }

        // Handle channel selection changes
        private void ChannelList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ChannelList.SelectedItem is Channel selectedChannel)
            {
                var channelView = new Views.Channels.ChannelView(_username, selectedChannel);
                MainContent.Content = channelView;
            }
        }

        private void ProfileBtn_Click(object sender, RoutedEventArgs e)
        {
            var profileView = new Views.Profile.Profileview
            {
                Username = _username
            };

            MainContent.Content = profileView;
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