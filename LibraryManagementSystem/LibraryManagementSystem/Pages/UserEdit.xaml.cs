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
        //// update user
        //user.Name = nameEntry.Text;
        //user.Username = usernameEntry.Text;
        //user.Password = passwordEntry.Text;
        //user.UserType = selectedUserType;

        //UserController userController = new UserController();
        //userController.UpdateUser(user);

        //// navigate back to user page
        //Shell.Current.GoToAsync(nameof(UserPage));
    }

    // event handler for cancel button
    private void CancelButton_Clicked(object sender, EventArgs e)
    {
        // navigate back to user page
        Shell.Current.GoToAsync(nameof(CustomerPage));
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