using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Entities
{
    public class Administrator : User
    {
        public Administrator()
        {
            UserType = UserTypes.Administrator;
        }

        public Administrator(string firstName, string lastName, string email, string password, string phoneNumber)
            : base(firstName, lastName, email, password, phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            PhoneNumber = phoneNumber;

            UserType = UserTypes.Administrator;
        }

    }
}
