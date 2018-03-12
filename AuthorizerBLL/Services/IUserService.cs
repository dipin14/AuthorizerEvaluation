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
        int Create(UserDTO user);
        int Update(UserDTO user);
        int Delete(UserDTO user);

        UserDTO Login(UserDTO loginUser);

        UserDTO GetByUserName(string userName);

        /// <summary>
        /// List all users
        /// </summary>
        /// <returns></returns>
        IList<UserDTO> FindAll();

        int checkAdmin();
    }
}
