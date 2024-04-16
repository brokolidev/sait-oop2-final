using LibraryManagementSystem.Config;
using LibraryManagementSystem.Entities;
using LibraryManagementSystem.Persistence.Controllers;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;

namespace LibraryManagementSystem.Pages;

public partial class RentalPage : ContentPage
{
    private List<Category> categories;
    private List<Book> books;
    private Category selectedCategory;
    private List<Book> selectedBooks;


	public RentalPage()
	{
		InitializeComponent();
    }


    // Set Categories
    private void SetCategories()
    {
        // set categories
        CategoryController categoryController = new CategoryController();
        categories = categoryController.GetAllCategories();

        CategoryPicker.ItemsSource = categories;
        CategoryPicker.ItemDisplayBinding = new Binding("Name");
        // bind the event handler
        CategoryPicker.SelectedIndexChanged += OnCategoryIndexChanged;
    }


    // event handler for category picker
    private void OnCategoryIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        selectedCategory = (Category)picker.SelectedItem;
    }

    // search books
    private void Search_Clicked(object sender, EventArgs e)
    {
        var title = BookTitleEntry.Text;

        // if no title is provided, replace with empty string
        // to prevent throwing exeption
        if (title == null)
        {
            title = "";
        }

        BookController bookController = new BookController();
        books = bookController.GetAllBooks(selectedCategory, title);

        // if no books found
        if (books.Count == 0)
        {
            ResultTitleLabel.IsVisible = false;
            BooksListView.IsVisible = false;
            DisplayAlert("No Books Found", "No books found for the given criteria", "OK");
            return;
        }

        ResultTitleLabel.IsVisible = true;
        BooksListView.IsVisible = true;
        // refresh the list view
        BooksListView.ItemsSource = books;
    }


    // event handler for book selection
    private void OnBookSelected(object sender, SelectedItemChangedEventArgs e)
    {
        var book = (Book)e.SelectedItem;
        if (book == null)
        {
            return;
        }

        // if book is already selected, skip it
        if(!selectedBooks.Contains(book))
        {
            selectedBooks.Add(book);

            // show the selected books if there are any
            SelectedBooksGroup.IsVisible = selectedBooks.Count > 0;

            // bind the selected books to the list view
            var selectedBooksCollection = new ObservableCollection<Book>(this.selectedBooks);
            SelectedBooksView.ItemsSource = selectedBooksCollection;
        }
        else
        {
            DisplayAlert("Book Already Selected", "The book is already selected", "OK");
        }
        

        BooksListView.SelectedItem = null;
    }

    // event handler for selected book selection
    private void OnSelectedBookSelected(object sender, SelectedItemChangedEventArgs e)
    {
        var book = (Book)e.SelectedItem;
        if (book == null)
        {
            return;
        }

        // remove the selected book
        selectedBooks.Remove(book);

        // show the selected books if there are any
        SelectedBooksGroup.IsVisible = selectedBooks.Count > 0;

        // bind the selected books to the list view
        var selectedBooksCollection = new ObservableCollection<Book>(this.selectedBooks);
        SelectedBooksView.ItemsSource = selectedBooksCollection;

        SelectedBooksView.SelectedItem = null;
    }

    // rent books
    private void RentButton_Clicked(object sender, EventArgs e)
    {
        if(selectedBooks.Count == 0)
        {
            DisplayAlert("No Books Selected", "Please select books to rent", "OK");
            return;
        }

        RentalController rentalController = new RentalController();
        foreach (var book in selectedBooks)
        {
            var rental = new Rental();
            rental.BookRented = book;
            rental.RentedBy = SystemEnv.LoggedInUser;
            rental.DateRented = DateOnly.FromDateTime(DateTime.Now);
            rental.DateUpdated = DateOnly.FromDateTime(DateTime.Now);
            rental.DateExpires = SystemEnv.CalculateExpireDate();

            rentalController.CreateRental(rental);
        }

        DisplayAlert("Books Rented", "Books rented successfully", "OK");
        selectedBooks.Clear();
        SelectedBooksGroup.IsVisible = false;
        SelectedBooksView.ItemsSource = null;
    }



    // basic settings for this page
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

        // set categories
        SetCategories();
        BooksListView.IsVisible = false;
        BooksListView.ItemSelected += OnBookSelected;
        SelectedBooksGroup.IsVisible = false;
        selectedBooks = new List<Book>();
        SelectedBooksView.ItemSelected += OnSelectedBookSelected;
        
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

    private void RentalHistoryButton_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(RentalHistory));
    }
}