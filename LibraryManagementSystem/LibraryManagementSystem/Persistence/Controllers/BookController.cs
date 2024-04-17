using LibraryManagementSystem.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Persistence.Controllers
{
    public class BookController
    {
        private readonly LMSDbContext _context = new();

        /// <summary>
        /// Creates a new <see cref="Book"/> in the database
        /// </summary>
        /// <param name="book">The <see cref="Book"/> to create</param>
        public string CreateBook(Book book)
        {
            if (!_context.Books.Contains(book))
            {
                var bookCreated = _context.Books.Add(book).Entity;
                _context.Categories.Attach(bookCreated.Category);
                _context.SaveChanges();

                return bookCreated.ISBN;
            }
            else
            {
                //throw an exception
                throw new Exception();
            }
        }

        /// <summary>
        /// Gets a <see cref="Book"/> from the database with the given <paramref name="ISBN"/>
        /// </summary>
        /// <param name="ISBN">The ISBN of the <see cref="Book"/> to find</param>
        /// <returns>The <see cref="Book"/> found, <c>Null</c> otherwise</returns>
        public Book GetBook(string ISBN)
        {
            //found include method here: https://learn.microsoft.com/en-us/ef/core/querying/related-data/eager
            //return null if the book was not found
            var book = _context.Books
                .Include(item => item.Category)
                .FirstOrDefault(item => item.ISBN == ISBN);

            if (book != null)
            {
                return book;
            }
            else
            {
                //throw an exception

                //TODO: Replace this exception with a custom one
                throw new Exception();
            }
        }

        /// <summary>
        /// Gets a list of all of the <see cref="Book"/> objects in the database
        /// </summary>
        /// <returns>A <c>List&lt;&lt;<see cref="Book"/>&gt;&gt;</c> of all of the <see cref="Book"/> objects in the database</returns>
        public List<Book> GetAllBooks(Category? category = null, string title = "")
        {
            //default the variables that are not defaulted to null
            title ??= "";

            //if there are no filters, then all will be returned
            //if there are filtered, then the where clauses will act and filter on those.
            List<Book> booksFound = [.. _context.Books
                .Include(item => item.Category)
                .Where(item => EF.Functions.Like(item.Title.ToLower(), "%" + (title == "" ? item.Title.ToLower() : title.ToLower()) + "%"))
                .Where(item => item.CategoryId == (category == null ? item.CategoryId : category.CategoryId))];

            return booksFound;
        }

        /// <summary>
        /// Updates the given <paramref name="book"/> in the database
        /// </summary>
        /// <param name="book">The updated <see cref="Book"/></param>
        public string UpdateBook(Book book)
        {
            var bookUpdated = _context.Books.Update(book).Entity;
            _context.SaveChanges();

            return bookUpdated.ISBN;
        }

        /// <summary>
        /// Removes a <see cref="Book"/> from the database
        /// </summary>
        /// <param name="ISBN">The ISBN of the book to delete</param>
        public void DeleteBook(string ISBN)
        {
            //find the book to remove in the database
            var bookToRemove = _context.Books.FirstOrDefault(book => book.ISBN == ISBN);

            //check if the book was found
            if (bookToRemove != null)
            {
                _context.Books.Remove(bookToRemove);
                _context.SaveChanges();
            }
            else
            {
                //Throw an exception
            }
        }
    }
}
