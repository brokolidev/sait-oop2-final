using LibraryManagementSystem.Config;
using LibraryManagementSystem.Entities;
using LibraryManagementSystem.Persistence.Controllers;

namespace LibraryManagementSystem.Pages
{
    public partial class MainPage : ContentPage
    {
    	public MainPage()
    	{
            InitializeComponent();
        }

        // check if the user is already logged in
        protected override void OnAppearing()
        {
            // check if the user is already logged in
            if (SystemEnv.IsAuthorized)
            {
                Shell.Current.GoToAsync(nameof(Welcome));
            } 
            
            base.OnAppearing();
        }


        // Login
        private void LoginButton_Clicked(object sender, EventArgs e)
        {
            string email = EmailEntry.Text;
            string password = PasswordEntry.Text;

            // null check
            if(string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                DisplayAlert("Error", "Please enter a username and password", "OK");
                return;
            }

            // check if the username and password are correct
            if(TryLogin(email, password))
            {
                // go to welcome page
                Shell.Current.GoToAsync(nameof(Welcome));
            }
            else
            {
                DisplayAlert("Error", "Invalid username or password", "OK");
            }
        }

        // this will need to be replaced with a database check
        private bool TryLogin(string email, string password)
        {

            User? userFound = EntityController.userController.ValidateCredentials(email, password);

            if (userFound == null)
            {
                return false;
            }

            //log the user in
            LoggedIn(userFound);

            return true;
        }

        // set the env variables
        private void LoggedIn(User user)
        {
            SystemEnv.IsAuthorized = true;

            // set the env variables
            SystemEnv.IsAuthorized = true;
            SystemEnv.LoggedInUser = user;
        }
    }
}