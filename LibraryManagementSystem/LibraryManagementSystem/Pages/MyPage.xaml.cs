using LibraryManagementSystem.Config;
using LibraryManagementSystem.Persistence.Controllers;

namespace LibraryManagementSystem.Pages;

public partial class MyPage : ContentPage
{
	public MyPage()
	{
		InitializeComponent();
		SetUserInfo();
	}

	private void SetUserInfo()
	{
		UserTypeLabel.Text = SystemEnv.LoggedInUser.UserType.ToString();
        firstNameEntry.Text = SystemEnv.LoggedInUser.FirstName;
        lastNameEntry.Text = SystemEnv.LoggedInUser.LastName;
        emailEntry.Text = SystemEnv.LoggedInUser.Email;
        phoneNumberEntry.Text = SystemEnv.LoggedInUser.PhoneNumber;
        isBlockedCheckBox.IsChecked = (bool)SystemEnv.LoggedInUser.IsBlocked;
    }

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
        SystemEnv.LoggedInUser.FirstName = firstNameEntry.Text;
        SystemEnv.LoggedInUser.LastName = lastNameEntry.Text;
        SystemEnv.LoggedInUser.Email = emailEntry.Text;
        SystemEnv.LoggedInUser.PhoneNumber = phoneNumberEntry.Text;
        SystemEnv.LoggedInUser.IsBlocked = isBlockedCheckBox.IsChecked;

        // @TODO: validate password
        if (!string.IsNullOrEmpty(passwordEntry.Text))
        {
            SystemEnv.LoggedInUser.Password = passwordEntry.Text;
        }

        UserController userController = new UserController();
        userController.UpdateUser(SystemEnv.LoggedInUser);

        passwordEntry.Text = string.Empty;

        // display success message
        DisplayAlert("Success", "User information updated successfully", "OK");
    }
}