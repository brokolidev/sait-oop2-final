using LibraryManagementSystem.Config;

namespace LibraryManagementSystem.Pages;

public partial class Welcome : ContentPage
{

	public Welcome()
	{
		InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        // set welcome message
        WelcomMessageLabel.Text = $"Welcome " +
            $"{SystemEnv.LoggedInUser.FirstName}," +
            $" You are logged in as {SystemEnv.LoggedInUser.UserType}";
    }

    private void InventoryButton_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(InventoryPage));
    }

    private void LogoutButton_Clicked(object sender, EventArgs e)
    {
        SystemEnv.LoggedInUser = null;
        SystemEnv.IsAuthorized = false;
        
        Shell.Current.GoToAsync($"//{nameof(MainPage)}");
    }
}