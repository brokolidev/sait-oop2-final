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
        // get rentals only for students and instructors when logged in as student or instructor
        if(SystemEnv.LoggedInUser is Student || SystemEnv.LoggedInUser is Instructor)
        {
            rentals = rentalController.GetAllRentals(SystemEnv.LoggedInUser);
        }
        else // get all rentals for librarian and administrator
        {
            rentals = rentalController.GetAllRentals();
        }
        var rentalCollection = new ObservableCollection<Rental>(rentals);
        RentalListView.ItemsSource = rentalCollection;
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

        // update book total count
        Book rentedBook = selectedRental.BookRented;
        rentedBook.Total++;
        BookController bookController = new BookController();
        bookController.UpdateBook(rentedBook);

        // display success message
        await DisplayAlert("Success", "Book returned successfully", "OK");

        // refresh list
        SetRentalList();
    }
}