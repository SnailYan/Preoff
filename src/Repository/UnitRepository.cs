using Microsoft.EntityFrameworkCore;
using Preoff.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Preoff.Repository
{
    public sealed class UnitRepository : RepositoryBase<UnitTable>, IUnitRepository
    {
        PreoffContext _dbcontext;
        public UnitRepository(PreoffContext dbcontext) : base(dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public UnitView Single(int id)
        {
            return _dbcontext.UnitView.FirstOrDefault(p => p.Id == id);
        }
    }
}
