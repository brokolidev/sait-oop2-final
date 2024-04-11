namespace LibraryManagementSystem.Pages
{
    public partial class MainPage : ContentPage
    {
    	public MainPage()
    	{
    		InitializeComponent();
    	}
    
        private void InventoryButton_Clicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync(nameof(InventoryPage));
        }

        private void LoginButton_Clicked(object sender, EventArgs e)
        {
            //TODO: Implement the login functionality
        }
    }
}