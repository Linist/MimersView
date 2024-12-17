using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;  

namespace MimersView.Desktop
{
    public partial class ChatWindow : Window
    {
        private string _username;

        public ChatWindow(string username)
        {
            InitializeComponent();
            _username = username;

            // Tilf�j en velkomstbesked
            MessageList.Items.Add($"Velkommen, {_username}!");
        }

        private void SendMessage_Click(object sender, RoutedEventArgs e)
        {
            string message = MessageInput.Text;

            if (!string.IsNullOrWhiteSpace(message))
            {
                // Tilf�j beskeden til listen
                MessageList.Items.Add($"{_username}: {message}");

                // Ryd inputboksen
                MessageInput.Clear();
            }
        }
        private void MessageInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) // Send besked ved tryk p� Enter
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
            // Tilf�j beskeden og scroll ned
            MessageList.Items.Add($"{user}: {message}");
            MessageList.ScrollIntoView(MessageList.Items[MessageList.Items.Count - 1]);
        }

        private void Smiley_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                // Tilf�j emoji til inputfeltet
                MessageInput.Text += button.Content.ToString();
                MessageInput.Focus();
                MessageInput.CaretIndex = MessageInput.Text.Length; // Flyt caret til slutningen
            }
        }
    }
}
