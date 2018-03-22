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
    public sealed class HotsPotsRepository : RepositoryBase<HotsPotsTable>, IHotsPotsRepository
    {
        PreoffContext _dbcontext;
        public HotsPotsRepository(PreoffContext dbcontext) : base(dbcontext)
        {
            _dbcontext = dbcontext;
        }

 
        public IQueryable<HotsPotsTable> GetEntity(string date)
        {
            DateTime x = DateTime.ParseExact(date, "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture);
            //IQueryable<HotsPotsTable> r = _dbcontext.FireStationData.Where(p => p.CatDate == date).Select(x => new ReturnEntity {code=x.Code,firelevel=x.Firelevel});
            IQueryable<HotsPotsTable> r = _dbcontext.HotsPotsTable.Where(p =>p.ReceiveTime.Value.Date==x.Date);
            
            return r;
        }


    }
}
