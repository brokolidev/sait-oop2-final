using LibraryManagementSystem.Config;

namespace LibraryManagementSystem.Pages
{
    public partial class MainPage : ContentPage
    {
    	public MainPage()
    	{
    		InitializeComponent();
    	}
    
        private void InventoryButton_Clicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync(nameof(InventoryPage));
        }

        // Login
        private void LoginButton_Clicked(object sender, EventArgs e)
        {
            string username = UsernameEntry.Text;
            string password = PasswordEntry.Text;

            // null check
            if(string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                DisplayAlert("Error", "Please enter a username and password", "OK");
                return;
            }

            // check if the username and password are correct
            // this will need to be replaced with a database check
            if(username == "admin" && password == "admin")
            {
                SystemEnv.GetIsAuthorized = true;
                Shell.Current.GoToAsync(nameof(Welcome));
                System.Diagnostics.Debug.WriteLine("Login successful");
            }
            else
            {
                DisplayAlert("Error", "Invalid username or password", "OK");
            }
        }
    }
}