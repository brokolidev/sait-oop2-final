using LibraryManagementSystem.Entities;

namespace LibraryManagementSystem.Config
{
    public static class SystemEnv
    {
        public const int RENTAL_DAYS_FOR_STUDENT = 14;
        public const int RENTAL_DAYS_FOR_INSTRUCTOR = 30;

        public static User? LoggedInUser { get; set; }
        public static bool IsAuthorized { get; set; }

        public static DateOnly CalculateExpireDate()
        {
            return LoggedInUser?.UserType switch
            {
                User.UserTypes.Student => DateOnly.FromDateTime(DateTime.Now.AddDays(RENTAL_DAYS_FOR_STUDENT)),
                User.UserTypes.Instructor => DateOnly.FromDateTime(DateTime.Now.AddDays(RENTAL_DAYS_FOR_INSTRUCTOR)),
                _ => DateOnly.FromDateTime(DateTime.Now)
            };
        }
    }
}
