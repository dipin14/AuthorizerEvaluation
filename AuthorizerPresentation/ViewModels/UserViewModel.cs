using Common.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorizerPresentation.ViewModels
{
    public class UserViewModel
    {
        string userName;
        string firstName;
        string lastName;
        string password;
        string confirmPassword;
        int roleId;
        string roleName;

        [Required]
        [RegularExpression(@"^\S*$", ErrorMessage = "No white space allowed")]
        [Display(Name = "Username")]
        public string UserName
        {
            get
            {
                return userName;
            }

            set
            {
                userName = value;
            }
        }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName
        {
            get
            {
                return firstName;
            }

            set
            {
                firstName = value;
            }
        }

        [Display(Name = "Last Name")]
        public string LastName
        {
            get
            {
                return lastName;
            }

            set
            {
                lastName = value;
            }
        }

        [DataType(DataType.Password)]
        [StringLength(100,ErrorMessage = "The {0} must be atleast {2} characters long",MinimumLength = 5)]
        [Display(Name = "Password")]
        [Required]
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
        
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password",ErrorMessage = "The password and confirmation message do not match")]
        public string ConfirmPassword
        {
            get
            {
                return confirmPassword;
            }

            set
            {
                confirmPassword = value;
            }
        }

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

        [Display(Name = "Role")]
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

        public static implicit operator UserDTO(UserViewModel user)
        {
            if (user != null)
            {
                return new UserDTO
                {
                    UserName = user.userName,
                    FirstName = user.firstName,
                    LastName = user.lastName,
                    Password = user.password,
                    RoleId = user.roleId
                };
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Implicit conversion of UserDTO to UserViewModel
        /// </summary>
        /// <param name="user"></param>
        public static implicit operator UserViewModel(UserDTO user)
        {
            if (user != null)
            {
                return new UserViewModel
                {
                    userName = user.UserName,
                    firstName = user.FirstName,
                    lastName = user.LastName,
                    password = user.Password,
                    roleId = user.RoleId
                };
            }
            else
            {
                return null;
            }
        }
    }
}
