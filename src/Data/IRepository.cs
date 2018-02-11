using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Preoff.Data
{
    public interface IRepository<T> where T : class, new()
    {
        /// <summary>
        /// 创建对象
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        T Create(T model);

        /// <summary>
        /// 更新对象
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        T Update(T model);

        /// <summary>
        /// 根据对象全局唯一标识检索对象
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        T Retrieve(int guid);


        /// <summary>
        /// 根据条件表达式检索对象
        /// </summary>
        /// <param name="expression">条件表达式</param>
        /// <returns></returns>
        /// <exception cref = "ArgumentNullException" > source 为 null</exception>
        T Retrieve(Expression<Func<T, bool>> expression);

        /// <summary>
        /// 根据对象全局唯一标识删除对象
        /// </summary>
        /// <param name="guid">对象全局唯一标识</param>
        /// <returns>删除的对象数量</returns>
        int Delete(int guid);

        /// <summary>
        /// 根据对象全局唯一标识集合删除对象集合
        /// </summary>
        /// <param name="guids">全局唯一标识集合</param>
        /// <returns>删除的对象数量</returns>
        int BatchDelete(IList<int> guids);
        /// <summary>
        /// 获取所有对象
        /// </summary>
        /// <returns></returns>
        List<T> GetAll();
        /// <summary>
        /// 按条件获取对象
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="sortPredicate"></param>
        /// <param name="sortOrder"></param>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        List<T> GetAll(Expression<Func<T, bool>> expression, Expression<Func<T, dynamic>> sortPredicate, SortOrder sortOrder, int skip, int take, out int total);
    }

    //public interface IRepository<T>
    //where T : class
    //{
    //    /// <summary>  
    //    /// 获取所有实体对象  
    //    /// </summary>  
    //    /// <returns></returns>  
    //    IQueryable<T> All();

    //    /// <summary>  
    //    /// 根据Lamda表达式来查询实体对象  
    //    /// </summary>  
    //    /// <param name="whereLambda"></param>  
    //    /// <returns></returns>  
    //    IQueryable<T> Where(Expression<Func<T, bool>> whereLambda);

    //    /// <summary>  
    //    /// 获取所有实体数量  
    //    /// </summary>  
    //    /// <returns></returns>  
    //    int Count();

    //    /// <summary>  
    //    /// 根据表达式获取实体数量  
    //    /// </summary>  
    //    /// <param name="whereLambda"></param>  
    //    /// <returns></returns>  
    //    int Count(Expression<Func<T, bool>> whereLambda);

    //    /// <summary>  
    //    /// 实体对象新增  
    //    /// </summary>  
    //    /// <param name="model"></param>  
    //    /// <returns></returns>  
    //    int Add(T model, bool IsCommit = false);

    //    /// <summary>  
    //    /// 实体对象修改  
    //    /// </summary>  
    //    /// <param name="model"></param>  
    //    /// <returns></returns>  
    //    int Update(T model, bool IsCommit = false);

    //    /// <summary>  
    //    /// 实体对象根据字段修改  
    //    /// </summary>  
    //    /// <param name="model"></param>  
    //    /// <param name="proName"></param>  
    //    /// <returns></returns>  
    //    int Update(T model, bool IsCommit = false, params string[] proName);

    //    /// <summary>  
    //    /// 实体对象删除  
    //    /// </summary>  
    //    /// <param name="model"></param>  
    //    /// <returns></returns>  
    //    int Delete(T model, bool IsCommit = false);

    //    /// <summary>  
    //    /// 删除复核条件的多个实体对象  
    //    /// </summary>  
    //    /// <param name="whereLambda"></param>  
    //    /// <returns></returns>  
    //    int Delete(Expression<Func<T, bool>> whereLambda, bool IsCommit = false);
    //}
}
