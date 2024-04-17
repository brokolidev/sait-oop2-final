using LibraryManagementSystem.Config;
using LibraryManagementSystem.Entities;
using LibraryManagementSystem.Persistence.Controllers;
using System.Diagnostics;

namespace LibraryManagementSystem.Pages;

public partial class CustomerPage : ContentPage
{

    List<User> users;
    UserController userController;
    User.UserTypes selectedUserType;

    public CustomerPage()
	{
		InitializeComponent();

        userController = new UserController();
	}

    // Set Customers list
    private void SetCustomersList()
    {
        // this could
        users = userController.GetAllUsers();
        CustomerListView.ItemsSource = users;
        CustomerListView.ItemSelected += OnCustomerSelected;
    }

    // Set User Types
    private void SetUserTypes()
    {
        UserTypePicker.ItemsSource = Enum.GetValues(typeof(User.UserTypes));
        UserTypePicker.SelectedIndexChanged += OnUserTypeIndexChanged;
    }

    // Event handler for user type selected
    private void OnUserTypeIndexChanged(object sender, EventArgs e)
    {
        selectedUserType = (User.UserTypes)UserTypePicker.SelectedItem;
    }

    // Event handler for filter button
    private void FilterButton_Clicked(object sender, EventArgs e)
    {
        var firstNameFilterText = firstNameFilterEntry.Text;
        var emailFilterText = emailFilterEntry.Text;
        var phoneFilterText = phoneNumberFilterEntry.Text;

        // refresh the list
        users = userController.GetAllUsers(selectedUserType, firstNameFilterText, emailFilterText, phoneFilterText);
        CustomerListView.ItemsSource = users;
    }

    // Event handler for customer selected
    private void OnCustomerSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem == null)
            return;

        User selectedUser = (User)e.SelectedItem;

        Debug.WriteLine($"{selectedUser.UserId} / {selectedUser.FirstName} / {selectedUser.LastName}");

        Shell.Current.GoToAsync($"{nameof(UserDetail)}" +
                       $"?Id={selectedUser.UserId}");
    }

    // Customer manager buttons
    private void AddCustButton_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(AddCustomerPage));
    }


    protected override void OnAppearing()
    {
        base.OnAppearing();

        // set buttons by user types
        RentalButton.IsVisible =
            SystemEnv.LoggedInUser is Student ||
            SystemEnv.LoggedInUser is Instructor;

        StaffRentalHistoryButton.IsVisible =
            SystemEnv.LoggedInUser is Librarian ||
            SystemEnv.LoggedInUser is Administrator;

        CustomerButton.IsVisible =
            SystemEnv.LoggedInUser is Librarian ||
            SystemEnv.LoggedInUser is Administrator;

        InventoryButton.IsVisible =
            SystemEnv.LoggedInUser is Librarian ||
            SystemEnv.LoggedInUser is Administrator;

        SystemButton.IsVisible =
            SystemEnv.LoggedInUser is Administrator;

        SetCustomersList();
        SetUserTypes();
    }

    // Main navigation buttons
    private void InventoryButton_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(InventoryPage));
    }

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

    private void StaffRentalHistoryButton_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(StaffRentalHistory));
    }
}