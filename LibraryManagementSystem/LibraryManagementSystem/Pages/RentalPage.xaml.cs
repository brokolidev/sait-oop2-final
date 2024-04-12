using LibraryManagementSystem.Config;
using LibraryManagementSystem.Entities;
using System.Diagnostics;

namespace LibraryManagementSystem.Pages;

public partial class RentalPage : ContentPage
{
	public RentalPage()
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
    }

    // navigation buttons
    private void HomeButton_Clicked(object sender, EventArgs e)
    {
        Shell.Current.Navigation.PopToRootAsync();
    }

    private void CustomerButton_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(CustomerPage));
    }

    private void InventoryButton_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(InventoryPage));
    }

    private void SystemButton_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(SystemPage));
    }
}