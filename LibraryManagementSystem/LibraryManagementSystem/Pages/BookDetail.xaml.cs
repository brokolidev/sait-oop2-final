using LibraryManagementSystem.Config;
using LibraryManagementSystem.Entities;
using LibraryManagementSystem.Persistence.Controllers;
using System.Diagnostics;

namespace LibraryManagementSystem.Pages;

[QueryProperty(nameof(BookISBN), "ISBN")]
public partial class BookDetail : ContentPage
{
    private Book book;
    private readonly BookController bookController;

	public BookDetail()
	{
		InitializeComponent();

        book = new();
        bookController = new();

	}

    // set parameter for selected book
    public string BookISBN
    {
        set
        {
            try
            {
                book = bookController.GetBook(value);
                SetBookDetails();
            }
            catch (Exception ex)
            {
                //return the user to the inventory page
                DisplayAlert("Book Not found", $"Book with ISBN {value} was not found in the database.", "OK");
                CancelButton_Clicked(new(), new());
            }
        }
    }

    // set book details
    private void SetBookDetails()
    {
        Title.Detail = book.Title;
        ISBN.Detail = book.ISBN;
        Author.Detail = book.Author;
        Publisher.Detail = book.Publisher;
        DatePublished.Detail = book.DatePublished.ToString("yyyy-MM-dd");
        DateRegistered.Detail = book.DateRegistered.ToString("yyyy-MM-dd");
        DateUpdated.Detail = book.DateUpdated.ToString();
        TotalAvailable.Detail = book.Total.ToString();
        TotalCheckedOut.Detail = book.CheckedOut.ToString() == "" ? "Never been checked out" : book.CheckedOut.ToString();
        TotalNumber.Detail = (book.Total + (book.CheckedOut == null ? 0 : book.CheckedOut)).ToString();
        CheckedOut.Detail = (book.Total != 0) ? "Available": "Unavailable";
        Category.Detail = book.Category.Name;
    }

    // go back to inventory page
    private void CancelButton_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(InventoryPage));
    }

    // delete book
    private async void DeleteButton_Clicked(object sender, EventArgs e)
    {
        // confirm delete
        bool answer = await DisplayAlert("Question?", "Really wanna delete?", "Yes", "No");

        if (answer)
        {
            BookController bookController = new BookController();
            bookController.DeleteBook(book.ISBN);
            Shell.Current.GoToAsync(nameof(InventoryPage));
        }
    }

    // go to edit page
    private void EditButton_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync($"{nameof(BookEdit)}?ISBN={book.ISBN}");
    }

    // when the page is shown
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

}