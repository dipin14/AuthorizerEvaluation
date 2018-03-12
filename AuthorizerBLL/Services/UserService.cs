using AuthorizerDAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Common.DataTransferObjects;

namespace AuthorizerBLL.Services
{
    public class UserService : IUserService
    {
        
        private readonly IUserRepository _iUserRepository;

        //DI to UserRepository
        public UserService(IUserRepository userRepository)
        {
            _iUserRepository = userRepository;
        }
                
        public int Create(UserDTO user)
        {
            return _iUserRepository.Create(user);
        }


        public int Update(UserDTO user)
        {
            return _iUserRepository.Update(user);
        }

        public int Delete(UserDTO user)
        {
            return _iUserRepository.Delete(user);
        }

        public int checkAdmin()
        {
            return _iUserRepository.AdminExists();
        }

        public IList<UserDTO> FindAll()
        {
            return _iUserRepository.FindAll().Select(b => new UserDTO()
            {
                FirstName = b.firstName,
                LastName = b.lastName,
                Password = b.password,
                UserName = b.userName,
                Role = b.Role
            }).ToList();
        }

        public UserDTO GetByUserName(string userName)
        {
            if (userName == null)
            {
                return null;
            }
            else
            {
                //Removes empty spaces if any
                var checkUserName = userName.Trim();
                return _iUserRepository.GetByUserName(userName);
            }
        }

        public UserDTO Login(UserDTO loginUser)
        {
            var loginResult = _iUserRepository.Login(loginUser);
            if (loginResult!=null)
            {
                return loginResult;
            }
            else
            {
                return null;
            }
        }
    }
}
