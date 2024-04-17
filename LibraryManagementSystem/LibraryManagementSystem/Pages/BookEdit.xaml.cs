using LibraryManagementSystem.Config;
using LibraryManagementSystem.Entities;
using LibraryManagementSystem.Persistence.Controllers;
using System.Diagnostics;

namespace LibraryManagementSystem.Pages;

[QueryProperty(nameof(BookISBN), "ISBN")]
public partial class BookEdit : ContentPage
{
    private Book book;
    private List<Category> categories;
    private Category selectedCategory;

    private void SetCategories()
    {
        // set categories
        CategoryController categoryController = new CategoryController();
        categories = categoryController.GetAllCategories();

        categoryPicker.ItemsSource = categories;
        categoryPicker.ItemDisplayBinding = new Binding("Name");
        categoryPicker.SelectedIndex = 0;

        // bind the event handler
        categoryPicker.SelectedIndexChanged += OnCategoryIndexChanged;
    }

    // event handler for category picker
    private void OnCategoryIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        selectedCategory = (Category)picker.SelectedItem;
    }


    public BookEdit()
	{
		InitializeComponent();

        SetCategories();
	}

    // set parameter for selected book
    public string BookISBN
    {
        set
        {
            BookController bookController = new BookController();
            book = bookController.GetBook(value);
            SetBookDetails();
        }
    }

    // set book details
    private void SetBookDetails()
    {
        ISBNLabel.Text = book.ISBN;
        titleEntry.Text = book.Title;
        authorEntry.Text = book.Author;
        publisherEntry.Text = book.Publisher;
        publishDateEntry.Text = book.DatePublished.ToString("yyyy-MM-dd");

        categoryPicker.SelectedItem = categories.Find(c => c.CategoryId == book.CategoryId);
    }


    // handle updating book button
    private void UpdateButton_Clicked(object sender, EventArgs e)
    {

        BookController bookController = new BookController();
        
        book.Title = titleEntry.Text;
        book.Author = authorEntry.Text;
        book.Publisher = publisherEntry.Text;
        book.DatePublished = DateOnly.Parse(publishDateEntry.Text);

        // set category
        book.Category = selectedCategory;

        // update date updated
        book.DateUpdated = DateOnly.FromDateTime(DateTime.Now);

        bookController.UpdateBook(book);

        // go back to inventory page after updating book
        Shell.Current.GoToAsync(nameof(InventoryPage));
    }

    // go back to inventory page
    private void CancelButton_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(InventoryPage));
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