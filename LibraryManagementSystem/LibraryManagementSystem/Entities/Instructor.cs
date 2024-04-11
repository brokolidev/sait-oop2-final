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

        public Instructor(int userId, string firstName, string lastName, string password, string email, string phoneNumber)
            : base(userId, firstName, lastName, password, email, phoneNumber) 
        {
            UserType = UserTypes.Instructor;
        }

    }
}
