namespace LibraryManagementSystem.Pages;

public partial class InventoryPage : ContentPage
{
	public InventoryPage()
	{
		InitializeComponent();
	}

    private void HomeButton_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(MainPage));
    }
}