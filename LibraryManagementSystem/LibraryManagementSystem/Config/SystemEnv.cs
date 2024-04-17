using LibraryManagementSystem.Entities;
using LibraryManagementSystem.Persistence.Controllers;
using System;
using System.Net.Mail;

namespace LibraryManagementSystem.Config
{
    public static class SystemEnv
    {
        public static int RentalDaysForStudent { get; set; }
        public static int RentalDaysForInstructor { get; set; }

        public static User? LoggedInUser { get; set; }
        public static bool IsAuthorized { get; set; }

        /// <summary>
        /// Calculates the expiration date for a rental based on the user type.
        /// </summary>
        /// <remarks>
        /// This method calculates the expiration date for a rental based on the user type of the logged-in user.
        /// If the user is a student, it returns the current date plus the number of rental days allowed for students (default: 14 days).
        /// If the user is an instructor, it returns the current date plus the number of rental days allowed for instructors (default: 30 days).
        /// If the user is not recognized or the rental days are not set, it returns the current date.
        /// </remarks>
        /// <returns>The calculated expiration date.</returns>
        public static DateOnly CalculateExpireDate()
        {
            int rentalDays = LoggedInUser?.UserType switch
            {
                User.UserTypes.Student => RentalDaysForStudent != 0 ? RentalDaysForStudent : 14,
                User.UserTypes.Instructor => RentalDaysForInstructor != 0 ? RentalDaysForInstructor : 30,
                _ => 0
            };

            return DateOnly.FromDateTime(DateTime.Now.AddDays(rentalDays));
        }

        // validtaion for email address
        public static bool IsValidEmail(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
