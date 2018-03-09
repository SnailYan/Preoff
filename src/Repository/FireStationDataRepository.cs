using Microsoft.EntityFrameworkCore;
using Preoff.Entity;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Preoff.Repository
{
    public sealed class FireStationDataRepository : RepositoryBase<FireStationDataTable>, IFireStationDataRepository
    {
        PreoffContext _dbcontext;
        public FireStationDataRepository(PreoffContext dbcontext) : base(dbcontext)
        {
            _dbcontext = dbcontext;
        }

 
        public IQueryable<ReturnEntity> GetEntity(string date, string hour)
        {
            IQueryable<ReturnEntity> r = _dbcontext.FireStationData.Where(p => p.CatDate == date && p.CatHour == hour).Select(x => new ReturnEntity {code=x.Code,firelevel=x.Firelevel});
            
            return r;
        }


    }
}
