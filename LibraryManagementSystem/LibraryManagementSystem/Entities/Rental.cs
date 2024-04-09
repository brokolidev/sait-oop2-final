using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Entities
{
    public class Rental
    {
        public int RentalId { get; set; }

        [DeleteBehavior(DeleteBehavior.SetNull)]
        public Book? BookRented { get; set; }

        [DeleteBehavior(DeleteBehavior.SetNull)]
        public User? RentedBy { get; set; }
        public required DateOnly DateRented { get; set; }
        public required DateOnly DateExpires { get; set; }
        public DateOnly? DateReturned { get; set; }
        public bool? FinePayed { get; set; }
        public double? FineAmount { get; set; }
    }
}
