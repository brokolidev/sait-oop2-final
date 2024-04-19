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

        MyPageButton.IsVisible = SystemEnv.IsAuthorized;
    }

    // Home
    private void HomeButton_Clicked(object sender, EventArgs e)
    {
        Shell.Current.Navigation.PopToRootAsync();
    }
    
    // Rental
    private void RentalButton_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(RentalPage));
    }

    // Rental History
    private void RentalHistory_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(RentalList));
    }

    // Inventory(Books)
    private void InventoryButton_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(InventoryPage));
    }

    // Customer
    private void CustomerButton_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(CustomerPage));
    }

    // System
    private void SystemButton_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(SystemPage));
    }

    // My Page
    private void MyPageButton_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(MyPage));
    }
}