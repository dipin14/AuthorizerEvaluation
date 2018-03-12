using AuthorizerDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorizerDAL.Repositories
{
    public interface IRoleRepository
    {
        /// <summary>
        /// Create a Role in database
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        int Create(Role role);

        /// <summary>
        /// Edit a Role in database
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        int Update(Role role);

        /// <summary>
        /// Delete a Role from database
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        int Delete(Role role);


        /// <summary>
        /// List all roles
        /// </summary>
        /// <returns></returns>
        IList<Role> FindAll();

        Role GetByRoleName(string roleName);
    }
}
