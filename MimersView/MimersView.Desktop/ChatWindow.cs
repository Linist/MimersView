using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows.Media;

namespace MimersView.Desktop
{
    public partial class ChatWindow : Window
    {
        private string _username;

        public ChatWindow(string username)
        {
            InitializeComponent();
            _username = username;

            // Set focus to the input box
            MessageInput.Focus();

            // Add a welcome message
            MessageList.Items.Add($"Velkommen, {_username}!");
        }


        private void SendMessage_Click(object sender, RoutedEventArgs e)
        {
            string message = MessageInput.Text;

            if (!string.IsNullOrWhiteSpace(message))
            {
                // Tilføj beskeden til listen
                MessageList.Items.Add($"{_username}: {message}");

                // Ryd inputboksen
                MessageInput.Clear();
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


        private void Smiley_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                // Tilføj emoji til inputfeltet
                MessageInput.Text += button.Content.ToString();
                MessageInput.Focus();
                MessageInput.CaretIndex = MessageInput.Text.Length; // Flyt caret til slutningen
            }
        }
    }
}
