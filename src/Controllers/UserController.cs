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
        /// <param name="_db">注入数据库配置</param>
        public UserController(IUserRepository _db)
        {
            _repository = _db;
        }

        /// <summary>
        /// 添加用户[支持批量]
        /// </summary>
        /// <param name="_user">用户类</param>
        /// <returns></returns>
        [HttpPost("add")]
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

