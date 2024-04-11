using LibraryManagementSystem.Config;
using LibraryManagementSystem.Entities;
using System.Diagnostics;

namespace LibraryManagementSystem.Pages;

public partial class AddInventoryPage : ContentPage
{
	public AddInventoryPage()
	{
		InitializeComponent();
	}
    protected override void OnAppearing()
    {
        base.OnAppearing();

        // set buttons by user types
        RentalButton.IsVisible =
            SystemEnv.LoggedInUser.UserType == User.UserTypes.Student ||
            SystemEnv.LoggedInUser.UserType == User.UserTypes.Instructor;

        CustomerButton.IsVisible =
            SystemEnv.LoggedInUser.UserType == User.UserTypes.Librarian ||
            SystemEnv.LoggedInUser.UserType == User.UserTypes.Administrator;

        InventoryButton.IsVisible =
            SystemEnv.LoggedInUser.UserType == User.UserTypes.Librarian ||
            SystemEnv.LoggedInUser.UserType == User.UserTypes.Administrator;

        SystemButton.IsVisible =
            SystemEnv.LoggedInUser.UserType == User.UserTypes.Administrator;
    }

    private void HomeButton_Clicked(object sender, EventArgs e)
    {
        Shell.Current.Navigation.PopToRootAsync();
    }
}