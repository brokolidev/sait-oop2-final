using LibraryManagementSystem.Config;
using LibraryManagementSystem.Entities;
using LibraryManagementSystem.Persistence.Controllers;
using System.Diagnostics;

namespace LibraryManagementSystem.Pages;

public partial class CustomerPage : ContentPage
{

    //List<User> users;
    //UserController userController;

	public CustomerPage()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();

        // set buttons by user types
        RentalButton.IsVisible =
            SystemEnv.LoggedInUser is Student ||
            SystemEnv.LoggedInUser is Instructor;

        CustomerButton.IsVisible =
            SystemEnv.LoggedInUser is Librarian ||
            SystemEnv.LoggedInUser is Administrator;

        InventoryButton.IsVisible =
            SystemEnv.LoggedInUser is Librarian ||
            SystemEnv.LoggedInUser is Administrator;

        SystemButton.IsVisible =
            SystemEnv.LoggedInUser is Administrator;

        // @TODO: Get all users from the database
        //userController = new UserController();
        //users = userController.GetAllUsers();
    }

    // Main navigation buttons
    private void InventoryButton_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(InventoryPage));
    }

    private void HomeButton_Clicked(object sender, EventArgs e)
    {
        Shell.Current.Navigation.PopToRootAsync();
    }

    private void CustomerButton_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(CustomerPage));
    }

    private void SystemButton_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(SystemPage));
    }


    // Customer manager buttons
    private void AddCustButton_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(AddCustomerPage));
    }

}