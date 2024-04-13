using LibraryManagementSystem.Entities;
using LibraryManagementSystem.Persistence.Controllers;

namespace LibraryManagementSystem.Pages;

[QueryProperty(nameof(BookISBN), "ISBN")]
public partial class BookDetail : ContentPage
{
    private Book book;

	public BookDetail()
	{
		InitializeComponent();

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
        ISBN.Detail = book.ISBN;
        Author.Detail = book.Author;
        Publisher.Detail = book.Publisher;
        DatePublished.Detail = book.DatePublished.ToString("yyyy-MM-dd");
        DateRegistered.Detail = book.DateRegistered.ToString("yyyy-MM-dd");
        DateUpdated.Detail = book.DateUpdated.ToString();
        Total.Detail = book.Total.ToString();
        CheckedOut.Detail = (book.CheckedOut == 0) ? "Available": "Unavailable";

        SetCategory(book.CategoryId);
    }

    // set category
    private void SetCategory(int categoryId)
    {
        CategoryController categoryController = new CategoryController();
        Category category = categoryController.GetCategory(categoryId);
        Category.Detail = category.Name;
    }

    // go back to inventory page
    private void CancelButton_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(InventoryPage));
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