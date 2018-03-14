using Common.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AuthorizerPresentation.ViewModels
{
    public class RoleViewModel
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

        [Display(Name = "Role Name")]
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

        [Display(Name = "Page A")]
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

        [Display(Name = "Page B")]
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

        [Display(Name = "Page C")]
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

        public static implicit operator RoleDTO(RoleViewModel role)
        {
            if (role != null)
            {
                return new RoleDTO
                {
                    RoleId = role.RoleId,
                    RoleName = role.RoleName,
                    AccessToPageA = role.AccessToPageA,
                    AccessToPageB = role.AccessToPageB,
                    AccessToPageC = role.AccessToPageC
                };
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Implicit conversion of RoleDTO to RoleViewModel
        /// </summary>
        /// <param name="roleDto"></param>
        public static implicit operator RoleViewModel(RoleDTO roleDto)
        {
            if (roleDto != null)
            {
                return new RoleViewModel
                {
                    RoleId = roleDto.RoleId,
                    RoleName = roleDto.RoleName,
                    AccessToPageA = roleDto.AccessToPageA,
                    AccessToPageB = roleDto.AccessToPageB,
                    AccessToPageC = roleDto.AccessToPageC
                };
            }
            else
            {
                return null;
            }
        }
    }
}