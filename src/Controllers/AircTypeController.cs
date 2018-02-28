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
    [Route("AircType")]
    public class AircTypeController : Controller
    {
        /// <summary>
        /// 无人机类型仓库
        /// </summary>
        public readonly IRepository<AircTypeTable> _repository;
        ILog log = LogManager.GetLogger(Startup.Logrepository.Name, typeof(Startup));
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_db">注入数据仓库</param>
        public AircTypeController(IRepository<AircTypeTable> _db)
        {
            _repository = _db;
        }

        /// <summary>
        /// 添加无人机类型[支持批量]
        /// </summary>
        /// <param name="_aircType">无人机类型类</param>
        /// <returns></returns>
        [HttpPost("addMul")]
        public IActionResult Add([FromBody]List<AircTypeTable> _aircType)
        {
            try
            {
                int count=_repository.SaveList(_aircType);
                return Json(new
                {
                    count,
                    state = "0",
                    msg = "操作成功！"
                });
                //return Ok(_repository.SaveList(_airc));
            }
            catch (Exception ex)
            {

                return Json(new
                {
                    state = "-1",
                    msg = "非法操作！"
                });
            }
        }
        /// <summary>
        /// 添加无人机类型返回无人机类型id
        /// </summary>
        /// <param name="_aircType">无人机类型类</param>
        /// <returns></returns>
        [HttpPost("addone")]
        public IActionResult Add([FromBody]AircTypeTable _aircType)
        {
            try
            {
                //return Ok(_repository.SaveGetId(_airc));
                int id = _repository.SaveGetId(_aircType);
                return Json(new
                {
                    id,
                    state = "0",
                    msg = "添加成功！"
                });
            }
            catch (Exception ex)
            {

                return Json(new
                {
                    state = "-1",
                    msg = "非法操作！"
                });
            }
        }
        /// <summary>
        /// 更新无人机类型[所有字段,支持批量]
        /// </summary>
        /// <param name="_aircType">无人机类型类</param>
        /// <returns></returns>
        [HttpPost("UpdateList")]
        public IActionResult UpdateList([FromBody]List<AircTypeTable> _aircType)
        {
            try
            {
                //return Ok(_repository.UpdateList(_airc));
                int count = _repository.UpdateList(_aircType);
                return Json(new
                {
                    count,
                    state = "0",
                    msg = "操作成功！"
                });
            }
            catch (Exception ex)
            {

                return Json(new {
                    state = "-1",
                    msg = "非法操作！"
                });
            }
        }
        /// <summary>
        /// 删除指定Id无人机类型
        /// </summary>
        /// <param name="id">无人机类型ID</param>
        /// <returns></returns>
        [HttpDelete("del/{id}")]
        public IActionResult Del(int id)
        {
            try
            {
                //return Ok(_repository.Delete(p => p.Id == id));
                int count = _repository.Delete(p => p.Id == id);
                return Json(new
                {
                    count,
                    state = "0",
                    msg = "操作成功！"
                });
            }
            catch (Exception ex)
            {
                return Json(new {
                    state = "-1",
                    msg = "非法操作！"
                });
            }
        }
        /// <summary>
        /// 批量删除无人机类型[根据无人机类型ID集合批量删除]
        /// </summary>
        /// <param name="_aircTypeID">无人机类型类</param>
        /// <returns></returns>
        [HttpDelete("delids")]
        public IActionResult DelByIds([FromBody]List<int> _aircTypeID)
        {
            try
            {
                //return Ok(_repository.Delete(p => _aircID.Contains(p.Id)));
                int count = _repository.Delete(p => _aircTypeID.Contains(p.Id));
                return Json(new
                {
                    count,
                    state = "0",
                    msg = "操作成功！"
                });
            }
            catch (Exception ex)
            {
                return Json(new {
                    state = "-1",
                    msg = "非法操作！"
                });
            }
        }
        /// <summary>
        /// 批量删除无人机类型[根据无人机类型集合批量删除]
        /// </summary>
        /// <param name="_aircType">无人机类型类</param>
        /// <returns></returns>
        [HttpDelete("batchdel")]
        public IActionResult Batchdel([FromBody]List<AircTypeTable> _aircType)
        {
            try
            {
                //return Ok(_repository.DeleteList(_airc));
                int count = _repository.DeleteList(_aircType);
                return Json(new
                {
                    count,
                    state = "0",
                    msg = "操作成功！"
                });
            }
            catch (Exception ex)
            {
                return Json(new {
                    state = "-1",
                    msg = "非法操作！"
                });
            }
        }
        /// <summary>
        /// 根据无人机类型ID查询无人机类型
        /// </summary>
        /// <param name="id">无人机类型ID</param>
        /// <returns></returns>
        [HttpGet("select/{id}")]
        public IActionResult Select(int id)
        {
            try
            {
                //return Ok(_repository.Get(p => p.Id == id));
                return Json(new
                {
                    table= _repository.Get(p => p.Id == id),
                    state = "0",
                    msg = "操作成功！"
                });
            }
            catch (Exception ex)
            {
                return Json(new {
                    state = "-1",
                    msg = "非法操作！"
                });
            }
        }
        /// <summary>
        /// 查询所有无人机类型
        /// </summary>
        /// <returns>返回所有无人机类型</returns>
        [HttpGet("selectall")]
        public IActionResult SelectAll()
        {
            try
            {
                //return Ok(_repository.LoadListAll());
                return Json(new
                {
                    table = _repository.LoadListAll(),
                    state = "0",
                    msg = "操作成功!"
                });
            }
            catch (Exception ex)
            {
                return Json(new {
                    state = "-1",
                    msg = "非法操作！"
                });
            }

        }
    }
}
