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
        public int Create(User user)
        {
            try
            {
                if (user != null)
                {
                    using (var db = new UserDbContext())
                    {
                        db.Users.Add(user);
                        db.SaveChanges();
                    }
                    return 1;
                }
                return 0;
            }
            catch(Exception)
            {
                return -1;
            }
        }

        public int Update(User user)
        {
            if (user != null)
            {
                User userObj = GetByUserName(user.userName);
                userObj = UpdateWith(userObj, user);
                using (var db = new UserDbContext())
                {
                    db.Entry(userObj).State = EntityState.Modified;
                    db.SaveChanges();
                }
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
                using (var db = new UserDbContext())
                {
                    db.Users.Attach(userObj);
                    db.Users.Remove(userObj);
                    db.SaveChanges();
                }
                return 1;
            }
            return 0;
        }
        
        public IList<User> FindAll()
        {
            using (var db = new UserDbContext())
            {
                var userList = db.Users.ToList();
                return userList;
            }
        }
                
        public User GetByUserName(string userName)
        {
            using (var db = new UserDbContext())
            {
                var a = db.Users.Where(u => u.userName == userName).FirstOrDefault();
                return a;
            }
        }

        public Role GetByRoleName(string roleName)
        {
            using (var db = new UserDbContext())
            {
                var roleDetails = db.Roles.Where(r => r.roleName == roleName).FirstOrDefault();
                return roleDetails;
            }
        }

        public User Login(User loginUser)
        {
            using (var db = new UserDbContext())
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
}
