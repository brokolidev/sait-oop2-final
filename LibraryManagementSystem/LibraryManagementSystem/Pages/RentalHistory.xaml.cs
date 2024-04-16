using LibraryManagementSystem.Config;
using LibraryManagementSystem.Entities;
using LibraryManagementSystem.Persistence.Controllers;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;


namespace LibraryManagementSystem.Pages;

public partial class RentalHistory : ContentPage
{
	public RentalHistory()
	{
		InitializeComponent();
	}

    // event handler for add button
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

    private void RentalButton_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(RentalPage));
    }

    private void RentalHistoryButton_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(RentalHistory));
    }
}