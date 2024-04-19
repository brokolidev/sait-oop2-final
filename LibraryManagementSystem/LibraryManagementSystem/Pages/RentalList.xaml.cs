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

        SetRentalList();
    }
}