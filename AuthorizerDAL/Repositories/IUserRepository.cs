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
        /// Create a User in database
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
        /// Delete a User from database
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        int Delete(User user);


        /// <summary>
        /// List all users
        /// </summary>
        /// <returns></returns>
        IList<User> FindAll();

        User Login(User loginUser);

        User GetByUserName(string userName);

        /// <summary>
        /// Check if Admin exists in database
        /// </summary>
        /// <returns></returns>
        int AdminExists();
    }
}
