using System.Windows;

namespace MimersView.Desktop
{
    public partial class ChatWindow : Window
    {
        private string _username;

        public ChatWindow(string username)
        {
            InitializeComponent();
            _username = username;

            // Tilføj en velkomstbesked
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
    }
}
