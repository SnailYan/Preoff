using Microsoft.EntityFrameworkCore;
using Preoff.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Preoff.Repository
{
    public sealed class CameraRepository : RepositoryBase<CameraTable>, ICameraRepository
    {
        PreoffContext _dbcontext;
        public CameraRepository(PreoffContext dbcontext) : base(dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public CameraView Single(int id)
        {
            return _dbcontext.CameraView.SingleOrDefault(p => p.Id == id);
        }
    }
}
