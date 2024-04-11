﻿using LibraryManagementSystem.Entities;

namespace LibraryManagementSystem.Config
{
    public static class SystemEnv
    {
        private static string? logedInUserFirstName;
        private static string? logedInUserLastName;
        private static Enum? loggedInUserType;

        public static readonly int RentalDaysForStudent = 14;
        public static readonly int RentalDaysForInstructor = 30;
        public static bool IsAuthorized { get; set; }

        public static string GetLogedInUserFirstName
        {
            get
            {
                return logedInUserFirstName;
            }

            set
            {
                logedInUserFirstName = value;
            }
        }

        public static string GetLogedInUserLastName
        {
            get
            {
                return logedInUserLastName;
            }

            set
            {
                logedInUserLastName = value;
            }
        }

        public static Enum GetLogedInUserType
        {
            get
            {
                return loggedInUserType;
            }

            set
            {
                loggedInUserType = value;
            }
        }
    }
}
