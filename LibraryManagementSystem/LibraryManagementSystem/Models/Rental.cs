using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Models
{
    public  class Rental
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int UserId { get; set; }
        public DateTime RentedAt { get; set; }
        public DateTime ReturnedAt { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Rental() { }
    }
}
