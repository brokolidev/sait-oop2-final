using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Entities
{
    public class Librarian : User
    {
        public Librarian() : base() { }

        public Librarian(int userId, string firstName, string lastName, string email,string password, string phoneNumber)
            : base(userId, firstName, lastName, email, password, phoneNumber) 
        { 
            UserType = UserTypes.Librarian;
        }
    }
}
