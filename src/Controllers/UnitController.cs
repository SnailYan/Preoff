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
    /// 单位控制器
    /// </summary>
    //[Authorize]
    [Produces("application/json")]
    [Route("Unit")]
    public class UnitController : Controller
    {
        /// <summary>
        /// 单位仓库
        /// </summary>
        public readonly IRepository<UnitTable> _repository;
        ILog log = LogManager.GetLogger(Startup.Logrepository.Name, typeof(Startup));
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_db">注入数据仓库</param>
        public UnitController(IRepository<UnitTable> _db)
        {
            _repository = _db;
        }

        /// <summary>
        /// 添加单位[支持批量]
        /// </summary>
        /// <param name="_user">单位类</param>
        /// <returns></returns>
        [HttpPost("addMul")]
        public IActionResult Add([FromBody]List<UnitTable> _user)
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

        [HttpPost("addone")]
        public IActionResult Add([FromBody]UnitTable _user)
        {
            try
            {
                return Ok(_repository.SaveGetId(_user));
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
        /// 更新单位[所有字段,支持批量]
        /// </summary>
        /// <param name="_user">单位类</param>
        /// <returns></returns>
        [HttpPost("UpdateList")]
        public IActionResult UpdateList([FromBody]List<UnitTable> _user)
        {
            try
            {
                return Ok(_repository.UpdateList(_user));
            }
            catch (Exception ex)
            {

                return Json(new { code = "-1" });
            }
        }
        /// <summary>
        /// 删除指定Id单位
        /// </summary>
        /// <param name="id">单位ID</param>
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
        /// 批量删除单位[根据单位ID集合批量删除]
        /// </summary>
        /// <param name="_userID">单位列表</param>
        /// <returns></returns>
        [HttpDelete("delids")]
        public IActionResult DelByIds([FromBody]List<int> _userID)
        {
            try
            {
                return Ok(_repository.Delete(p => _userID.Contains(p.Id)));
            }
            catch (Exception ex)
            {
                return Json(new { code = "-1" });
            }
        }
        /// <summary>
        /// 批量删除单位[根据单位集合批量删除]
        /// </summary>
        /// <param name="_user">单位列表</param>
        /// <returns></returns>
        [HttpDelete("batchdel")]
        public IActionResult Batchdel([FromBody]List<UnitTable> _user)
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
        /// 根据单位ID查询单位
        /// </summary>
        /// <param name="id">单位ID</param>
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
        /// 查询所有单位
        /// </summary>
        /// <returns>返回所有单位</returns>
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
    }
}
