using Microsoft.EntityFrameworkCore;
using Preoff.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Preoff.Repository
{
    public sealed class CameraTypeRepository : RepositoryBase<CameraTypeTable>, ICameraTypeRepository
    {
        PreoffContext _dbcontext;
        public CameraTypeRepository(PreoffContext dbcontext) : base(dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public CameraTypeView Single(int id)
        {
            return _dbcontext.CameraTypeView.FirstOrDefault(p => p.Id == id);
        }
    }
}
