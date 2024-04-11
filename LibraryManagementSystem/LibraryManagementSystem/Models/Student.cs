using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Models
{
    public class Student : User
    {
        public Student()
        {
            
        }

        public Student(string firstName, string lastName, string email, string phoneNumber) : base(firstName, lastName, email, phoneNumber)
        {
            UserType = "Student";
        }

    }
}
