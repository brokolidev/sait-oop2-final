using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Entities
{
    public class Rental
    {
        public int RentalId { get; set; }
        public Book BookRented { get; set; }
        public User RentedBy { get; set; }
        public DateOnly DateRented { get; set; }
        public DateOnly DateExpires { get; set; }
        public DateOnly DateReturned { get; set; }
    }
}
