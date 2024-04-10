using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Models
{
    public class Librarian : User
    {
        public Librarian() : base() 
        {
            UserType = "Librarian";
        }

        public Librarian(string firstName, string lastName, string email, string phoneNumber) : base(firstName, lastName, email, phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            UserType = "Librarian";
        }
    }
}
