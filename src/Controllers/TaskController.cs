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
    /// 任务控制器
    /// </summary>
    //[Authorize]
    [Produces("application/json")]
    [Route("Task")]
    public class TaskController : Controller
    {
        /// <summary>
        /// 任务仓库
        /// </summary>
        public readonly IRepository<TaskTable> _repository;
        ILog log = LogManager.GetLogger(Startup.Logrepository.Name, typeof(Startup));
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_db">注入数据仓库</param>
        public TaskController(IRepository<TaskTable> _db)
        {
            _repository = _db;
        }

        /// <summary>
        /// 添加任务[支持批量]
        /// </summary>
        /// <param name="_task">用户类</param>
        /// <returns></returns>
        [HttpPost("addMul")]
        public IActionResult Add([FromBody]List<TaskTable> _task)
        {
            try
            {
                //return Ok(_repository.SaveList(_task));
                int count = _repository.SaveList(_task);
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
        /// 添加任务返回任务id
        /// </summary>
        /// <param name="_task">任务</param>
        /// <returns></returns>
        [HttpPost("addone")]
        public IActionResult Add([FromBody]TaskTable _task)
        {
            try
            {
                //return Ok(_repository.SaveGetId(_task));
                int id = _repository.SaveGetId(_task);
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
        /// 更新任务[所有字段,支持批量]
        /// </summary>
        /// <param name="_task">任务类</param>
        /// <returns></returns>
        [HttpPost("UpdateList")]
        public IActionResult UpdateList([FromBody]List<TaskTable> _task)
        {
            try
            {
                //return Ok(_repository.UpdateList(_task));
                int count = _repository.UpdateList(_task);
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
        /// 删除指定Id任务
        /// </summary>
        /// <param name="id">任务ID</param>
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
        /// 批量删除任务[根据任务ID集合批量删除]
        /// </summary>
        /// <param name="_taskID">任务列表</param>
        /// <returns></returns>
        [HttpDelete("delids")]
        public IActionResult DelByIds([FromBody]List<int> _taskID)
        {
            try
            {
                //return Ok(_repository.Delete(p => _taskID.Contains(p.Id)));
                int count = _repository.Delete(p => _taskID.Contains(p.Id));
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
        /// 批量删除任务[根据任务集合批量删除]
        /// </summary>
        /// <param name="_task">任务列表</param>
        /// <returns></returns>
        [HttpDelete("batchdel")]
        public IActionResult Batchdel([FromBody]List<TaskTable> _task)
        {
            try
            {
                //return Ok(_repository.DeleteList(_task));
                int count = _repository.DeleteList(_task);
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
        /// 根据任务ID查询任务
        /// </summary>
        /// <param name="id">任务ID</param>
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
        /// 查询所有任务
        /// </summary>
        /// <returns>返回所有任务</returns>
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
