using Microsoft.EntityFrameworkCore;
using Preoff.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Preoff.Repository
{
    public sealed class ExecTaskRepository : RepositoryBase<ExecTaskTable>, IExecTaskRepository
    {
        PreoffContext _dbcontext;
        public ExecTaskRepository(PreoffContext dbcontext) : base(dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public ExecTaskView Single(int id)
        {
            return _dbcontext.ExecTaskView.SingleOrDefault(p => p.Id == id);
        }
    }
}
