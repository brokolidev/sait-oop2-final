using LibraryManagementSystem.Config;
using LibraryManagementSystem.Entities;
using LibraryManagementSystem.Persistence.Controllers;
using System.Diagnostics;

namespace LibraryManagementSystem.Pages;

public partial class RentalPage : ContentPage
{
    private List<Category> categories;
    private List<Book> books;
    private Category selectedCategory;


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
        // refresh the list view
        BooksListView.ItemsSource = books;
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

}