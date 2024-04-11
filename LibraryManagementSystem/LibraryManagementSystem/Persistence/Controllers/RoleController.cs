using LibraryManagementSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Persistence.Controllers
{
    public class RoleController
    {
        private readonly LMSDbContext _context = new();

        /// <summary>
        /// Creates a new <see cref="Role"/> in the database
        /// </summary>
        /// <param name="role">The <see cref="Role"/> to create</param>
        public int CreateRole(Role role)
        {
            if (!_context.Roles.Contains(role))
            {
                var roleCreated = _context.Roles.Add(role).Entity;
                _context.SaveChanges();

                return roleCreated.RoleId;
            }
            else
            {
                //throw an exception
                throw new Exception();
            }
        }

        /// <summary>
        /// Gets a <see cref="Role"/> from the database with the given <paramref name="roleId"/>
        /// </summary>
        /// <param name="roleId">The ID of the <see cref="Role"/> to find</param>
        /// <returns>The <see cref="Role"/> found, <c>Null</c> otherwise</returns>
        public Role GetRole(int roleId)
        {
            //return null if the role was not found
            var role = _context.Roles.FirstOrDefault(item => item.RoleId == roleId);

            if (role != null)
            {
                return role;
            }
            else
            {
                //throw an exception

                //TODO: Replace this exception with a custom one
                throw new Exception();
            }
        }

        /// <summary>
        /// Gets a list of all of the <see cref="Role"/> objects in the database
        /// </summary>
        /// <returns>A <c>List&lt;&lt;<see cref="Role"/>&gt;&gt;</c> of all of the <see cref="Role"/> objects in the database</returns>
        public List<Role> GetAllRoles()
        {
            return [.. _context.Roles];
        }

        /// <summary>
        /// Updates the given <paramref name="role"/> in the database
        /// </summary>
        /// <param name="role">The updated <see cref="Role"/></param>
        public int UpdateRole(Role role)
        {
            var roleUpdated = _context.Roles.Update(role).Entity;
            _context.SaveChanges();

            return roleUpdated.RoleId;
        }

        /// <summary>
        /// Removes a <see cref="Role"/> from the database
        /// </summary>
        /// <param name="roleId">The ID of the <see cref="Role"/> to delete</param>
        public void DeleteRole(int roleId)
        {
            //find the role to remove in the database
            var roleToRemove = _context.Roles.FirstOrDefault(role => role.RoleId == roleId);

            //check if the role was found
            if (roleToRemove != null)
            {
                _context.Roles.Remove(roleToRemove);
                _context.SaveChanges();
            }
            else
            {
                //Throw an exception
            }
        }
    }
}
