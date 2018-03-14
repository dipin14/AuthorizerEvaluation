using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthorizerDAL.Models;
using AuthorizerDAL.DatabaseContext;
using System.Data.Entity;

namespace AuthorizerDAL.Repositories
{
    public class RoleRepository : IRoleRepository
    {        
        public int Create(Role role)
        {
            try
            {
                if (role != null)
                {
                    using (var db = new UserDbContext())
                    {
                        db.Roles.Add(role);
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
        
        public int Delete(Role role)
        {
            try
            {
                if (role != null)
                {
                    Role roleObj = GetByRoleName(role.roleName);
                    using (var db = new UserDbContext())
                    {
                        db.Roles.Remove(roleObj);
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
        
        public IList<Role> FindAll()
        {
            IList<Role> roleList;
            using (var db = new UserDbContext())
            {
                roleList = db.Roles.ToList();
            }
            return roleList;
        }        
        
        public int Update(Role role)
        {
            try
            {
                if (role != null)
                {
                    using (var db = new UserDbContext())
                    {
                        db.Entry(role).State = EntityState.Modified;
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
                
        public Role GetByRoleName(string roleName)
        {
            try
            {
                using (var db = new UserDbContext())
                {
                    var roleDetails = db.Roles.Where(r => r.roleName == roleName).FirstOrDefault();
                    return roleDetails;
                }                
            }
            catch(Exception)
            {
                return null;
            }
        }

        public Role GetPagePriveleges(int roleId)
        {
            try
            {
                using (var db = new UserDbContext())
                {
                    var priveleges = db.Roles.Find(roleId);
                    return priveleges;
                }
            }
            catch(Exception)
            {
                return null;
            }
        }
    }
}
