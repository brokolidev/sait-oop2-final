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
            $"{SystemEnv.GetLogedInUserFirstName} {SystemEnv.GetLogedInUserLastName}," +
            $" You are logged in as {SystemEnv.GetLogedInUserType}";
    }

    private void InventoryButton_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(InventoryPage));
    }
}