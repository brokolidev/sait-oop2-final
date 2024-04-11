using LibraryManagementSystem.Config;
using LibraryManagementSystem.Entities;

namespace LibraryManagementSystem.Pages
{
    public partial class MainPage : ContentPage
    {
    	public MainPage()
    	{
            InitializeComponent();
    	}

        protected override void OnAppearing()
        {
            // check if the user is already logged in
            if (SystemEnv.IsAuthorized)
            {
                Shell.Current.GoToAsync(nameof(Welcome));
            } 
            
            base.OnAppearing();
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
                SystemEnv.IsAuthorized = true;

                // set the env variables
                SystemEnv.IsAuthorized = true;
                SystemEnv.GetLogedInUserFirstName = "Admin";
                SystemEnv.GetLogedInUserLastName= "Admin";
                SystemEnv.GetLogedInUserType = User.UserTypes.Administrator;


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