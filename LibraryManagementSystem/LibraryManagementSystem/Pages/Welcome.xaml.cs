using LibraryManagementSystem.Config;
using LibraryManagementSystem.Entities;

namespace LibraryManagementSystem.Pages;

public partial class Welcome : ContentPage
{

	public Welcome()
	{
		InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        // set welcome message
        WelcomMessageLabel.Text = $"Welcome " +
            $"{SystemEnv.LoggedInUser.FirstName}," +
            $" You are logged in as {SystemEnv.LoggedInUser.UserType}";

        // set buttons by user types
        RentalButton.IsVisible = 
            SystemEnv.LoggedInUser.UserType == User.UserTypes.Student || 
            SystemEnv.LoggedInUser.UserType == User.UserTypes.Instructor;

        CustomerButton.IsVisible = 
            SystemEnv.LoggedInUser.UserType == User.UserTypes.Librarian|| 
            SystemEnv.LoggedInUser.UserType == User.UserTypes.Administrator;

        InventoryButton.IsVisible =
            SystemEnv.LoggedInUser.UserType == User.UserTypes.Librarian ||
            SystemEnv.LoggedInUser.UserType == User.UserTypes.Administrator;

        SystemButton.IsVisible = 
            SystemEnv.LoggedInUser.UserType == User.UserTypes.Administrator;
    }

    private void InventoryButton_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(InventoryPage));
    }

    private void LogoutButton_Clicked(object sender, EventArgs e)
    {
        SystemEnv.LoggedInUser = null;
        SystemEnv.IsAuthorized = false;
        
        Shell.Current.GoToAsync($"//{nameof(MainPage)}");
    }
}