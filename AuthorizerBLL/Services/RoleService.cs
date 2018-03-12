using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.DataTransferObjects;
using AuthorizerDAL.Repositories;

namespace AuthorizerBLL.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _iRoleRepository;

        //DI to UserRepository
        public RoleService(IRoleRepository roleRepository)
        {
            _iRoleRepository = roleRepository;
        }

        public int Create(RoleDTO role)
        {
            return _iRoleRepository.Create(role);
        }


        public int Update(RoleDTO role)
        {
            return _iRoleRepository.Update(role);
        }

        public int Delete(RoleDTO role)
        {
            return _iRoleRepository.Delete(role);
        }

        public IList<RoleDTO> FindAll()
        {
            return _iRoleRepository.FindAll().Select(r => new RoleDTO()
            {
                RoleName = r.roleName
            }).ToList();
        }

        public RoleDTO GetByRoleName(string roleName)
        {
            if (roleName == null)
            {
                return null;
            }
            else
            {
                //Removes empty spaces if any
                var checkRoleName = roleName.Trim();
                return _iRoleRepository.GetByRoleName(checkRoleName);
            }
        }
    }
}
