using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthorizerDAL.DatabaseContext;
using AuthorizerDAL.Models;
using System.Data.Entity;
using System.Web.Mvc;

namespace AuthorizerDAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        UserDbContext db = new UserDbContext();

        public int Create(User user)
        {
            if (user != null)
            {
                user.Role = GetByRoleName(user.Role.roleName);
                db.Users.Add(user);
                db.SaveChanges();
                return 1;
            }
            return 0;
        }

        public int Update(User user)
        {
            if (user != null)
            {
                User userObj = GetByUserName(user.userName);
                userObj = UpdateWith(userObj, user);
                db.Entry(userObj).State = EntityState.Modified;
                db.SaveChanges();
                return 1;
            }
            return 0;
        }

        private User UpdateWith(User old, User updated)
        {
            old.firstName = updated.firstName;
            old.lastName = updated.lastName;
            old.roleId = updated.roleId;
            return old;
        }

        public int Delete(User user)
        {
            if (user != null)
            {
                User userObj = GetByUserName(user.userName);
                db.Users.Remove(userObj);
                db.SaveChanges();
                return 1;
            }
            return 0;
        }

        public int AdminExists()
        {
            if (db.Users.Any(u => u.Role.roleName.ToLower() == "admin"))
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public IList<User> FindAll()
        {
            return db.Users.ToList();
        }

        public User GetByUserName(string userName)
        {
            var a = db.Users.Where(u => u.userName == userName).FirstOrDefault();
            return a;
        }

        public Role GetByRoleName(string roleName)
        {
            var roleDetails = db.Roles.Where(r => r.roleName == roleName).FirstOrDefault();
            return roleDetails;
        }

        public User Login(User loginUser)
        {
            var obj = db.Users.Where(u => u.userName.Equals(loginUser.userName) && u.password.Equals(loginUser.password)).FirstOrDefault();
            if (obj != null)
            {
                return obj;
            }
            else
                return null;
        }
    }
}
