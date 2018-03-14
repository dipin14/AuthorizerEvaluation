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
        bool rememberMe;

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

        [Display(Name = "Remember Me")]
        public bool RememberMe
        {
            get
            {
                return rememberMe;
            }

            set
            {
                rememberMe = value;
            }
        }

        /// <summary>
        /// Implicit conversion of UserLoginViewModel to UserDTO
        /// </summary>
        /// <param name="user"></param>
        public static implicit operator UserDTO(UserLoginViewModel user)
        {
            if (user != null)
            {
                return new UserDTO
                {
                    UserName = user.Username,
                    Password = user.Password
                };
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Implicit conversion of UserDTO to UserLoginViewModel
        /// </summary>
        /// <param name="userDto"></param>
        public static implicit operator UserLoginViewModel(UserDTO userDto)
        {
            if (userDto != null)
            {
                return new UserLoginViewModel
                {
                    Username = userDto.UserName,
                    Password = userDto.Password,
                    Role = userDto.RoleId.ToString()
                };
            }
            else
            {
                return null;
            }
        }
    }
}