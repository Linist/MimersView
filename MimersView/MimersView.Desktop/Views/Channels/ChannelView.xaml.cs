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

namespace MimersView.Desktop.Views.Channels
{
    /// <summary>
    /// Interaction logic for ChannelView.xaml
    /// </summary>
    public partial class ChannelView : UserControl
    {
        private string _username; // Add this at the class level

        public ChannelView(string username)
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
        }
    }
}
