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
    /// 任务状态控制器
    /// </summary>
    //[Authorize]
    [Produces("application/json")]
    [Route("TaskState")]
    public class TaskStateController : Controller
    {
        /// <summary>
        /// 任务状态仓库
        /// </summary>
        public readonly IRepository<TaskStateTable> _repository;
        ILog log = LogManager.GetLogger(Startup.Logrepository.Name, typeof(Startup));
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_db">注入数据仓库</param>
        public TaskStateController(IRepository<TaskStateTable> _db)
        {
            _repository = _db;
        }

        /// <summary>
        /// 添加任务状态[支持批量]
        /// </summary>
        /// <param name="_taskState">任务状态类</param>
        /// <returns></returns>
        [HttpPost("addMul")]
        public IActionResult Add([FromBody]List<TaskStateTable> _taskState)
        {
            try
            {
                int count=_repository.SaveList(_taskState);
                return Json(new
                {
                    count,
                    state = "0",
                    msg = "操作成功！"
                });
                //return Ok(_repository.SaveList(_taskState));
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
        /// 添加任务状态返回任务状态id
        /// </summary>
        /// <param name="_taskState">任务状态</param>
        /// <returns></returns>
        [HttpPost("addone")]
        public IActionResult Add([FromBody]TaskStateTable _taskState)
        {
            try
            {
                //return Ok(_repository.SaveGetId(_taskState));
                int id = _repository.SaveGetId(_taskState);
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
        /// 更新任务状态[所有字段,支持批量]
        /// </summary>
        /// <param name="_taskState">任务状态类</param>
        /// <returns></returns>
        [HttpPost("UpdateList")]
        public IActionResult UpdateList([FromBody]List<TaskStateTable> _taskState)
        {
            try
            {
                //return Ok(_repository.UpdateList(_taskState));
                int count = _repository.UpdateList(_taskState);
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
        /// 删除指定Id任务状态
        /// </summary>
        /// <param name="id">任务状态ID</param>
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
        /// 批量删除任务状态[根据任务状态ID集合批量删除]
        /// </summary>
        /// <param name="_taskStateID">任务状态列表</param>
        /// <returns></returns>
        [HttpDelete("delids")]
        public IActionResult DelByIds([FromBody]List<int> _taskStateID)
        {
            try
            {
                //return Ok(_repository.Delete(p => _taskStateID.Contains(p.Id)));
                int count = _repository.Delete(p => _taskStateID.Contains(p.Id));
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
        /// 批量删除任务状态[根据任务状态集合批量删除]
        /// </summary>
        /// <param name="_taskState">任务状态列表</param>
        /// <returns></returns>
        [HttpDelete("batchdel")]
        public IActionResult Batchdel([FromBody]List<TaskStateTable> _taskState)
        {
            try
            {
                //return Ok(_repository.DeleteList(_taskState));
                int count = _repository.DeleteList(_taskState);
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
        /// 根据任务状态ID查询任务状态
        /// </summary>
        /// <param name="id">任务状态ID</param>
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
        /// 查询所有任务状态
        /// </summary>
        /// <returns>返回所有任务状态</returns>
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
