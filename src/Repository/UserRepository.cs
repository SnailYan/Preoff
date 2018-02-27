using Preoff.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Preoff.Repository
{
    public sealed class UserRepository : RepositoryBase<UserTable>, IUserRepository
    {
        PreoffContext _dbcontext;
        public UserRepository(PreoffContext dbcontext) : base(dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public void BatchUpdateUserBirthday()
        {
            //using (var dbcontext = new DbContext(ConnectionString))
            //{
            //    var usersFromDb = dbcontext.Set<User>().Where(q => q.Name.Equals("zhang"));
            //    foreach (var item in usersFromDb)
            //    {
            //        item.Name = "wang";
            //        dbcontext.Entry(item).State = EntityState.Modified;
            //    }
            //    dbcontext.SaveChanges();
            //}            
        }

        public UserTable getUser(int id)
        {
            //var sg = db.Users.GroupJoin(db.Departments, u => u.DepartmentId, d => d.DepartmentId, (u, d) => new { u, d }).Select(o => o).ToList();
            var sg=_dbcontext.UserTable.Join(_dbcontext.UnitTable, d => d.UnitTableId, p => p.Id, (d, p) => new { d, p }).Where(o => o.d.Id==id).ToList();
            return null;
        }
    }
}
