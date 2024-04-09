using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Entities
{
    public class Role
    {
        public int RoleId { get; set; }
        public required string Name { get; set; }
        public required bool IsAdmin { get; set; }
        public required bool ExtendedCheckOut { get; set; }
    }
}
