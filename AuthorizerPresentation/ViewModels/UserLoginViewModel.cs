using Common.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AuthorizerPresentation.ViewModels
{
    public class UserLoginViewModel
    {
        string username;
        string password;
        string role;

        [Required]
        [Display(Name = "Username")]
        public string Username
        {
            get
            {
                return username;
            }

            set
            {
                username = value;
            }
        }

        [Required]
        [Display(Name = "Password")]
        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
            }
        }

        public string Role
        {
            get
            {
                return role;
            }

            set
            {
                role = value;
            }
        }

        public static implicit operator UserDTO(UserLoginViewModel user)
        {
            return new UserDTO
            {
                UserName = user.Username,
                Password = user.Password
            };
        }

        public static implicit operator UserLoginViewModel(UserDTO userDto)
        {
            return new UserLoginViewModel
            {
                Username = userDto.UserName,
                Password = userDto.Password,
                Role = userDto.Role.roleName
            };
        }
    }
}