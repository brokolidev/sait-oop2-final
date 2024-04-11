namespace LibraryManagementSystem.Entities
{
    public class Administrator : User
    {
        public Administrator() { }

        public Administrator(int userId, string firstName, string lastName, string email, string password, string phoneNumber)
            : base(userId, firstName, lastName, email, password, phoneNumber) 
        {
            UserType = UserTypes.Administrator;
        }

    }
}
