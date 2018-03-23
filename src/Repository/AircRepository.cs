using Preoff.Entity;
using System.Linq;

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
            return _dbcontext.AircView.FirstOrDefault(p => p.Id == id);
        }
    }
}
