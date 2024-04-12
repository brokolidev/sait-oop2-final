using LibraryManagementSystem.Config;
using LibraryManagementSystem.Entities;
using System.Diagnostics;

namespace LibraryManagementSystem.Pages;

public partial class AddInventoryPage : ContentPage
{
    List<Category> categories;

	public AddInventoryPage()
	{
		InitializeComponent();
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

        // set categories
        // @TODO: get categories from database
        categories = new List<Category>
        {
            new Category {CategoryId = 1, Name = "Fiction", DateRegistered = new DateOnly(2021, 10, 1)},
            new Category {CategoryId = 2, Name = "Non-Fiction", DateRegistered = new DateOnly(2021, 10, 1)},
            new Category {CategoryId = 3, Name = "Mystery", DateRegistered = new DateOnly(2021, 10, 1)},
            new Category {CategoryId = 4, Name = "Science Finction", DateRegistered = new DateOnly(2021, 10, 1)},
            new Category {CategoryId = 5, Name = "Fantasy", DateRegistered = new DateOnly(2021, 10, 1)}
        };

        categoryPicker.ItemsSource = categories;
        categoryPicker.ItemDisplayBinding = new Binding("Name");
        // bind the event handler
        categoryPicker.SelectedIndexChanged += OnCategoryIndexChanged;


    }

    // event handler for category picker
    private void OnCategoryIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        int selectedIndex = picker.SelectedIndex;

        Category selectedCategory = categories[selectedIndex];
        Debug.WriteLine("Selected Category: " + selectedCategory.Name);
    }

    private void SaveButton_Clicked(object sender, EventArgs e)
    {
        // @TODO: save new book to database
        // after successfully saved the book, navigate back to InventoryPage
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