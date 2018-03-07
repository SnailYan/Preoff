using Microsoft.EntityFrameworkCore;
using Preoff.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Preoff.Repository
{
    public sealed class UserRepository : RepositoryBase<UserTable>, IUserRepository
    {
        PreoffContext _dbcontext;
        public UserRepository(PreoffContext dbcontext) : base(dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public override int UpdateList(List<UserTable> t)
        {
            if (t.Count <= 0) return 0;
            try
            {
                foreach (var item in t)
                {
                    UserTable _temp=_dbcontext.UserTable.FirstOrDefault(p => p.Id == item.Id);
                    _temp.Birthday = item.Birthday;
                    _temp.Email = item.Email;
                    _temp.Gender = item.Gender;
                    _temp.RealName = item.RealName;
                    _temp.Telephone = item.Telephone;
                    _temp.ViewName = item.ViewName;
                    _dbcontext.Update(_temp);
                }
                return _dbcontext.SaveChanges();
            }
            catch (Exception e) { throw e; }
        }

        public UserView Single(int id)
        {
            UserView userView = _dbcontext.UserView.SingleOrDefault(p => p.Id == id);
            //if (userView!=null)
            //{
            //    userView.LoginPwd = "********";
            //}
            return userView;
        }
    }
}
