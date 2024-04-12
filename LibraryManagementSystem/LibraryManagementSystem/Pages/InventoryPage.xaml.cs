using LibraryManagementSystem.Config;
using LibraryManagementSystem.Entities;
using System.Diagnostics;

namespace LibraryManagementSystem.Pages;

public partial class InventoryPage : ContentPage
{
    public InventoryPage()
	{
		InitializeComponent();

        List<Book> books = new List<Book>
        {
            new Book {ISBN = "34234232", Title = "Happy Ending Story", Author = "Chai"},
            new Book {ISBN = "34234232", Title = "Happy Ending Story", Author = "Chai"},
            new Book {ISBN = "34234232", Title = "Happy Ending Story", Author = "Chai"},
            new Book {ISBN = "34234232", Title = "Happy Ending Story", Author = "Chai"},
            new Book {ISBN = "34234232", Title = "Happy Ending Story", Author = "Chai"}

        };

        BooksListView.ItemsSource = books;
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
    }

    // Navigation Buttons
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


    // Add Buttons routing
    private void AddInvenButton_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(AddInventoryPage));
    }
}