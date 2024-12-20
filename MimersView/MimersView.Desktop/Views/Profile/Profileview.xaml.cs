using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace MimersView.Desktop.Views.Profile
{
    public partial class Profileview : UserControl, INotifyPropertyChanged
    {

        private string _currentDate;

        private string _username;



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


        // Properties for Username and CurrentDate (INotifyPropertyChanged)
        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged();
            }
        }

        public string CurrentDate
        {
            get => _currentDate;
            set
            {
                _currentDate = value;
                OnPropertyChanged();
            }
        }

        // Constructor
        public Profileview()
        {
            InitializeComponent();
            DataContext = this;
            GeneralSettings.Visibility = Visibility.Visible; // Default tab content
            // Set current date to be displayed
            CurrentDate = DateTime.Now.ToString("dd/MM/yyyy");
        }

        // INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;

        // OnPropertyChanged method to notify the UI of changes
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
