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
    }
}