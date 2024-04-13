using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Entities
{
    public class Instructor : User
    {
        public Instructor() { }

        public Instructor(string firstName, string lastName, string password, string email, string phoneNumber)
            : base(firstName, lastName, password, email, phoneNumber) 
        {
            UserType = UserTypes.Instructor;
        }

    }
}
