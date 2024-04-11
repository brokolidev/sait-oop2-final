using LibraryManagementSystem.Entities;

namespace LibraryManagementSystem.Config
{
    public static class SystemEnv
    {
        public const int RENTAL_DAYS_FOR_STUDENT = 14;
        public const int RENTAL_DAYS_FOR_INSTRUCTOR = 30;

        public static User? LoggedInUser { get; set; }
        public static bool IsAuthorized { get; set; }
    }
}
