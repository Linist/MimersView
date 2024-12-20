using System.Windows;
using System.Windows.Input;

namespace MimersView.Desktop.Views
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
            // Close the application
            Application.Current.Shutdown();
        }

        // Event handler for the Login button
        private void Login_Click(object sender, RoutedEventArgs e)
        {
            // Retrieve the username
            string username = UsernameBox.Text.Trim();

            // Open the MainWindow and pass the username
            MainWindow mainWindow = new MainWindow(username);
            mainWindow.Show();

            // Close the LoginWindow
            this.Close();

            // Uncomment and implement production logic below when ready
            /*
            string username = UsernameBox.Text.Trim();
            string password = PasswordBox.Password.Trim();

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Indtast både brugernavn og adgangskode.", "Fejl", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Placeholder login validation
            if (username == "admin" && password == "password")
            {
                MessageBox.Show("Velkommen, " + username + "!", "Login Succes", MessageBoxButton.OK, MessageBoxImage.Information);
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Ugyldigt brugernavn eller adgangskode.", "Login Fejl", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            */
        }

        // Event handler for the Create User button
        private void CreateUser_Click(object sender, RoutedEventArgs e)
        {
            // DEVELOPMENT MODE:
            MessageBox.Show("Create User functionality (development mode).", "Ny bruger", MessageBoxButton.OK, MessageBoxImage.Information);

            // Uncomment and implement navigation to user registration below when ready
            /*
            CreateUserWindow createUserWindow = new CreateUserWindow();
            createUserWindow.Show();
            this.Close();
            */
        }

        // Handle keyboard shortcuts
        private void LoginWindow_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Enter:
                    Login_Click(this, new RoutedEventArgs());
                    break;

                case Key.Escape:
                    Exit_Click(this, new RoutedEventArgs());
                    break;
            }
        }
    }
}