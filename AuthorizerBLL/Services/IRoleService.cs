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
        int Create(RoleDTO role);
        int Update(RoleDTO role);
        int Delete(RoleDTO role);

        RoleDTO GetByRoleName(string roleName);

        /// <summary>
        /// List all roles
        /// </summary>
        /// <returns></returns>
        IList<RoleDTO> FindAll();
    }
}
