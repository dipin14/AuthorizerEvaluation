using Common.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorizerBLL.Services
{
    public interface IUserService
    {
        /// <summary>
        /// Create a user model
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        int Create(UserDTO user);

        /// <summary>
        /// Update existing user model
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        int Update(UserDTO user);

        /// <summary>
        /// Remove user model from database
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        int Delete(UserDTO user);

        /// <summary>
        /// Check login credentials
        /// </summary>
        /// <param name="loginUser"></param>
        /// <returns></returns>
        UserDTO Login(UserDTO loginUser);

        /// <summary>
        /// Retrieve user details using username
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        UserDTO GetByUserName(string userName);

        /// <summary>
        /// List all users
        /// </summary>
        /// <returns></returns>
        IList<UserDTO> FindAll();
    }
}
