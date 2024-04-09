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
    public class Book
    {
        [Key]
        [NotNull]
        public required string ISBN { get; set; }
        public required string Title { get; set; }
        public required string AuthorFirstName { get; set; }
        public required string AuthorLastName { get; set; }
        public int? Total { get; set; }
        public int? CheckedOut { get; set; }
    }
}
