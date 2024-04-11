using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Entities
{
    public class Rental
    {
        [Key]
        public int RentalId { get; set; }

        [DeleteBehavior(DeleteBehavior.SetNull)]
        public Book? BookRented { get; set; }

        [DeleteBehavior(DeleteBehavior.SetNull)]
        public User? RentedBy { get; set; }

        [NotNull]
        public DateOnly DateRented { get; set; } = new();

        [NotNull]
        public DateOnly DateExpires { get; set; } = new(); //calculated from the constants based on type of user
        public DateOnly? DateReturned { get; set; }
        public DateOnly? DateUpdated { get; set; }
        public bool? FinePayed { get; set; }
        public double? FineAmount { get; set; }
    }
}
