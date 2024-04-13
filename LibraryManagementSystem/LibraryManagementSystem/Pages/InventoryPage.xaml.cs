using LibraryManagementSystem.Config;
using LibraryManagementSystem.Entities;
using LibraryManagementSystem.Persistence.Controllers;
using System.Diagnostics;

namespace LibraryManagementSystem.Pages;

public partial class InventoryPage : ContentPage
{
    List<Book>? books;
    BookController bookController;
    List<Category> categories;
    Category selectedCategory;

    public InventoryPage()
	{
		InitializeComponent();

        bookController = new BookController();
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

    // Set Books List
    private void SetBooksList()
    {
        books = bookController.GetAllBooks();
        BooksListView.ItemsSource = books;
        BooksListView.ItemSelected += OnBookSelected;
    }

    // Event handler for book selected
    private void OnBookSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem == null)
            return;

        Book selectedBook = (Book)e.SelectedItem;

        Shell.Current.GoToAsync($"{nameof(BookDetail)}" +
            $"?ISBN={selectedBook.ISBN}");        
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


        SetBooksList();
        SetCategories();
    }

    // event handler for category picker
    private void OnCategoryIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        selectedCategory = (Category)picker.SelectedItem;
        
        // @TODO: Filter books by category
    }


    // Navigation Buttons
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


    // Add Buttons routing
    private void AddInvenButton_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(AddInventoryPage));
    }
}