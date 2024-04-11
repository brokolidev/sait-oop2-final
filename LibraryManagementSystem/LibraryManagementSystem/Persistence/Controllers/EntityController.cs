namespace LibraryManagementSystem.Persistence.Controllers
{
    /// <summary>
    /// A class to call the entity controllers with
    /// </summary>
    public static class EntityController
    {
        public static readonly BookController bookController = new();
        public static readonly RentalController rentalController = new();
        public static readonly UserController userController = new();
        public static readonly CategoryController categoryController = new();
    }
}
