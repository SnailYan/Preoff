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
    }
}
