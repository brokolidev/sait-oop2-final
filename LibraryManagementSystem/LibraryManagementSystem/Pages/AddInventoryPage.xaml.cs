using LibraryManagementSystem.Config;
using LibraryManagementSystem.Entities;
using LibraryManagementSystem.Persistence.Controllers;
using System.Diagnostics;

namespace LibraryManagementSystem.Pages;

public partial class AddInventoryPage : ContentPage
{
    List<Category> categories;
    Category selectedCategory;

	public AddInventoryPage()
	{
		InitializeComponent();
	}

    // set categories for the picker
    private void SetCategories()
    {
        // set categories
        CategoryController categoryController = new CategoryController();
        categories = categoryController.GetAllCategories();

        categoryPicker.ItemsSource = categories;
        categoryPicker.ItemDisplayBinding = new Binding("Name");
        categoryPicker.SelectedIndex = 0;
        selectedCategory = categoryPicker.SelectedItem as Category;

        // bind the event handler
        categoryPicker.SelectedIndexChanged += OnCategoryIndexChanged;
    }

    // when the page is shown
    protected override void OnAppearing()
    {
        base.OnAppearing();

        SetCategories();
    }

    // event handler for category picker
    private void OnCategoryIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        selectedCategory = picker.SelectedItem as Category;
    }

    // add book to inventory
    private void SaveButton_Clicked(object sender, EventArgs e)
    {
        // validate category
        if(selectedCategory == null)
        {
            DisplayAlert("Error", "Please select a category", "OK");
            return;
        }

        // validate other text fields
        if (string.IsNullOrEmpty(isbnEntry.Text) || string.IsNullOrEmpty(titleEntry.Text) || string.IsNullOrEmpty(authorEntry.Text) || string.IsNullOrEmpty(publisherEntry.Text) || string.IsNullOrEmpty(publishDateEntry.Text))
        {
            DisplayAlert("Error", "Please fill in all fields", "OK");
            return;
        }

        // validate published date input
        DateOnly publishedDate;
        bool publishedDateParsed = DateOnly.TryParse(publishDateEntry.Text, out publishedDate);

        if (!publishedDateParsed)
        {
            DisplayAlert("Error", "Please enter a valid date", "OK");
            return;
        }

        // create book
        BookController bookController = new BookController();

        Book newBook = new Book();
        newBook.ISBN = isbnEntry.Text;
        newBook.Title = titleEntry.Text;
        newBook.Author = authorEntry.Text;
        newBook.Publisher = publisherEntry.Text;
        newBook.DatePublished = publishedDate;
        newBook.Total = 0;
        
        // set category for the new book 
        newBook.Category = selectedCategory;

        // update dates
        newBook.DateRegistered = DateOnly.FromDateTime(DateTime.Now);
        newBook.DateUpdated = DateOnly.FromDateTime(DateTime.Now);
        
        bookController.CreateBook(newBook);

        // go back to inventory page after updating book
        Shell.Current.GoToAsync(nameof(InventoryPage));
    }

    // Go back to listing page
    private void CancelButton_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(InventoryPage));
    }
}