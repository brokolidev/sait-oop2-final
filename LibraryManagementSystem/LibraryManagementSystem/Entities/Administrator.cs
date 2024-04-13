namespace LibraryManagementSystem.Entities
{
    public class Administrator : User
    {
        public Administrator() { }

        public Administrator(string firstName, string lastName, string email, string password, string phoneNumber)
            : base(firstName, lastName, email, password, phoneNumber) 
        {
            UserType = UserTypes.Administrator;
        }

    }
}
