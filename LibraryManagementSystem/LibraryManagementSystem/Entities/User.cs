using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Entities
{
    public abstract class User
    {

        /*
         * TODO:
         *    - change all required to [NotNull]
         *        - This will make the entities work better with the rest of the program
         *    - DateTime should be TimeOnly. this will keep the data consistent.
         */

        [Key]
        public int UserId { get; set; }

        [NotNull]
        public string FirstName { get; set; } = String.Empty;

        [NotNull]
        public string LastName { get; set; } = String.Empty;

        [NotNull]
        public string Email { get; set; } = String.Empty;

        [NotNull]
        public string Password { get; set; } = String.Empty;

        [NotNull]
        public string PhoneNumber { get; set; } = String.Empty;

        [NotNull]
        public DateOnly DateRegistered { get; set; } = new();
        public DateOnly? DateUpdated { get; set; }
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
