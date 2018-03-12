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
        RoleDTO userRole;

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

        public RoleDTO UserRole
        {
            get
            {
                return userRole;
            }

            set
            {
                userRole = value;
            }
        }

        public static implicit operator UserDTO(UserViewModel user)
        {
            return new UserDTO
            {
                UserName = user.userName,
                FirstName = user.firstName,
                LastName = user.lastName,
                Password = user.password,
                Role = user.UserRole
            };
        }

        public static implicit operator UserViewModel(UserDTO user)
        {
            return new UserViewModel
            {
                userName = user.UserName,
                firstName = user.FirstName,
                lastName = user.LastName,
                password = user.Password,
                userRole = user.Role
            };
        }
    }
}
