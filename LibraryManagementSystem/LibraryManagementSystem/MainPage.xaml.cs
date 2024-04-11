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
            if(TryLogin(username, password))
            {

            }
            else
            {
                DisplayAlert("Error", "Invalid username or password", "OK");
            }
        }


        // this will need to be replaced with a database check
        private bool TryLogin(string username, string password)
        {

            // create administator instance
            Administrator admin = new Administrator(1, "Ted", "Choi", "ted@gmail.com", "123-1234-1111");
            Librarian librarian = new Librarian(2, "Dan", "Choi", "dan@gmail.com", "123-1234-2222");
            Instructor instructor = new Instructor(3, "Bill", "Choi", "bill@gmail.com", "123-1234-3333");
            Student student = new Student(4, "Mac", "Choi", "mac@gmail.com", "123-1234-4444");

            if (username == "admin" && password == "pass")
            {
                LoggedIn("Ted", "Choi", User.UserTypes.Administrator);

                Shell.Current.GoToAsync(nameof(Welcome));
            }
            else if (username == "student" && password == "pass")
            {
                LoggedIn("Dan", "Choi", User.UserTypes.Administrator);

                Shell.Current.GoToAsync(nameof(Welcome));
            }
            else if (username == "librarian" && password == "pass")
            {
                LoggedIn("Bill", "Choi", User.UserTypes.Administrator);

                Shell.Current.GoToAsync(nameof(Welcome));
            }
            else if (username == "instructor" && password == "pass")
            {
                LoggedIn("Mac", "Choi", User.UserTypes.Administrator);

                Shell.Current.GoToAsync(nameof(Welcome));
            }

            return false;
        }

        private void LoggedIn(string userFirstName, string UserLastName, Enum userType)
        {
            SystemEnv.IsAuthorized = true;

            // set the env variables
            SystemEnv.IsAuthorized = true;
            SystemEnv.GetLogedInUserFirstName = userFirstName;
            SystemEnv.GetLogedInUserLastName = UserLastName;
            SystemEnv.GetLogedInUserType = userType;
        }
    }
}