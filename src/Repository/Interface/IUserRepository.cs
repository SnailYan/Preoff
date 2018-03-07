using Preoff.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Preoff.Repository
{
    /// <summary>
    /// 用户仓储接口
    /// </summary>
    public interface IUserRepository : IRepository<UserTable>
    {
        int UpdateList(List<UserTable> _user);
        UserView Single(int id);
        int SaveList(List<UserTable> _user);
    }
}
