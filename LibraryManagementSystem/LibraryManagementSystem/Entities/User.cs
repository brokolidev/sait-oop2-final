using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Entities
{
    public abstract class User
    {

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public UserTypes UserType { get; set; }
        public DateTime RegisteredAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool? IsBlocked { get; set; }


        public enum UserTypes
        {
            Administrator,
            Instructor,
            Librarian,
            Student
        }

        public User()
        {
        }

        public User(int userId, string firstName, string lastName, string email, string phoneNumber)
        {
            UserId = userId;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            UserType = userType;

            RegisteredAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
            IsBlocked = false;
        }
    }
}
