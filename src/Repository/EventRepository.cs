using Microsoft.EntityFrameworkCore;
using Preoff.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            return _dbcontext.EventView.SingleOrDefault(p => p.Id == id);
        }
    }
}
