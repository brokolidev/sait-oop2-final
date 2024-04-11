namespace LibraryManagementSystem
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void InvenButton_Clicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync(nameof(InventoryPage));
        }

        // Login
        private void LoginButton_Clicked(object sender, EventArgs e)
        {
            string username = UsernameEntry.Text;
            string password = PasswordEntry.Text;

            // hardcoded username and password, should be replaced with real account with db connection
            if(username == "admin" && password == "admin")
            {
                System.Diagnostics.Debug.WriteLine("Login successful");
            }
            else
            {
                DisplayAlert("Error", "Invalid username or password", "OK");
            }
        }
    }

}
