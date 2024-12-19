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

        // Event handler for the Exit button
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SendMessage_Click(object sender, RoutedEventArgs e)
        {
            string message = MessageInput.Text.Trim();

            if (!string.IsNullOrWhiteSpace(message))
            {
                // Tilf�j beskeden til listen
                MessageList.Items.Add($"{_username}: {message}");

                // Ryd inputboksen
                MessageInput.Clear();

                // Optionally scroll to the latest message
                MessageList.ScrollIntoView(message);
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
            if (sender is System.Windows.Controls.Button button)
            {
                // Append the smiley to the message input field
                MessageInput.Text += button.Content.ToString();
                MessageInput.Focus();
                MessageInput.CaretIndex = MessageInput.Text.Length; // Move caret to the end
            }
        }

        // Handle keyboard shortcuts
        private void ChatWindow_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                SendMessage_Click(this, null!);
            }
            else if (e.Key == System.Windows.Input.Key.Escape)
            {
                Exit_Click(this, null!);
            }
        }
    }
}
