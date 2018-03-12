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
        string roleName;

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

        public static implicit operator RoleDTO(RoleViewModel role)
        {
            return new RoleDTO
            {
                RoleName = role.RoleName
            };
        }

        public static implicit operator RoleViewModel(RoleDTO roleDto)
        {
            return new RoleViewModel
            {
                RoleName = roleDto.RoleName
            };
        }
    }
}