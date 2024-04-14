using LibraryManagementSystem.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Persistence.Controllers
{
    public class RentalController
    {

        private readonly LMSDbContext _context = new();

        /// <summary>
        /// Creates a new <see cref="Rental"/> in the database
        /// </summary>
        /// <param name="rental">The <see cref="Rental"/> to create</param>
        public int CreateRental(Rental rental)
        {
            if (!_context.Rentals.Contains(rental))
            {
                var rentalCreated = _context.Rentals.Add(rental).Entity;

                //Solution found here: https://stackoverflow.com/questions/52718652/ef-core-sqlite-sqlite-error-19-unique-constraint-failed
                _context.Users.Attach(rentalCreated.RentedBy);
                _context.Books.Attach(rentalCreated.BookRented);
                _context.Categories.Attach(rentalCreated.BookRented.Category);
                _context.SaveChanges();

                return rentalCreated.RentalId;
            }
            else
            {
                //Throw an exception
                throw new Exception();
            }
        }

        /// <summary>
        /// Gets a <see cref="Rental"/> from the database with the given <paramref name="rentalId"/>
        /// </summary>
        /// <param name="rentalId">The ID of the <see cref="Rental"/> to find</param>
        /// <returns>The <see cref="Rental"/> found, <c>Null</c> otherwise</returns>
        public Rental GetRental(int rentalId)
        {
            var rental = _context.Rentals
                .Include("Book.User")
                .FirstOrDefault(item => item.RentalId == rentalId);

            if (rental != null)
            {
                return rental;
            }
            else
            {
                //Throw an exception

                //TODO: Change to a custom exception
                throw new Exception();
            }
        }

        /// <summary>
        /// Gets a list of all of the <see cref="Rental"/> objects in the database
        /// </summary>
        /// <returns>A <c>List&lt;&lt;<see cref="Rental"/>&gt;&gt;</c> of all of the <see cref="Rental"/> objects in the database</returns>
        public List<Rental> GetAllRentals(User? rentedBy = null, Book? bookRented = null,
            DateOnly? dateRented = null, DateOnly? dateExpires = null, DateOnly ? dateReturned = null, bool? finePayed = null)
        {

            List<Rental> rentalsFound = [.. _context.Rentals
                .Include("Book.User")
                .Where(item => item.RentedBy.UserId == (rentedBy == null ? item.RentedBy.UserId : rentedBy.UserId))
                .Where(item => item.BookRented.ISBN == (bookRented == null ? item.BookRented.ISBN : bookRented.ISBN))
                .Where(item => item.DateRented == (dateRented == null ? item.DateRented : dateRented))
                .Where(item => item.DateExpires == (dateExpires == null ? item.DateExpires : dateExpires))
                .Where(item => item.DateReturned == (dateReturned == null ? item.DateReturned : dateReturned))
                .Where(item => item.FinePayed == (finePayed == null ? item.FinePayed : finePayed))];

            return rentalsFound;
        }

        /// <summary>
        /// Updates the given <paramref name="rental"/> in the database
        /// </summary>
        /// <param name="rental">The updated <see cref="Rental"/></param>
        public int UpdateRental(Rental rental)
        {
            var rentalUpdated = _context.Rentals.Update(rental).Entity;
            _context.SaveChanges();

            return rentalUpdated.RentalId;
        }

        /// <summary>
        /// Removes a <see cref="Rental"/> from the database
        /// </summary>
        /// <param name="rentalId">The ID of the <see cref="Rental"/> to delete</param>
        public void DeleteRental(int rentalId)
        {
            var rentalToRemove = _context.Rentals.FirstOrDefault(item => item.RentalId == rentalId);

            if (rentalToRemove != null)
            {
                _context.Rentals.Remove(rentalToRemove);
                _context.SaveChanges();
            }
            else
            {
                //throw an exception
            }
        }
    }
}
