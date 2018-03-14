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
        int roleId;
        string roleName;
        bool accessToPageA;
        bool accessToPageB;
        bool accessToPageC;

        public int RoleId
        {
            get
            {
                return roleId;
            }

            set
            {
                roleId = value;
            }
        }

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

        public bool AccessToPageA
        {
            get
            {
                return accessToPageA;
            }

            set
            {
                accessToPageA = value;
            }
        }

        public bool AccessToPageB
        {
            get
            {
                return accessToPageB;
            }

            set
            {
                accessToPageB = value;
            }
        }

        public bool AccessToPageC
        {
            get
            {
                return accessToPageC;
            }

            set
            {
                accessToPageC = value;
            }
        }

        /// <summary>
        /// Implicit Conversion of RoleDTO to Role
        /// </summary>
        /// <param name="roleDto"></param>
        public static implicit operator Role(RoleDTO roleDto)
        {
            if (roleDto != null)
            {
                return new Role
                {
                    roleId = roleDto.RoleId,
                    roleName = roleDto.RoleName,
                    accessToPageA = roleDto.AccessToPageA,
                    accessToPageB = roleDto.AccessToPageB,
                    accessToPageC = roleDto.AccessToPageC,
                };
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Implicit conversion of Role to RoleDTO
        /// </summary>
        /// <param name="role"></param>
        public static implicit operator RoleDTO(Role role)
        {
            if (role != null)
            {
                return new RoleDTO
                {
                    roleId = role.roleId,
                    roleName = role.roleName,
                    accessToPageA = role.accessToPageA,
                    accessToPageB = role.accessToPageB,
                    accessToPageC = role.accessToPageC
                };
            }
            else
            {
                return null;
            }
        }
    }
}
