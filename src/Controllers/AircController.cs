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
        /// 无人机仓库
        /// </summary>
        public readonly IRepository<AircTable> _repository;
        ILog log = LogManager.GetLogger(Startup.Logrepository.Name, typeof(Startup));
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_db">注入数据仓库</param>
        public AircController(IRepository<AircTable> _db)
        {
            _repository = _db;
        }

        /// <summary>
        /// 添加无人机[支持批量]
        /// </summary>
        /// <param name="_airc">用户类</param>
        /// <returns></returns>
        [HttpPost("addMul")]
        public IActionResult Add([FromBody]List<AircTable> _airc)
        {
            try
            {
                int count=_repository.SaveList(_airc);
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
        /// 添加无人机返回无人机id
        /// </summary>
        /// <param name="_airc">无人机</param>
        /// <returns></returns>
        [HttpPost("addone")]
        public IActionResult Add([FromBody]AircTable _airc)
        {
            try
            {
                //return Ok(_repository.SaveGetId(_airc));
                int id = _repository.SaveGetId(_airc);
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
        /// 更新无人机[所有字段,支持批量]
        /// </summary>
        /// <param name="_airc">无人机类</param>
        /// <returns></returns>
        [HttpPost("UpdateList")]
        public IActionResult UpdateList([FromBody]List<AircTable> _airc)
        {
            try
            {
                //return Ok(_repository.UpdateList(_airc));
                int count = _repository.UpdateList(_airc);
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
        /// 删除指定Id无人机
        /// </summary>
        /// <param name="id">无人机ID</param>
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
        /// 批量删除无人机[根据无人机ID集合批量删除]
        /// </summary>
        /// <param name="_aircID">无人机列表</param>
        /// <returns></returns>
        [HttpDelete("delids")]
        public IActionResult DelByIds([FromBody]List<int> _aircID)
        {
            try
            {
                //return Ok(_repository.Delete(p => _aircID.Contains(p.Id)));
                int count = _repository.Delete(p => _aircID.Contains(p.Id));
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
        /// 批量删除无人机[根据无人机集合批量删除]
        /// </summary>
        /// <param name="_airc">无人机列表</param>
        /// <returns></returns>
        [HttpDelete("batchdel")]
        public IActionResult Batchdel([FromBody]List<AircTable> _airc)
        {
            try
            {
                //return Ok(_repository.DeleteList(_airc));
                int count = _repository.DeleteList(_airc);
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
        /// 根据无人机ID查询无人机
        /// </summary>
        /// <param name="id">无人机ID</param>
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
        /// 查询所有无人机
        /// </summary>
        /// <returns>返回所有无人机</returns>
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
