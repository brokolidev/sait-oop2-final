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

    private void HomeButton_Clicked(object sender, EventArgs e)
    {
        Shell.Current.Navigation.PopToRootAsync();
    }
}