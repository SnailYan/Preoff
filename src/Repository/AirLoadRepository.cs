using Microsoft.EntityFrameworkCore;
using Preoff.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Preoff.Repository
{
    public sealed class AirLoadRepository : RepositoryBase<AirLoadTable>, IAirLoadRepository
    {
        PreoffContext _dbcontext;
        public AirLoadRepository(PreoffContext dbcontext) : base(dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public AirLoadView Single(int id)
        {
            return _dbcontext.AirLoadView.FirstOrDefault(p => p.Id == id);
        }
    }
}
