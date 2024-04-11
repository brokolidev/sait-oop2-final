using LibraryManagementSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Persistence.Controllers
{
    public class CategoryController
    {
        private readonly LMSDbContext _context = new();

        /// <summary>
        /// Creates a new <see cref="Category"/> in the database
        /// </summary>
        /// <param name="category">The <see cref="Category"/> to create</param>
        public int CreateCategory(Category category)
        {
            if (!_context.Categories.Contains(category))
            {
                var categoryCreated = _context.Categories.Add(category).Entity;
                _context.SaveChanges();

                return categoryCreated.CategoryId;
            }
            else
            {
                //throw an exception
                throw new Exception();
            }
        }

        /// <summary>
        /// Gets a <see cref="Category"/> from the database with the given <paramref name="categoryId"/>
        /// </summary>
        /// <param name="categoryId">The ID of the <see cref="Category"/> to find</param>
        /// <returns>The <see cref="Category"/> found, <c>Null</c> otherwise</returns>
        public Category GetCategory(int categoryId)
        {
            //return null if the category was not found
            var category = _context.Categories.FirstOrDefault(item => item.CategoryId == categoryId);

            if (category != null)
            {
                return category;
            }
            else
            {
                //throw an exception

                //TODO: Replace this exception with a custom one
                throw new Exception();
            }
        }

        /// <summary>
        /// Gets a list of all of the <see cref="Category"/> objects in the database
        /// </summary>
        /// <returns>A <c>List&lt;&lt;<see cref="Category"/>&gt;&gt;</c> of all of the <see cref="Category"/> objects in the database</returns>
        public List<Category> GetAllCategories()
        {
            return [.. _context.Categories];
        }

        /// <summary>
        /// Updates the given <paramref name="category"/> in the database
        /// </summary>
        /// <param name="category">The updated <see cref="Category"/></param>
        public int UpdateCategory(Category category)
        {
            var categoryUpdated = _context.Categories.Update(category).Entity;
            _context.SaveChanges();

            return categoryUpdated.CategoryId;
        }

        /// <summary>
        /// Removes a <see cref="Category"/> from the database
        /// </summary>
        /// <param name="categoryId">The ID of the <see cref="Category"/> to delete</param>
        public void DeleteCategory(int categoryId)
        {
            //find the category to remove in the database
            var categoryToRemove = _context.Categories.FirstOrDefault(category => category.CategoryId == categoryId);

            //check if the category was found
            if (categoryToRemove != null)
            {
                _context.Categories.Remove(categoryToRemove);
                _context.SaveChanges();
            }
            else
            {
                //Throw an exception
            }
        }
    }
}
