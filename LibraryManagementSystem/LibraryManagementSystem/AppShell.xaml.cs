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
            Routing.RegisterRoute(nameof(AddCustomerPage), typeof(AddCustomerPage));
            Routing.RegisterRoute(nameof(SystemPage), typeof(SystemPage));
            Routing.RegisterRoute(nameof(RentalPage), typeof(RentalPage));
            Routing.RegisterRoute(nameof(BookDetail), typeof(BookDetail));
            Routing.RegisterRoute(nameof(BookEdit), typeof(BookEdit));
            Routing.RegisterRoute(nameof(UserDetail), typeof(UserDetail));
            Routing.RegisterRoute(nameof(UserEdit), typeof(UserEdit));
            Routing.RegisterRoute(nameof(StaffRentalHistory), typeof(StaffRentalHistory));
            Routing.RegisterRoute(nameof(CustomerRentalHistory), typeof(CustomerRentalHistory));

        }
    }
}
