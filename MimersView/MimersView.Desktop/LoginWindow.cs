using System.Windows;

namespace MimersView.Desktop
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameBox.Text;

            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Indtast et gyldigt brugernavn!", "Fejl", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Åbn chatvinduet (som vi opretter i næste trin)
            ChatWindow chatWindow = new ChatWindow(username);
            chatWindow.Show();

            // Luk loginvinduet
            this.Close();
        }
    }
}
