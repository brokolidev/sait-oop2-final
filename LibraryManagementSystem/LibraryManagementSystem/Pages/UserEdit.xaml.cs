using LibraryManagementSystem.Config;
using LibraryManagementSystem.Entities;
using LibraryManagementSystem.Persistence.Controllers;

namespace LibraryManagementSystem.Pages;

[QueryProperty(nameof(UserId), "Id")]
public partial class UserEdit : ContentPage
{
	private User user;
    User.UserTypes selectedUserType;

    public UserEdit()
	{
		InitializeComponent();
	}

    // set parameter for selected book
    public int UserId
    {
        set
        {
            UserController userController = new UserController();
            user = userController.GetUser(value);
            SetUserDetails();
        }
    }

    // Set User Details
    private void SetUserDetails()
    {
        firstNameEntry.Text = user.FirstName;
        lastNameEntry.Text = user.LastName;
        emailEntry.Text = user.Email;
        phoneNumberEntry.Text = user.PhoneNumber;
        
        isBlockedCheckBox.IsChecked = (bool)user.IsBlocked;
    }

    // event handler for update button
    private void UpdateButton_Clicked(object sender, EventArgs e)
    {
        // validate other text fields
        if (string.IsNullOrEmpty(firstNameEntry.Text) || string.IsNullOrEmpty(lastNameEntry.Text) || string.IsNullOrEmpty(emailEntry.Text) || string.IsNullOrEmpty(phoneNumberEntry.Text))
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
        if (!SystemEnv.IsValidEmail(emailEntry.Text))
        {
            DisplayAlert("Error", "Please enter a valid email address", "OK");
            return;
        }

        // update user
        user.FirstName = firstNameEntry.Text;
        user.LastName = lastNameEntry.Text;
        user.Email = emailEntry.Text;
        user.PhoneNumber = phoneNumberEntry.Text;
        user.UserType = selectedUserType;
        user.IsBlocked = isBlockedCheckBox.IsChecked;
        
        // @TODO: validate email

        // @TODO: validate password
        if(!string.IsNullOrEmpty(passwordEntry.Text))
        {
            user.Password = passwordEntry.Text;
        }

        UserController userController = new UserController();
        userController.UpdateUser(user);

        // navigate back to user page
        Shell.Current.GoToAsync(nameof(CustomerPage));
    }

    // event handler for cancel button
    private void CancelButton_Clicked(object sender, EventArgs e)
    {
        // navigate back to user page
        Shell.Current.GoToAsync(nameof(CustomerPage));
    }

    // Set User Types
    private void SetUserTypes()
    {
        UserTypePicker.ItemsSource = Enum.GetValues(typeof(User.UserTypes));
        UserTypePicker.SelectedItem = user.UserType;
        UserTypePicker.SelectedIndexChanged += OnUserTypeIndexChanged;
    }

    // Event handler for user type selected
    private void OnUserTypeIndexChanged(object sender, EventArgs e)
    {
        selectedUserType = (User.UserTypes)UserTypePicker.SelectedItem;
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

        // set user type
        SetUserTypes();
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