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
        [NotNull]
        public string ISBN { get; set; } = String.Empty;

        [NotNull]
        public string Title { get; set; } = String.Empty;

        [NotNull]
        public string Author { get; set; } = String.Empty;
        public string? Publisher { get; set; }
        
        [NotNull]
        public Category Category { get; set; } = new();
        
        [NotNull]
        public DateOnly DatePublished { get; set; } = new();
        
        [NotNull]
        public DateOnly DateRegistered { get; set; } = new();
        public DateOnly? DateUpdated { get; set; }
        public int? Total { get; set; }
        public int? CheckedOut { get; set; }

        public Book() { }
    }
}
