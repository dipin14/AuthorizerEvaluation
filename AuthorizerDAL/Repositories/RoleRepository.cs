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
        UserDbContext db = new UserDbContext();

        public int Create(Role role)
        {
            if (role != null)
            {
                db.Roles.Add(role);
                db.SaveChanges();
                return 1;
            }
            return 0;
        }

        public int Delete(Role role)
        {
            if (role != null)
            {
                Role roleObj = GetByRoleName(role.roleName);
                db.Roles.Remove(roleObj);
                db.SaveChanges();
                return 1;
            }
            return 0;
        }

        public IList<Role> FindAll()
        {
            return db.Roles.ToList();
        }        

        public int Update(Role role)
        {
            if (role != null)
            {
                Role roleObj = GetByRoleName(role.roleName);
                roleObj = role;
                db.Entry(roleObj).State = EntityState.Modified;
                db.SaveChanges();
                return 1;
            }
            return 0;
        }

        public Role GetByRoleName(string roleName)
        {
            var roleDetails = db.Roles.Where(r => r.roleName == roleName).FirstOrDefault();
            return roleDetails;
        }
    }
}
