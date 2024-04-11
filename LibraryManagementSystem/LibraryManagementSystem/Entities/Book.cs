using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Entities
{
    public class Book
    {
        [Key]
        public required string ISBN { get; set; }
        public required string Title { get; set; }
        public required string Author { get; set; }
        public string? Publisher { get; set; }
        //public required Category Category { get; set; }
        //public required DateTime DatePublished { get; set; }
        //public required DateTime DateRegistered { get; set; }
        public DateTime? DateUpdated { get; set; }
        public int? Total { get; set; }
        public int? CheckedOut { get; set; }

    }
}
