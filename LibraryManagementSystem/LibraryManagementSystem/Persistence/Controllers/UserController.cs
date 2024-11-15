﻿using LibraryManagementSystem.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Persistence.Controllers
{
    public class UserController
    {
        private readonly LMSDbContext _context = new();

        /// <summary>
        /// Creates a new <see cref="User"/> in the database
        /// </summary>
        /// <param name="user">The <see cref="User"/> to create</param>
        public int CreateUser(User user)
        {
            if (!_context.Users.Contains(user))
            {
                var userCreated = _context.Users.Add(user).Entity;
                _context.SaveChanges();

                return userCreated.UserId;
            }
            else
            {
                //throw an exception
                throw new Exception();
            }
        }

        /// <summary>
        /// Gets a <see cref="User"/> from the database with the given <paramref name="userId"/>
        /// </summary>
        /// <param name="userId">The ID of the <see cref="User"/> to find</param>
        /// <returns>The <see cref="User"/> found, <c>Null</c> otherwise</returns>
        public User GetUser(int userId)
        {
            //return null if the user was not found
            var user = _context.Users.FirstOrDefault(item => item.UserId == userId);

            if (user != null)
            {
                return user;
            }
            else
            {
                //throw an exception

                //TODO: Replace this exception with a custom one
                throw new Exception();
            }
        }

        /// <summary>
        /// Gets a list of all of the <see cref="User"/> objects in the database
        /// </summary>
        /// <returns>A <c>List&lt;&lt;<see cref="User"/>&gt;&gt;</c> of all of the <see cref="User"/> objects in the database</returns>
        public List<User> GetAllUsers(User.UserTypes? userType = null, string firstName = "", string email = "", string phone = "")
        {

            //default the strings, if they are null
            firstName ??= "";
            email ??= "";
            phone ??= "";

            //Found the like method here: https://stackoverflow.com/questions/45708715/entity-framework-ef-functions-like-vs-string-contains
            //if there are no filters, then all will be returned
            //if there are filtered, then the where clauses will act and filter on those.
            List<User> usersFound = [.. _context.Users
                .Where(item => item.UserType == (userType ?? item.UserType))
                .Where(item => EF.Functions.Like(item.FirstName.ToLower(), "%" + (firstName == "" ? item.FirstName : firstName.ToLower()) + "%"))
                .Where(item => EF.Functions.Like(item.Email.ToLower(), "%" + (email == "" ? item.Email.ToLower() : email.ToLower()) + "%"))
                .Where(item => EF.Functions.Like(item.PhoneNumber, "%" + (phone == "" ? item.PhoneNumber : phone) + "%"))];

            return usersFound;
        }

        /// <summary>
        /// Updates the given <paramref name="user"/> in the database
        /// </summary>
        /// <param name="user">The updated <see cref="User"/></param>
        public int UpdateUser(User user)
        {
            var userUpdated = _context.Users.Update(user).Entity;
            _context.SaveChanges();

            return userUpdated.UserId;
        }

        /// <summary>
        /// Removes a <see cref="User"/> from the database
        /// </summary>
        /// <param name="userId">The ID of the <see cref="User"/> to delete</param>
        public void DeleteUser(int userId)
        {
            //find the user to remove in the database
            var userToRemove = _context.Users.FirstOrDefault(user => user.UserId == userId);

            //check if the user was found
            if (userToRemove != null)
            {
                _context.Users.Remove(userToRemove);
                _context.SaveChanges();
            }
            else
            {
                //Throw an exception
            }
        }

        public User? ValidateCredentials(string email, string password)
        {
            //This should return 1 if the credentials are valid
            var userFound = _context.Users.FirstOrDefault(item => item.Email.ToLower() == email.ToLower() &&
                item.Password == password);

            if (userFound != null)
            {
                return userFound;
            }
            else
            {
                return null;
            }
        }
    }
}
