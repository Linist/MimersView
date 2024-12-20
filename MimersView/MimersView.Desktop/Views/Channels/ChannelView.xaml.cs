using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace MimersView.Desktop.Views.Channels
{
    public partial class ChannelView : UserControl
    {
        private readonly string _username;
        private readonly MimersView.Desktop.Channel selectedChannel;

        public ChannelView(string username, MimersView.Desktop.Channel channel)
        {
            InitializeComponent();
            _username = username;
            selectedChannel = channel; // Assign the channel to the field
            DataContext = selectedChannel; // Set the channel as DataContext for binding

            // Set focus to the input box
            MessageInput.Focus();
            // Add a welcome message
            MessageList.Items.Add($"Velkommen til denne channel {_username}!");
        }

        private void SendMessage_Click(object sender, RoutedEventArgs e)
        {
            string message = MessageInput.Text.Trim();

            if (!string.IsNullOrWhiteSpace(message))
            {
                // Tilføj beskeden til listen
                MessageList.Items.Add($"{_username}: {message}");

                // Ryd inputboksen
                MessageInput.Clear();

                // Optionally scroll to the latest message
                MessageList.ScrollIntoView(message);
            }
        }
        private void MessageInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) // Send besked ved tryk på Enter
            {
                SendMessage();
            }
        }

        private void SendMessage()
        {
            string message = MessageInput.Text;

            if (!string.IsNullOrWhiteSpace(message))
            {
                AddMessage(_username, message);
                MessageInput.Clear();
            }
        }

        private void AddMessage(string user, string message)
        {
            string timestamp = DateTime.Now.ToString("HH:mm:ss");
            string fullMessage = $"[{timestamp}] {user}: {message}";

            var listBoxItem = new ListBoxItem
            {
                Content = fullMessage,
                HorizontalContentAlignment = user == _username ? HorizontalAlignment.Right : HorizontalAlignment.Left,
                Background = user == _username ? Brushes.LightBlue : Brushes.White,
                Margin = new Thickness(5),
                Padding = new Thickness(5)
            };

            MessageList.Items.Add(listBoxItem);
            MessageList.ScrollIntoView(listBoxItem);
        }

        // Event handler for smiley buttons
        private void Smiley_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                MessageInput.Text += button.Content.ToString();
                MessageInput.Focus();
                MessageInput.CaretIndex = MessageInput.Text.Length; // Place caret at the end
            }
        }

        private void ToggleSmileyPanel_Click(object sender, RoutedEventArgs e)
        {
            SmileyPanel.Visibility = SmileyPanel.Visibility == Visibility.Collapsed ? Visibility.Visible : Visibility.Collapsed;
        }

        private void UploadFile_Click(object sender, RoutedEventArgs e)
        {
            // Create OpenFileDialog
            Microsoft.Win32.OpenFileDialog openFileDialog = new()
            {
                Title = "Select a File",
                Filter = "All Files (*.*)|*.*",
                Multiselect = false // Set to true if you want to allow multiple file selection
            };

            // Show the dialog and process the selected file
            if (openFileDialog.ShowDialog() == true)
            {
                string selectedFile = openFileDialog.FileName;

                // Add the file as a message to the message list (or handle it as required)
                MessageList.Items.Add($"File uploaded: {selectedFile}");
            }
        }

        // Handle keyboard shortcuts
        private void ChatWindow_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                SendMessage_Click(this, null!);
            }
        }
    }
}