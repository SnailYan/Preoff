﻿using Preoff.Entity;
using System.Linq;

namespace Preoff.Repository
{
    public sealed class UserRepository : RepositoryBase<UserTable>, IUserRepository
    {
        PreoffContext _dbcontext;
        public UserRepository(PreoffContext dbcontext) : base(dbcontext)
        {
            _dbcontext = dbcontext;
        }
        //public override int UpdateList(List<UserTable> t)
        //{           
        //    if (t.Count <= 0) return 0;
        //    try
        //    {
        //        foreach (var item in t)
        //        {
        //            UserTable _temp=_dbcontext.UserTable.FirstOrDefault(p => p.Id == item.Id);
        //            if (_temp!=null)
        //            {
        //                bool isE=_dbcontext.UserTable.Where(p => p.ViewName == item.ViewName).Any();
        //                //UserTable _re = _dbcontext.UserTable.FirstOrDefault(p => p.ViewName == item.ViewName);
        //                if (!isE)
        //                {
        //                    _temp.Birthday = item.Birthday;
        //                    _temp.Email = item.Email;
        //                    _temp.Gender = item.Gender;
        //                    _temp.RealName = item.RealName;
        //                    _temp.Telephone = item.Telephone;
        //                    _temp.ViewName = item.ViewName;
        //                    _dbcontext.Update(_temp);
        //                }

        //            }                   
        //        }
        //        return _dbcontext.SaveChanges();
        //    }
        //    catch (Exception e) { throw e; }
        //}
        //public override int SaveList(List<UserTable> t)
        //{
        //    try
        //    {
        //        DbSet.Local.Clear();
        //        foreach (var item in t)
        //        {
        //            DbSet.Add(item);
        //        }
        //        return _dbcontext.SaveChanges();
        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //    }
        //}
        public UserView Single(int id)
        {
            UserView userView = _dbcontext.UserView.FirstOrDefault(p => p.Id == id);
            //if (userView!=null)
            //{
            //    userView.LoginPwd = "********";
            //}
            return userView;
        }
    }
}
