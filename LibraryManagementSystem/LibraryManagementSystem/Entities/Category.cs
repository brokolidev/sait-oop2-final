using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Entities
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [NotNull]
        public string Name { get; set; } = String.Empty;

        [NotNull] 
        public DateOnly DateRegistered { get; set; } = new();
        public DateOnly? DateUpdated { get; set; }

        public Category() { }
    }
}
