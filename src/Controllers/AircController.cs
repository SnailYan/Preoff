using log4net;
using Microsoft.AspNetCore.Mvc;
using Preoff.Entity;
using Preoff.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Preoff.Controllers
{
    /// <summary>
    /// 无人机控制器
    /// </summary>
    //[Authorize]
    [Produces("application/json")]
    [Route("Airc")]
    public class AircController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        public readonly IRepository<AircTable> _aircRepository;
        ILog log = LogManager.GetLogger(Startup.Logrepository.Name, typeof(Startup));
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_db">注入数据库配置</param>
        public AircController(IRepository<AircTable> _db)
        {
            _aircRepository = _db;
        }

        /// <summary>
        /// 添加无人机[支持批量]
        /// </summary>
        /// <param name="_user">用户类</param>
        /// <returns>执行成功则返回添加成功记录条数，失败返回-1</returns>
        [HttpPost("add")]
        public IActionResult Add([FromBody]List<AircTable> _user)
        {
            try
            {
                return Ok(_aircRepository.SaveList(_user));
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
        public IActionResult UpdateList([FromBody]List<AircTable> _user)
        {
            try
            {
                return Ok(_aircRepository.UpdateList(_user));
            }
            catch (Exception ex)
            {

                return Json(new { code = "-1" });
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
                return Ok(_aircRepository.Delete(p => p.Id == id));
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
                return Ok(_aircRepository.Delete(p => _userID.Contains(p.Id)));
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
        public IActionResult Batchdel([FromBody]List<AircTable> _user)
        {
            try
            {
                return Ok(_aircRepository.DeleteList(_user));
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
                return Ok(_aircRepository.Get(p => p.Id == id));
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
                return Ok(_aircRepository.LoadListAll());
            }
            catch (Exception ex)
            {
                return Json(new { code = "-1" });
            }

        }
    }
}
