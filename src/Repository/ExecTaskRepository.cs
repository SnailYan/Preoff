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
            return _dbcontext.ExecTaskView.FirstOrDefault(p => p.Id == id);
        }
        public bool UpdateStatus(int execTaskId, int statusId, DateTime endTime)
        {
            ExecTaskTable _etable = _dbcontext.ExecTaskTable.FirstOrDefault(p => p.Id == execTaskId);
            if (_etable!=null)
            {
                _etable.TaskStateTableId = statusId;
                if (endTime!=null && endTime.Year!=1)
                {
                    _etable.EndTime = endTime;
                }                
                var entity =_dbcontext.Entry(_etable);
                entity.State = EntityState.Modified;
                int row=_dbcontext.SaveChanges();
                entity.State = EntityState.Detached;
                return row==1;
            }
            else
            {
                return false;
            }
        }
    }
}
