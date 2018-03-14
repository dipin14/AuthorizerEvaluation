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
        /// Insert a Role in database
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
        /// Remove a Role from database
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        int Delete(Role role);


        /// <summary>
        /// List all roles
        /// </summary>
        /// <returns></returns>
        IList<Role> FindAll();

        /// <summary>
        /// Retrieve role details using rolename
        /// </summary>
        /// <param name="roleName"></param>
        /// <returns></returns>
        Role GetByRoleName(string roleName);


        /// <summary>
        /// Retrieve page privileges using roleid
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        Role GetPagePriveleges(int roleId);
    }
}
