using LibraryManagementSystem.Config;
using LibraryManagementSystem.Entities;
using LibraryManagementSystem.Persistence.Controllers;

namespace LibraryManagementSystem.Pages;

public partial class RentalList : ContentPage
{
    List<Rental> rentals;
    RentalController rentalController;

    public RentalList()
	{
		InitializeComponent();

        rentalController = new RentalController();
    }

    // Set Rentals List
    private void SetRentalList()
    {
        rentals = rentalController.GetAllRentals();
        RentalListView.ItemsSource = rentals;
        //RentalListView.ItemSelected += OnCustomerSelected;
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

        SetRentalList();
    }

    // navigation buttons
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

    private void HomeButton_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(Welcome));
    }
}