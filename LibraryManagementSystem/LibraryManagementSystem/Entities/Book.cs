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

        public Book(string ISBN, string title, string author, string publisher, Category category, DateOnly datePublished, int total, int checkedOut=0)
        {
            this.ISBN = ISBN;
            this.Title = title;
            this.Author = author;
            this.Publisher = publisher;
            this.Category = category;
            this.Total = total;
            this.CheckedOut = checkedOut;
            this.DatePublished = datePublished;

            this.DateRegistered = DateOnly.FromDateTime(DateTime.Now);
            this.DateUpdated = DateOnly.FromDateTime(DateTime.Now);
        }
    }
}
