using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Config
{
    public class SystemEnv
    {
        public int RentalDaysForStudent { get; set; }
        public int RentalDaysForInstructor { get; set; }


        public SystemEnv()
        {
            // Default values
            // This can be changed by the administrator
            // need to be stored in the database
            RentalDaysForStudent = 14;
            RentalDaysForInstructor = 30;
        }
    }
}
