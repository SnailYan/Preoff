using Microsoft.EntityFrameworkCore;
using Preoff.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Preoff.Repository
{
    public sealed class TaskRepository : RepositoryBase<TaskTable>, ITaskRepository
    {
        PreoffContext _dbcontext;
        public TaskRepository(PreoffContext dbcontext) : base(dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public TaskView Single(int id)
        {
            return _dbcontext.TaskView.SingleOrDefault(p => p.Id == id);
        }
    }
}
