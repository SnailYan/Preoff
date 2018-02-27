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
        /// <summary>
        /// 批量修改用户生日
        /// </summary>
        void BatchUpdateUserBirthday();
        UserTable getUser(int id);
    }
}
