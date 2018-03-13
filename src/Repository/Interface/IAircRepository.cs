using Preoff.Entity;

namespace Preoff.Repository
{
    /// <summary>
    /// 用户仓储接口
    /// </summary>
    public interface IAircRepository : IRepository<AircTable>
    {
        AircView Single(int id);
    }
}
