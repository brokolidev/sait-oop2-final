namespace LibraryManagementSystem.Pages;

public partial class CustomerPage : ContentPage
{
	public CustomerPage()
	{
		InitializeComponent();
	}

    private void HomeButton_Clicked(object sender, EventArgs e)
    {
        Shell.Current.Navigation.PopToRootAsync();
    }
}