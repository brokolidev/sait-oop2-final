using LibraryManagementSystem.Config;
using LibraryManagementSystem.Entities;
using LibraryManagementSystem.Persistence.Controllers;
using System.Diagnostics;

namespace LibraryManagementSystem.Pages;

public partial class AddCustomerPage : ContentPage
{
    User.UserTypes selectedUserType;
    User newUser;

	public AddCustomerPage()
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

        SetUserTypes();
    }

    // Set User Types
    private void SetUserTypes()
    {
        UserTypePicker.ItemsSource = Enum.GetValues(typeof(User.UserTypes));
        UserTypePicker.SelectedIndex = 0;

        UserTypePicker.SelectedIndexChanged += OnUserTypeIndexChanged;
    }

    // Event handler for user type selected
    private void OnUserTypeIndexChanged(object sender, EventArgs e)
    {
        selectedUserType = (User.UserTypes)UserTypePicker.SelectedItem;
    }


    // add new customer 
    private void SaveButton_Clicked(object sender, EventArgs e)
    {
        // validate category
        if (selectedUserType == null)
        {
            DisplayAlert("Error", "Please select user type", "OK");
            return;
        }

        // validate other text fields
        if (string.IsNullOrEmpty(firstNameEntry.Text) || string.IsNullOrEmpty(lastNameEntry.Text) || string.IsNullOrEmpty(emailEntry.Text) || string.IsNullOrEmpty(passwordEntry.Text) || string.IsNullOrEmpty(phoneNumberEntry.Text))
        {
            DisplayAlert("Error", "Please fill in all fields", "OK");
            return;
        }

        // validation for phone field
        // allowd formats:
        // (xxx)xxxxxxx
        // (xxx)xxxxxxx
        // (xxx)xxx - xxxx
        // (xxx) xxx - xxxx
        // xxxxxxxxxx
        // xxx - xxx - xxxxx
        if (!System.Text.RegularExpressions.Regex.IsMatch(phoneNumberEntry.Text, @"^\(?([0-9]{3})\)?[-.¡Ü]?([0-9]{3})[-.¡Ü]?([0-9]{4})$"))
        {
            DisplayAlert("Error", "Please enter a valid phone number", "OK");
            return;
        }

        // validation for email address
        if(!SystemEnv.IsValidEmail(emailEntry.Text))
        {
            DisplayAlert("Error", "Please enter a valid email address", "OK");
            return;
        }


        // create a new customer instasnce
        UserController userController = new UserController();

        switch(selectedUserType)
        {
            case User.UserTypes.Student:
                newUser = new Student();
                break;
            case User.UserTypes.Instructor:
                newUser = new Instructor();
                break;
            case User.UserTypes.Librarian:
                newUser = new Librarian();
                break;
            case User.UserTypes.Administrator:
                newUser = new Administrator();
                break;
        }

        if(newUser == null)
        {
            // display error message
            DisplayAlert("Error", "Invalid user type", "OK");
        }
        
        newUser.FirstName = firstNameEntry.Text;
        newUser.LastName = lastNameEntry.Text;
        newUser.Email = emailEntry.Text;
        newUser.Password = passwordEntry.Text;
        newUser.PhoneNumber = phoneNumberEntry.Text;
        newUser.UserType = selectedUserType;
        newUser.DateRegistered = DateOnly.FromDateTime(DateTime.Now);
        newUser.DateUpdated = DateOnly.FromDateTime(DateTime.Now);
        newUser.IsBlocked = false;

        userController.CreateUser(newUser);

        // go back to inventory page after updating book
        Shell.Current.GoToAsync(nameof(CustomerPage));
    }


    // Navigation buttons
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