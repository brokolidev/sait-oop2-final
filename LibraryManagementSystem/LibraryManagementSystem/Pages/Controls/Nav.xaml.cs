using LibraryManagementSystem.Config;
using LibraryManagementSystem.Entities;

namespace LibraryManagementSystem.Pages.Controls;

public partial class Nav : ContentView
{
	public Nav()
	{
		InitializeComponent();

        // set buttons by user types
        RentalButton.IsVisible =
            SystemEnv.LoggedInUser is Student ||
            SystemEnv.LoggedInUser is Instructor;

        RentalHistoryButton.IsVisible = SystemEnv.IsAuthorized;

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

    private void InventoryButton_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(InventoryPage));
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

    private void RentalHistory_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(RentalList));
    }
}