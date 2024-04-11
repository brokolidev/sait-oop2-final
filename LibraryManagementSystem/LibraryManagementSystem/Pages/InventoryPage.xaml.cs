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

    private void HomeButton_Clicked(object sender, EventArgs e)
    {
        Shell.Current.Navigation.PopToRootAsync();
    }
}