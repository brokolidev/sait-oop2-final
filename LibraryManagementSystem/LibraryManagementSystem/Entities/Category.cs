using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }
        public required string Name { get; set; }
        public required DateTime DateRegistered { get; set; }
        public DateTime? DateUpdated { get; set; }

        public Category() { }
    }
}
