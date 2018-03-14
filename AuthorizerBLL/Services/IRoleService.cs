using Common.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorizerBLL.Services
{
    public interface IRoleService
    {
        /// <summary>
        /// Create a role model
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        int Create(RoleDTO role);

        /// <summary>
        /// Update existing role model
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        int Update(RoleDTO role);

        /// <summary>
        /// Remove role model
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        int Delete(RoleDTO role);

        /// <summary>
        /// Retrieve role details using rolename
        /// </summary>
        /// <param name="roleName"></param>
        /// <returns></returns>
        RoleDTO GetByRoleName(string roleName);

        /// <summary>
        /// List all roles
        /// </summary>
        /// <returns></returns>
        IList<RoleDTO> FindAll();

        /// <summary>
        /// Obtain page priveleges using roleid
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        RoleDTO GetPagePriveleges(int roleId);
    }
}
