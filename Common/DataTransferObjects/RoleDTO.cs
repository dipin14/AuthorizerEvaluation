using AuthorizerDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DataTransferObjects
{
    public class RoleDTO
    {
        string roleName;

        public string RoleName
        {
            get
            {
                return roleName;
            }

            set
            {
                roleName = value;
            }
        }

        public static implicit operator Role(RoleDTO roleDto)
        {
            return new Role
            {
                roleName = roleDto.RoleName
            };
        }

        public static implicit operator RoleDTO(Role role)
        {
            return new RoleDTO
            {
                roleName = role.roleName
            };
        }
    }
}
