using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace MimersView.Desktop.Views
{
    public partial class ChannelOverview : UserControl
    {
        public ObservableCollection<Channel> Channels { get; set; } = new ObservableCollection<Channel>();

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
                .Where(c => c.Name.ToLower().Contains(searchText))
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