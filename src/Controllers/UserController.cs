using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Preoff.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using log4net;
using Preoff.Repository;
using System.Linq.Expressions;
using Preoff.Comm;

namespace Preoff.Controllers
{
    /// <summary>
    /// 用户控制器
    /// </summary>
    //[Authorize]
    [Produces("application/json")]
    [Route("user")]
    public class UserController : Controller
    {
        public readonly IUserRepository _repository;
        ILog log = LogManager.GetLogger(Startup.Logrepository.Name, typeof(Startup));
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_db">注入数据仓库</param>
        public UserController(IUserRepository _db)
        {
            _repository = _db;
        }

        /// <summary>
        /// 添加用户[支持批量]
        /// </summary>
        /// <param name="_user">用户类</param>
        /// <returns></returns>
        [HttpPost("addMul")]
        public IActionResult Add([FromBody]List<UserTable> _user)
        {
            try
            {
                return Ok(_repository.SaveList(_user));
            }
            catch (Exception ex)
            {

                return Json(new
                {
                    code = "-1"
                });
            }
        }
        /// <summary>
        /// 更新用户[所有字段,支持批量]
        /// </summary>
        /// <param name="_user">用户类</param>
        /// <returns></returns>
        [HttpPost("UpdateList")]
        public IActionResult UpdateList([FromBody]List<UserTable> _user)
        {
            try
            {
                return Ok(_repository.UpdateList(_user));
            }
            catch (Exception ex)
            {

                return Json(new {code = "-1"});
            }
        }
        /// <summary>
        /// 删除指定Id用户
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <returns></returns>
        [HttpDelete("del/{id}")]
        public IActionResult Del(int id)
        {
            try
            {
                return Ok(_repository.Delete(p => p.Id == id));
            }
            catch (Exception ex)
            {

                return Json(new { code = "-1" });
            }
        }
        /// <summary>
        /// 批量删除用户[根据用户ID集合批量删除]
        /// </summary>
        /// <param name="_userID">用户列表</param>
        /// <returns></returns>
        [HttpDelete("delids")]
        public IActionResult DelByIds([FromBody]List<int> _userID)
        {
            try
            {
                return Ok(_repository.Delete(p=> _userID.Contains(p.Id)));
            }
            catch (Exception ex)
            {
                return Json(new { code = "-1" });
            }
        }
        /// <summary>
        /// 批量删除用户[根据用户集合批量删除]
        /// </summary>
        /// <param name="_user">用户列表</param>
        /// <returns></returns>
        [HttpDelete("batchdel")]
        public IActionResult Batchdel([FromBody]List<UserTable> _user)
        {
            try
            {
               return Ok(_repository.DeleteList(_user));
            }
            catch (Exception ex)
            {
                return Json(new { code = "-1" });
            }
        }
        /// <summary>
        /// 根据用户ID查询用户
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <returns></returns>
        [HttpGet("select/{id}")]
        public IActionResult Select(int id)
        {
            try
            {
                //return Ok(_repository.getUser(id));
                return Ok(_repository.Get(p => p.Id == id));
            }
            catch (Exception ex)
            {
                return Json(new { code = "-1" });
            }
        }
        /// <summary>
        /// 查询所有用户
        /// </summary>
        /// <returns>返回所有用户</returns>
        [HttpGet("selectall")]
        public IActionResult SelectAll()
        {
            try
            {
                return Ok(_repository.LoadListAll());
            }
            catch (Exception ex)
            {
                return Json(new { code = "-1" });
            }
           
        }

        [HttpPost("filter")]
        public IActionResult SelectPage(int pageindex, int pageSize, List<FilterStr> filter, string order, bool isAsc)
        {

            var builder = new ExpressionBuilder<UserTable>();//实例化组件
            var filters = new List<SqlFilter>();
            foreach (FilterStr item in filter)
            {
                filters.Add(SqlFilter.Create(item.Name, Operation.Equal, item.Value));
            }
            if (order != null && order.Trim() != string.Empty)
            {
                var type = typeof(UserTable);
                var propertyName = order;
                var param = Expression.Parameter(type, type.Name);
                var body = Expression.Property(param, propertyName);
                var keySelector = Expression.Lambda(body, param);
                switch (body.Type.Name.ToString())
                {
                    case "String":
                        if (filter.Count != 0)
                        {
                            var where = builder.Build(filters, new Dictionary<string, string>());
                            return Ok(_repository.Query<UserTable, string>(pageindex, pageSize, where, (Expression<Func<UserTable, string>>)keySelector, null, isAsc));
                        }
                        else
                        {
                            return Ok(_repository.Query<UserTable, string>(pageindex, pageSize, null, (Expression<Func<UserTable, string>>)keySelector, null, isAsc));
                        }
                    case "Int32":
                        if (filter.Count != 0)
                        {
                            var where = builder.Build(filters, new Dictionary<string, string>());
                            return Ok(_repository.Query<UserTable, Int32>(pageindex, pageSize, where, (Expression<Func<UserTable, Int32>>)keySelector, null, isAsc));
                        }
                        else
                        {
                            return Ok(_repository.Query<UserTable, Int32>(pageindex, pageSize, null, (Expression<Func<UserTable, Int32>>)keySelector, null, isAsc));
                        }
                    case "System.DateTime":
                        if (filter.Count != 0)
                        {
                            var where = builder.Build(filters, new Dictionary<string, string>());
                            return Ok(_repository.Query<UserTable, DateTime>(pageindex, pageSize, where, (Expression<Func<UserTable, DateTime>>)keySelector, null, isAsc));
                        }
                        else
                        {
                            return Ok(_repository.Query<UserTable, DateTime>(pageindex, pageSize, null, (Expression<Func<UserTable, DateTime>>)keySelector, null, isAsc));
                        }
                    case "Double":
                        if (filter.Count != 0)
                        {
                            var where = builder.Build(filters, new Dictionary<string, string>());
                            return Ok(_repository.Query<UserTable, double>(pageindex, pageSize, where, (Expression<Func<UserTable, double>>)keySelector, null, isAsc));
                        }
                        else
                        {
                            return Ok(_repository.Query<UserTable, double>(pageindex, pageSize, null, (Expression<Func<UserTable, double>>)keySelector, null, isAsc));
                        }
                    default:
                        break;
                }

                return Ok("-1");
            }
            else
            {
                return Ok(_repository.Query<UserTable, string>(pageindex, pageSize, null, null, null, isAsc));
            }
        }

        //[HttpGet("{page}")]
        //public async Task<IActionResult> pages(int? page)
        //{
        //    if (page<1)
        //    {
        //        return BadRequest();
        //    }
        //    var _user = from s in _dbContext.Tuser
        //                select s;

        //    return Ok(await PaginatedList<Tuser>.CreateAsync(_user.AsNoTracking(), page ?? 1, 10));
        //}

        //[HttpGet("{page}")]
        //public async Task<IActionResult> SelectPage(string sortOrder, string currentFilter, string searchString, int? page)
        //{
        //    if (searchString != null)
        //    {
        //        page = 1;
        //    }
        //    else
        //    {
        //        searchString = currentFilter;
        //    }
        //    var _user = from s in _dbContext.UserTable
        //                select s;
        //    if (!String.IsNullOrEmpty(searchString))
        //    {
        //        _user = _user.Where(s => s.RealName.Contains(searchString)
        //                               || s.ViewName.Contains(searchString));
        //    }
        //    switch (sortOrder)
        //    {
        //        case "name_desc":
        //            _user = _user.OrderByDescending(s => s.Id);
        //            break;
        //        case "Date":
        //            _user = _user.OrderBy(s => s.RegTime);
        //            break;
        //        case "date_desc":
        //            _user = _user.OrderByDescending(s => s.RegTime);
        //            break;
        //        default:
        //            _user = _user.OrderBy(s => s.LoginName);
        //            break;
        //    }

        //    int pageSize = 3;
        //    return Ok(await PaginatedList<UserTable>.CreateAsync(_user.AsNoTracking(), page ?? 1, pageSize));
        //}
    }
}

