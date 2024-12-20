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

namespace MimersView.Desktop.Views
{
    /// <summary>
    /// Interaction logic for SettingsView.xaml
    /// </summary>
    public partial class SettingsView : UserControl
    {
        public SettingsView()
        {
            InitializeComponent();
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Collapse all settings initially
            GeneralSettings.Visibility = Visibility.Collapsed;
            NotificationsSettings.Visibility = Visibility.Collapsed;
            DataSettings.Visibility = Visibility.Collapsed;
            ChannelsSettings.Visibility = Visibility.Collapsed;
            SecuritySettings.Visibility = Visibility.Collapsed;

            // Show the selected tab's settings
            if (e.Source is TabControl tabControl)
            {
                if (tabControl.SelectedItem is TabItem selectedTab)
                {
                    switch (selectedTab.Header.ToString())
                    {
                        case "General":
                            GeneralSettings.Visibility = Visibility.Visible;
                            break;
                        case "Notifications":
                            NotificationsSettings.Visibility = Visibility.Visible;
                            break;
                        case "Data":
                            DataSettings.Visibility = Visibility.Visible;
                            break;
                        case "Channels":
                            ChannelsSettings.Visibility = Visibility.Visible;
                            break;
                        case "Security":
                            SecuritySettings.Visibility = Visibility.Visible;
                            break;
                    }
                }
            }
        }
    }
}
