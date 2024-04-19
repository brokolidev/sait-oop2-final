using LibraryManagementSystem.Config;
using LibraryManagementSystem.Entities;
using LibraryManagementSystem.Persistence.Controllers;
using System.Collections.ObjectModel;
using System.Diagnostics;

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
        var rentalCollection = new ObservableCollection<Rental>(rentals);
        RentalListView.ItemsSource = rentalCollection;
        //RentalListView.ItemSelected += OnCustomerSelected;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        SetRentalList();
    }

    // Return Rental
    private async void ReturnButton_Clicked(object sender, EventArgs e)
    {
        // display alert to confirm deletion
        bool answer = await DisplayAlert("Delete", "Are you sure you want to return this book?", "Yes", "No");

        if (!answer)
        {
            return;
        }

        var button = sender as Button;
        int rentalId = (int)button.CommandParameter;

        // return rental
        Rental selectedRental = rentalController.GetRental(rentalId);

        selectedRental.DateReturned = DateOnly.FromDateTime(DateTime.Now);
        rentalController.UpdateRental(selectedRental);

        // display success message
        await DisplayAlert("Success", "Book returned successfully", "OK");

        // refresh list
        SetRentalList();
    }
}