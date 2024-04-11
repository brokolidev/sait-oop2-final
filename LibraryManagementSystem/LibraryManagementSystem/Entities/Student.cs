﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Entities
{
    public class Student : User
    {
        public Student()
        {
            UserType = UserTypes.Student;
        }

        public Student(int userId, string firstName, string lastName, string email, string phoneNumber)
            : base(userId, firstName, lastName, email, phoneNumber)
        {
            UserType = UserTypes.Student;
        }

    }
}
