using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace MimersView.Desktop.Views
{
    public partial class ChannelOverview : UserControl
    {
        public ObservableCollection<Channel> Channels { get; set; } = [];

        public ChannelOverview()
        {
            InitializeComponent();

            // Add sample data
            Channels.Add(new Channel { Name = "General" });
            Channels.Add(new Channel { Name = "Development" });
            Channels.Add(new Channel { Name = "Design" });

            // Bind the channel list
            ChannelListView.ItemsSource = Channels;
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var searchText = SearchBox.Text.ToLower();

            // Filter channels
            var filteredChannels = Channels
                .Where(c => c.Name.Contains(searchText, StringComparison.CurrentCultureIgnoreCase))
                .ToList();

            ChannelListView.ItemsSource = filteredChannels;
        }

        private void EditChannel_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is Channel channel)
            {
                MessageBox.Show($"Edit channel: {channel.Name}", "Edit Channel", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void RemoveChannel_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is Channel channel)
            {
                var result = MessageBox.Show($"Are you sure you want to remove {channel.Name}?", "Remove Channel", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    Channels.Remove(channel);
                }
            }
        }
    }

    public class Channel
    {
        public required string Name { get; set; }
    }
}