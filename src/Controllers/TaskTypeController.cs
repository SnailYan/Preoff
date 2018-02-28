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
    /// 任务类型控制器
    /// </summary>
    //[Authorize]
    [Produces("application/json")]
    [Route("TaskType")]
    public class TaskTypeController : Controller
    {
        /// <summary>
        /// 任务类型仓库
        /// </summary>
        public readonly IRepository<TaskTypeTable> _repository;
        ILog log = LogManager.GetLogger(Startup.Logrepository.Name, typeof(Startup));
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_db">注入数据仓库</param>
        public TaskTypeController(IRepository<TaskTypeTable> _db)
        {
            _repository = _db;
        }

        /// <summary>
        /// 添加任务类型[支持批量]
        /// </summary>
        /// <param name="_taskType">任务类型类</param>
        /// <returns></returns>
        [HttpPost("addMul")]
        public IActionResult Add([FromBody]List<TaskTypeTable> _taskType)
        {
            try
            {
                int count=_repository.SaveList(_taskType);
                return Json(new
                {
                    count,
                    state = "0",
                    msg = "操作成功！"
                });
                //return Ok(_repository.SaveList(_taskType));
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
        /// 添加任务类型返回任务类型id
        /// </summary>
        /// <param name="_taskType">任务类型</param>
        /// <returns></returns>
        [HttpPost("addone")]
        public IActionResult Add([FromBody]TaskTypeTable _taskType)
        {
            try
            {
                //return Ok(_repository.SaveGetId(_taskType));
                int id = _repository.SaveGetId(_taskType);
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
        /// 更新任务类型[所有字段,支持批量]
        /// </summary>
        /// <param name="_taskType">任务类型类</param>
        /// <returns></returns>
        [HttpPost("UpdateList")]
        public IActionResult UpdateList([FromBody]List<TaskTypeTable> _taskType)
        {
            try
            {
                //return Ok(_repository.UpdateList(_taskType));
                int count = _repository.UpdateList(_taskType);
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
        /// 删除指定Id任务类型
        /// </summary>
        /// <param name="id">任务类型ID</param>
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
        /// 批量删除任务类型[根据任务类型ID集合批量删除]
        /// </summary>
        /// <param name="_taskTypeID">任务类型列表</param>
        /// <returns></returns>
        [HttpDelete("delids")]
        public IActionResult DelByIds([FromBody]List<int> _taskTypeID)
        {
            try
            {
                //return Ok(_repository.Delete(p => _taskTypeID.Contains(p.Id)));
                int count = _repository.Delete(p => _taskTypeID.Contains(p.Id));
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
        /// 批量删除任务类型[根据任务类型集合批量删除]
        /// </summary>
        /// <param name="_taskType">任务类型列表</param>
        /// <returns></returns>
        [HttpDelete("batchdel")]
        public IActionResult Batchdel([FromBody]List<TaskTypeTable> _taskType)
        {
            try
            {
                //return Ok(_repository.DeleteList(_taskType));
                int count = _repository.DeleteList(_taskType);
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
        /// 根据任务类型ID查询任务类型
        /// </summary>
        /// <param name="id">任务类型ID</param>
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
        /// 查询所有任务类型
        /// </summary>
        /// <returns>返回所有任务类型</returns>
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
