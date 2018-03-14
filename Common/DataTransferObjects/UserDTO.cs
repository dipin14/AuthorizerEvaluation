using AuthorizerDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DataTransferObjects
{
    public class UserDTO
    {
        string userName;
        string firstName;
        string lastName;
        string password;
        int roleId;

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

        public static implicit operator User(UserDTO userDto)
        {
            return new User
            {
                userName = userDto.UserName,
                firstName = userDto.FirstName,
                lastName = userDto.LastName,
                password = userDto.Password,
                roleId = userDto.RoleId
            };
        }

        public static implicit operator UserDTO(User user)
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
    }
}
