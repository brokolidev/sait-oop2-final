using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Entities
{
    public class Administrator : User
    {
        public Administrator() { }

        public Administrator(string firstName, string lastName, string email, string password, string phoneNumber)
            : base(firstName, lastName, email, password, phoneNumber) { }

    }
}
