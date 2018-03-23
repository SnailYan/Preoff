using Preoff.Entity;
using System.Linq;

namespace Preoff.Repository
{
    public sealed class EventRepository : RepositoryBase<EventTable>, IEventRepository
    {
        PreoffContext _dbcontext;
        public EventRepository(PreoffContext dbcontext) : base(dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public EventView Single(int id)
        {
            return _dbcontext.EventView.FirstOrDefault(p => p.Id == id);
        }
    }
}
