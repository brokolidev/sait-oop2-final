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
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string PhoneNumber { get; set; }
        public required UserTypes UserType { get; set; }
        public required DateTime RegisteredAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool? IsBlocked { get; set; }


        public enum UserTypes
        {
            Administrator,
            Instructor,
            Librarian,
            Student
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string UserType { get; set; }
        public DateTime RegisteredAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsBlocked { get; set; }

        public User()
        {
        }

        public User(string firstName, string lastName, string email, string password, string phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            PhoneNumber = phoneNumber;

            IsBlocked = false;
        }

    }
}
