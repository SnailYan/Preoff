using Microsoft.EntityFrameworkCore;
using Preoff.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Preoff.Data
{
    public class ImplRepository<T> : IRepository<T> where T : class, new()
    {
        private CoreTestContext _dbContext;

        protected ImplRepository(CoreTestContext _db)
        {
            _dbContext = _db;
        }

        public virtual int BatchDelete(IList<Guid> guids)
        {
            foreach (var item in guids)
            {
                var model = _dbContext.Set<T>().Find(item);
                _dbContext.Entry(model).State = EntityState.Deleted;
            }
            return _dbContext.SaveChanges();
        }

        public virtual T Create(T model)
        {
            _dbContext.Entry(model).State = EntityState.Added;
            var createRowCount = _dbContext.SaveChanges();
            return createRowCount > 0 ? model : null;
        }

        /// <summary>
        /// 删除模型
        /// </summary>
        /// <param name="guid">指定的全局标识</param>
        /// <returns>删除数量</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public virtual int Delete(Guid guid)
        {
            var model = _dbContext.Set<T>().Find(guid);
            if (model == null) throw new ArgumentOutOfRangeException(nameof(guid));
            _dbContext.Entry(model).State = EntityState.Deleted;
            return _dbContext.SaveChanges();
        }

        public virtual List<T> GetAll()
        {
            return _dbContext.Set<T>().Where(q => true).ToList();
        }

        public virtual List<T> GetAll(Expression<Func<T, bool>> expression, Expression<Func<T, dynamic>> sortPredicate, SortOrder sortOrder, int skip, int take, out int total)
        {

            total = _dbContext.Set<T>().Where(expression).Count();
            switch (sortOrder)
            {
                case SortOrder.Ascending:
                    return _dbContext.Set<T>().Where(expression).OrderBy(sortPredicate).Skip(skip).Take(take).ToList();

                case SortOrder.Descending:
                    return _dbContext.Set<T>().Where(expression).OrderByDescending(sortPredicate).Skip(skip).Take(take).ToList();

            }
            throw new InvalidOperationException("基于分页功能的查询必须指定排序字段和排序顺序。");
        }

        /// <summary>
        /// 返回序列中的第一个元素
        /// </summary>
        /// <param name="expression">查询表达式</param>
        /// <returns>T</returns>
        /// <exception cref="ArgumentNullException">source 为 null</exception>
        public virtual T Retrieve(Expression<Func<T, bool>> expression)
        {
            return _dbContext.Set<T>().FirstOrDefault(expression);
        }

        public virtual T Retrieve(Guid guid)
        {
            return _dbContext.Set<T>().Find(guid);
        }

        public virtual T Update(T model)
        {
            _dbContext.Entry(model).State = EntityState.Modified;
            var updateRowAcount = _dbContext.SaveChanges();
            return updateRowAcount > 0 ? model : null;
        }
    }

}
