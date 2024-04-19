using LibraryManagementSystem.Entities;
using LibraryManagementSystem.Persistence.Controllers;
using System.Diagnostics;

namespace LibraryManagementSystem.Pages;

[QueryProperty(nameof(UserId), "Id")]
public partial class UserDetail : ContentPage
{
    private User user;

	public UserDetail()
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

    // set book details
    private void SetUserDetails()
    {
        if (user != null)
        {
            // set user details
            UserType.Detail = user.UserType.ToString();
            UserIdLabel.Detail = user.UserId.ToString();
            FirstName.Detail = user.FirstName;
            LastName.Detail = user.LastName;
            Email.Detail = user.Email;
            PhoneNumber.Detail = user.PhoneNumber;
            DateRegistered.Detail = user.DateRegistered.ToString("yyyy-MM-dd");
            DateUpdated.Detail = user.DateUpdated?.ToString("yyyy-MM-dd");

            // set blocked status
            string blockedStatus = "Active";

            if(user.IsBlocked != null && user.IsBlocked == true)
            {
                blockedStatus = "Blocked";
            }

            IsBlocked.Detail = blockedStatus;
        }
        
    }

    // go back to user list
    private void CancelButton_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(CustomerPage));
    }

    // delete user
    private async void DeleteButton_Clicked(object sender, EventArgs e)
    {
        // confirm delete
        bool answer = await DisplayAlert("Question?", "Really wanna delete?", "Yes", "No");

        if (answer)
        {
            UserController userController = new UserController();
            userController.DeleteUser(user.UserId);

            Shell.Current.GoToAsync(nameof(CustomerPage));
        }
    }

    // go to edit page
    private void EditButton_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync($"{nameof(UserEdit)}?Id={user.UserId}");
    }
}