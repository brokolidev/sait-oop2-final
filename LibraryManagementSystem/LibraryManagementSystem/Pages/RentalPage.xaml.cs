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
    private Category? selectedCategory;
    private List<Book> selectedBooks;

    //Controllers needed for this screen
    private readonly BookController bookController;
    private readonly CategoryController categoryController;
    private readonly RentalController rentalController;


	public RentalPage()
	{
		InitializeComponent();

        //create new instances of the controllers needed
        bookController = new();
        categoryController = new();
        rentalController = new();

        //default the properties
        categories = [];
        books = [];
        selectedBooks = [];
    }

    // Set Categories
    private void SetCategories()
    {
        // set categories
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
        List<String> booksRented = [];

        if(selectedBooks.Count == 0)
        {
            DisplayAlert("No Books Selected", "Please select books to rent", "OK");
            return;
        }

        foreach (Book book in selectedBooks)
        {

            if (book.Total == 0)
            {
                //display a message to the user stating that this book is unavailable.
                string title = $"{book.Title} Unavailable";
                string message = $"{book.Title} is not available to be rented at this moment. " +
                    $"Check with a librarian to see when this book will be available.";
                DisplayAlert(title, message, "OK");

                //skip this book and proceed to the next
                continue;
            }

            //create the rental
            Rental rental = new();
            rental.BookRented = book;
            rental.RentedBy = SystemEnv.LoggedInUser;
            rental.DateRented = DateOnly.FromDateTime(DateTime.Now);
            rental.DateUpdated = DateOnly.FromDateTime(DateTime.Now);
            rental.DateExpires = SystemEnv.CalculateExpireDate();

            //update the book to, to ensure that it is showing the correct numbers
            book.Total--;
            book.CheckedOut = book.CheckedOut == null ? 1 : book.CheckedOut + 1;

            //send it off to the controllers to update the database
            bookController.UpdateBook(book);
            rentalController.CreateRental(rental);

            //add the name of the book to the list
            booksRented.Add(book.Title);
        }

        //only display the success message if at least one book was successfully rented
        if (booksRented.Count > 0)
        {
            string message = "The following books were successfully rented:";

            booksRented.ForEach(book =>
            {
                message += $"\n{book}";
            });

            DisplayAlert("Books Rented", message, "OK");
        }

        selectedBooks.Clear();
        SelectedBooksGroup.IsVisible = false;
        SelectedBooksView.ItemsSource = null;
    }



    // basic settings for this page
    protected override void OnAppearing()
    {
        base.OnAppearing();

        // set categories
        SetCategories();
        BooksListView.IsVisible = false;
        BooksListView.ItemSelected += OnBookSelected;
        SelectedBooksGroup.IsVisible = false;
        selectedBooks = new List<Book>();
        SelectedBooksView.ItemSelected += OnSelectedBookSelected;


        //bring in all of the books in the system
        //pass new instances of each object. they are not needed for the method to run.
        Search_Clicked(new(), new());
    }
}