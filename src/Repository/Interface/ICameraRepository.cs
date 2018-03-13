using Preoff.Entity;

namespace Preoff.Repository
{
    /// <summary>
    /// 用户仓储接口
    /// </summary>
    public interface ICameraRepository : IRepository<CameraTable>
    {
        CameraView Single(int id);
    }
}
