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
    /// 事件控制器
    /// </summary>
    //[Authorize]
    [Produces("application/json")]
    [Route("Event")]
    public class EventController : Controller
    {
        /// <summary>
        /// 事件仓库
        /// </summary>
        public readonly IRepository<EventTable> _repository;
        ILog log = LogManager.GetLogger(Startup.Logrepository.Name, typeof(Startup));
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_db">注入数据仓库</param>
        public EventController(IRepository<EventTable> _db)
        {
            _repository = _db;
        }

        /// <summary>
        /// 添加事件[支持批量]
        /// </summary>
        /// <param name="_event">事件类</param>
        /// <returns></returns>
        [HttpPost("addMul")]
        public IActionResult Add([FromBody]List<EventTable> _event)
        {
            try
            {
                //return Ok(_repository.SaveList(_event));
                int count = _repository.SaveList(_event);
                return Json(new
                {
                    count,
                    state = "0",
                    msg = "操作成功！"
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
        /// 添加事件返回事件id
        /// </summary>
        /// <param name="_event">事件</param>
        /// <returns></returns>
        [HttpPost("addone")]
        public IActionResult Add([FromBody]EventTable _event)
        {
            try
            {
                //return Ok(_repository.SaveGetId(_event));
                int id = _repository.SaveGetId(_event);
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
        /// 更新事件[所有字段,支持批量]
        /// </summary>
        /// <param name="_event">事件类</param>
        /// <returns></returns>
        [HttpPost("UpdateList")]
        public IActionResult UpdateList([FromBody]List<EventTable> _event)
        {
            try
            {
                //return Ok(_repository.UpdateList(_event));
                int count = _repository.UpdateList(_event);
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
        /// 删除指定Id事件
        /// </summary>
        /// <param name="id">事件ID</param>
        /// <returns></returns>
        [HttpDelete("del/{id}")]
        public IActionResult Del(int id)
        {
            try
            {
                //return Ok(_repository.Delete(p => p.Id == id));
                int count=_repository.Delete(p => p.Id == id);
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
        /// 批量删除事件[根据事件ID集合批量删除]
        /// </summary>
        /// <param name="_eventID">事件列表</param>
        /// <returns></returns>
        [HttpDelete("delids")]
        public IActionResult DelByIds([FromBody]List<int> _eventID)
        {
            try
            {
                //return Ok(_repository.Delete(p => _eventID.Contains(p.Id)));
                int count = _repository.Delete(p => _eventID.Contains(p.Id));
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
        /// 批量删除事件[根据事件集合批量删除]
        /// </summary>
        /// <param name="_event">事件列表</param>
        /// <returns></returns>
        [HttpDelete("batchdel")]
        public IActionResult Batchdel([FromBody]List<EventTable> _event)
        {
            try
            {
                //return Ok(_repository.DeleteList(_event));
                int count = _repository.DeleteList(_event);
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
        /// 根据事件ID查询事件
        /// </summary>
        /// <param name="id">事件ID</param>
        /// <returns></returns>
        [HttpGet("select/{id}")]
        public IActionResult Select(int id)
        {
            try
            {
                //return Ok(_repository.Get(p => p.Id == id));
                return Json(new
                {
                    table = _repository.Get(p => p.Id == id),
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
        /// 查询所有事件
        /// </summary>
        /// <returns>返回所有事件</returns>
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
