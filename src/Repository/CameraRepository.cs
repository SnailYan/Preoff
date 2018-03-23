using Preoff.Entity;
using System.Linq;

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
            return _dbcontext.CameraView.FirstOrDefault(p => p.Id == id);
        }
    }
}
