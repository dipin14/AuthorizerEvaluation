using AuthorizerDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorizerDAL.Repositories
{
    public interface IUserRepository
    {
        /// <summary>
        /// Insert a User in database
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        int Create(User user);

        /// <summary>
        /// Edit a User in database
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        int Update(User user);

        /// <summary>
        /// Remove a User from database
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        int Delete(User user);


        /// <summary>
        /// List all users
        /// </summary>
        /// <returns></returns>
        IList<User> FindAll();


        /// <summary>
        /// Check login credentials
        /// </summary>
        /// <param name="loginUser"></param>
        /// <returns></returns>
        User Login(User loginUser);

        /// <summary>
        /// Retrieve user by username
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        User GetByUserName(string userName);
        
    }
}
