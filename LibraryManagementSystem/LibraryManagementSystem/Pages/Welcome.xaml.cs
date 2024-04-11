namespace LibraryManagementSystem.Pages;

public partial class Welcome : ContentPage
{
	public Welcome()
	{
		InitializeComponent();
	}

    private void InventoryButton_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(InventoryPage));
    }

}