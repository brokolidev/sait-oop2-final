using LibraryManagementSystem.Config;
using LibraryManagementSystem.Entities;
using System.Diagnostics;

namespace LibraryManagementSystem.Pages;

public partial class InventoryPage : ContentPage
{   
    //public List<Book> Books { get; set; }

    //public void SampleData()
    //{
    //    Books = new List<Book>
    //    {
    //        new Book
    //        {
    //            ISBN = "3141341341",
    //            Title = "Understanding Artificial Intelligence",
    //            Author = "Alex J. Smith",
    //            DatePublished = new DateTime(2020, 1, 1),
    //            DateRegistered = DateTime.Now
    //        },
    //        new Book
    //        {
    //            ISBN = "314134134134",
    //            Title = "Advanced .NET Programming",
    //            Author = "Samantha Rose",
    //            DatePublished = new DateTime(2021, 2, 15),
    //            DateRegistered = DateTime.Now
    //        },
    //        new Book
    //        {
    //            ISBN = "6767374476",
    //            Title = "Database Systems: The Complete Book",
    //            Author = "Hector Garcia-Molina",
    //            DatePublished = new DateTime(2019, 8, 23),
    //            DateRegistered = DateTime.Now
    //        },
    //        new Book
    //        {
    //            ISBN = "8476456353",
    //            Title = "Principles of Compiler Design",
    //            Author = "Alfred V. Aho",
    //            DatePublished = new DateTime(2018, 4, 12),
    //            DateRegistered = DateTime.Now
    //        },
    //        new Book
    //        {
    //            ISBN = "446464465",
    //            Title = "The Algorithm Design Manual",
    //            Author = "Steven S Skiena",
    //            DatePublished = new DateTime(2022, 3, 1),
    //            DateRegistered = DateTime.Now
    //        }
    //    };
    //}

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