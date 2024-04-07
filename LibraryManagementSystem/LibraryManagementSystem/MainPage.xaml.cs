using LibraryManagementSystem.Entities;
using LibraryManagementSystem.Persistence.Controllers;

namespace LibraryManagementSystem
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        

        public MainPage()
        {
            InitializeComponent();
            TestDb();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }

        private void TestDb()
        {
            Book book = new()
            {
                ISBN = "1234567890123",
                Title = "Test",
                AuthorFirstName = "Test",
                AuthorLastName = "Test",
                Total = 5,
                CheckedOut = 0
            };
            
            EntityController.bookController.CreateBook(book);

            Role role = new()
            {
                Name = "Librarian"
            };
            
            int newRoleId = EntityController.roleController.CreateRole(role);
            role = EntityController.roleController.GetRole(newRoleId);

            User user = new()
            {
                FirstName = "Bob",
                LastName = "Test",
                UserRole = role,
                Email = "Bob@email.com",
                Password = "bobBob"
            };
            
            int newUserId = EntityController.userController.CreateUser(user);
            user = EntityController.userController.GetUser(newUserId);

            Rental rental = new()
            {
                RentedBy = user,
                BookRented = book,
                DateRented = new DateOnly(2024, 01, 01),
                DateExpires = new DateOnly(2024, 01, 08),
                DateReturned = new DateOnly(2024, 01, 10)
            };

            EntityController.rentalController.CreateRental(rental);
        }
    }

}
