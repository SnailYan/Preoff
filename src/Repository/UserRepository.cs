using Microsoft.EntityFrameworkCore;
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

        public Object GetTask(int id)
        {
            //var xxx=_dbcontext.Database.ExecuteSqlCommand("select * from dbo.VTaskTable");
            //IQueryable<ViewTask> iQueryTable = _dbcontext.Set<ViewTask>().FromSql("select * from dbo.VTaskTable");
            //_dbcontext.Database.SqlQuery<ViewTask>("select * from dbo.YourView");
            var myList = _dbcontext.TaskTable
                .Join(
                    _dbcontext.TaskUserTable, 
                    a => a.Id, 
                    b => b.TaskTableId, 
                    (a, b) => new{task = a,taskUser = b })
                .Join(
                    _dbcontext.UserTable.Where(c => c.Id == id),
                    d => d.taskUser.UserTableId,
                    c => c.Id,
                    (d, c) => new { d.task, d.taskUser, IndustryCode = c.Id })
                .Select(c => new {
                    c.task.Id,                
                    c.task.TaskName,                
                    c.task.TaskTypeTableId,
                    c.task.UserTableId,
                    c.task.PubTime,
                    c.task.EndTime,
                    c.task.TaskDesc,
                    c.task.TaskStateTableId
                });
            return myList;
        }

        public UserTable getUser(int id)
        {
            //var sg = db.Users.GroupJoin(db.Departments, u => u.DepartmentId, d => d.DepartmentId, (u, d) => new { u, d }).Select(o => o).ToList();
            var sg=_dbcontext.UserTable.Join(_dbcontext.UnitTable, d => d.UnitTableId, p => p.Id, (d, p) => new { d, p }).Where(o => o.d.Id==id).ToList();
            return null;
        }
    }
}
