using System.Windows;
using System.Windows.Input;

namespace MimersView.Desktop
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();

            // Attach keyboard event handlers
            this.KeyDown += LoginWindow_KeyDown;
        }

        // Event handler for the Exit button
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        // Event handler for the Login button
        private void Login_Click(object sender, RoutedEventArgs e)
        {
            // Retrieve the username
            string username = UsernameBox.Text;

            // For development mode, skip validation
            MessageBox.Show($"Login successful as {username} (development mode).", "Login", MessageBoxButton.OK, MessageBoxImage.Information);

            // Pass the username to the ChatWindow
            ChatWindow chatWindow = new ChatWindow(username);
            chatWindow.Show();

            // Close the LoginWindow
            this.Close();
        }

        // Event handler for the Create User button
        private void CreateUser_Click(object sender, RoutedEventArgs e)
        {
            // Uncomment and add functionality when needed
            // MessageBox.Show("Funktionen til at oprette en ny bruger er endnu ikke implementeret.", "Ny bruger", MessageBoxButton.OK, MessageBoxImage.Information);

            MessageBox.Show("Create user functionality (development mode).", "Ny bruger", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        // Handle keyboard shortcuts
        private void LoginWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Login_Click(this, null!);
            }
            else if (e.Key == Key.Escape)
            {
                Exit_Click(this, null!);
            }
        }
    }
}
