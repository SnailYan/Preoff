using Preoff.Entity;
using System.Linq;

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
            return _dbcontext.TaskView.FirstOrDefault(p => p.Id == id);
        }
    }
}
