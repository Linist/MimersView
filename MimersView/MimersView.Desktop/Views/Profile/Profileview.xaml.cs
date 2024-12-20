using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace MimersView.Desktop.Views.Profile
{
    public partial class Profileview : UserControl, INotifyPropertyChanged
    {

        private string _username;
        private DateTime _currentDate;

        // Properties for Username and CurrentDate (INotifyPropertyChanged)
        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        public DateTime CurrentDate
        {
            get => _currentDate;
            set
            {
                _currentDate = value;
                OnPropertyChanged(nameof(CurrentDate));
            }
        }

        // Constructor
        public Profileview()
        {
            InitializeComponent();
            DataContext = this;
            _username = "Guest";
            // Set current date to be displayed
            CurrentDate = DateTime.Now;
        }

        // INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler? PropertyChanged;

        // OnPropertyChanged method to notify the UI of changes
        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
