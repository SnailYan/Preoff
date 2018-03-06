using Microsoft.EntityFrameworkCore;
using Preoff.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Preoff.Repository
{
    public sealed class AircRepository : RepositoryBase<AircTable>, IAircRepository
    {
        PreoffContext _dbcontext;
        public AircRepository(PreoffContext dbcontext) : base(dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public AircView Single(int id)
        {
            return _dbcontext.AircView.SingleOrDefault(p => p.Id == id);
        }
    }
}
