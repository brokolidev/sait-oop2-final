using LibraryManagementSystem.Pages;

namespace LibraryManagementSystem
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            Routing.RegisterRoute(nameof(InventoryPage), typeof(InventoryPage));
            Routing.RegisterRoute(nameof(Welcome), typeof(Welcome));
            Routing.RegisterRoute(nameof(AddInventoryPage), typeof(AddInventoryPage));
            Routing.RegisterRoute(nameof(CustomerPage), typeof(CustomerPage));


        }
    }
}
