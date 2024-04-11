namespace LibraryManagementSystem.Config
{
    public static class SystemEnv
    {
        private static bool isAuthorized = false;

        public static readonly int RentalDaysForStudent = 14;
        public static readonly int RentalDaysForInstructor = 30;
        public static bool GetIsAuthorized 
        {
            get 
            {
                return isAuthorized;
            }

            set
            {
                isAuthorized = value;
            }
        }
    }
}
