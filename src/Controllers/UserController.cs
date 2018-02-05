using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Preoff.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using log4net;

namespace Preoff.Controllers
{
    /// <summary>
    /// 用户类控制器
    /// </summary>
    //[Authorize]
    [Produces("application/json")]
    [Route("user")]
    public class UserController : Controller
    {
        private JwtSettings _jwtSettings;
        private CoreTestContext _dbContext;
        ILog log = LogManager.GetLogger(Startup.repository.Name, typeof(Startup));
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_jwtSettingsAccesser">注入Jwt认证</param>
        /// <param name="_db">注入数据库配置</param>
        public UserController(IOptions<JwtSettings> _jwtSettingsAccesser,CoreTestContext _db)
        {
            _jwtSettings = _jwtSettingsAccesser.Value;
            _dbContext = _db;
        }
        /// <summary>
        /// 添加用户[支持批量]
        /// </summary>
        /// <param name="_user">用户类</param>
        /// <returns>执行成功则返回添加成功记录条数，失败返回0</returns>
        [HttpPost("add")]
        public IActionResult Add([FromBody]List<Tuser> _user)
        {
            if (_user is null || _user.Count==0)
            {
                return Json(new { code = "-1", msg = "添加失败,数据为空或不合法!" });
            }
            foreach (Tuser user in _user)
            {
                user.Id = 0;
                _dbContext.Database.EnsureCreated();
                _dbContext.Tuser.Add(user);                
            }
            int x = _dbContext.SaveChanges();
            //return Ok(x);
            return Json(new { code = "0", msg = "添加成功!共添加"+x.ToString()+"条数据。" });
        }
        /// <summary>
        /// 更新用户[所有字段,支持批量]
        /// </summary>
        /// <param name="_user">用户类</param>
        /// <returns></returns>
        [HttpPost("modify")]
        public IActionResult Modify([FromBody]List<Tuser> _user)
        {
            if (_user is null || _user.Count == 0)
            {
                return Json(new { code = "-1", msg = "修改失败,数据为空或不合法!" });
            }
            foreach (Tuser user in _user)
            {
                ////更新全部字段
                _dbContext.Tuser.Update(user);
                //更新部分字段
                // db.Tuser.Single(u => u.Id == _user.Id).CName = _user.CName;                
            }
            int x = _dbContext.SaveChanges();
            //return Ok(x);
            return Json(new { code = "0", msg = "更新成功,共更新"+x.ToString()+"条数据。" });
        }
        /// <summary>
        /// 删除指定Id用户
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <returns></returns>
        [HttpDelete("del/{id}")]
        public IActionResult Del(int id)
        {
            Tuser user = _dbContext.Tuser.SingleOrDefault(u => u.Id == id);
            if (user is null)
            {
                return Json(new { code = "-1", msg = "删除失败,数据不存在或不合法!" });
            }
            else
            {
                _dbContext.Tuser.Remove(user);
                //return Ok(_dbContext.SaveChanges());
                return Json(new { code = "0", msg = "删除成功,共删除" + _dbContext.SaveChanges() + "条数据。" });
            }
        }

        /// <summary>
        /// 批量删除用户[根据ID号批量删除]
        /// </summary>
        /// <param name="_userID">用户列表</param>
        /// <returns></returns>
        [HttpDelete("delMul")]
        public IActionResult DelMul([FromBody]List<int> _userID)
        {
            //Tuser user = _dbContext.Tuser.SingleOrDefault(u => u.Id == id);
            if (_userID is null || _userID.Count<1)
            {
                return Json(new { code = "-1", msg = "删除失败,数据为空或不合法!" });
            }
            else
            {
                var user=_dbContext.Tuser.Where(r => _userID.Contains(r.Id)).ToList();
                if (user.Count>0)
                {
                    _dbContext.Tuser.RemoveRange(user);
                    //return _dbContext.SaveChanges();
                    return Json(new { code = "0", msg = "删除成功,共删除" + _dbContext.SaveChanges() + "条数据。" });
                }
                else
                {
                    return Json(new { code = "-1", msg = "id不存在!" });
                }
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
            //根据id查询
            Tuser user = _dbContext.Tuser.SingleOrDefault(u => u.Id == id);

            //根据name过滤查询
            //var user = db.Tuser
            //        .Where(u => u.Name.Contains("test"))
            //        .First();
            if (user is null)
            {
                return Json(new { code = "-1", msg = "ID不存在" });
            }
            return Ok(user);
        }
        /// <summary>
        /// 查询所有用户
        /// </summary>
        /// <returns>返回所有用户</returns>
        [HttpGet("selectall")]
        public IActionResult SelectAll()
        {
            var user = _dbContext.Tuser.ToList();
            return Ok(user);
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
        //public async Task<IActionResult> SelectPage(string sortOrder,string currentFilter,string searchString,int? page)
        //{
        //    if (searchString != null)
        //    {
        //        page = 1;
        //    }
        //    else
        //    {
        //        searchString = currentFilter;
        //    }
        //    var _user = from s in _dbContext.Tuser
        //                   select s;
        //    if (!String.IsNullOrEmpty(searchString))
        //    {
        //        _user = _user.Where(s => s.CName.Contains(searchString)
        //                               || s.CValue.Contains(searchString));
        //    }
        //    switch (sortOrder)
        //    {
        //        case "name_desc":
        //            _user = _user.OrderByDescending(s => s.CName);
        //            break;
        //        case "Date":
        //            _user = _user.OrderBy(s => s.CValue);
        //            break;
        //        case "date_desc":
        //            _user = _user.OrderByDescending(s => s.CValue);
        //            break;
        //        default:
        //            _user = _user.OrderBy(s => s.CName);
        //            break;
        //    }

        //    int pageSize = 3;
        //    return Ok(await PaginatedList<Tuser>.CreateAsync(_user.AsNoTracking(), page ?? 1, pageSize));
        //}
    }
}

