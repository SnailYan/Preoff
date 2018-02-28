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
    /// 执行任务控制器
    /// </summary>
    //[Authorize]
    [Produces("application/json")]
    [Route("ExecTask")]
    public class ExecTaskController : Controller
    {
        /// <summary>
        /// 执行任务仓库
        /// </summary>
        public readonly IRepository<ExecTaskTable> _repository;
        ILog log = LogManager.GetLogger(Startup.Logrepository.Name, typeof(Startup));
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_db">注入数据仓库</param>
        public ExecTaskController(IRepository<ExecTaskTable> _db)
        {
            _repository = _db;
        }

        /// <summary>
        /// 添加执行任务[支持批量]
        /// </summary>
        /// <param name="_execTask">执行任务类</param>
        /// <returns></returns>
        [HttpPost("addMul")]
        public IActionResult Add([FromBody]List<ExecTaskTable> _execTask)
        {
            try
            {
                int count=_repository.SaveList(_execTask);
                return Json(new
                {
                    count,
                    state = "0",
                    msg = "操作成功！"
                });
                //return Ok(_repository.SaveList(_execTask));
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
        /// 添加执行任务返回执行任务id
        /// </summary>
        /// <param name="_execTask">执行任务</param>
        /// <returns></returns>
        [HttpPost("addone")]
        public IActionResult Add([FromBody]ExecTaskTable _execTask)
        {
            try
            {
                //return Ok(_repository.SaveGetId(_execTask));
                int id = _repository.SaveGetId(_execTask);
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
        /// 更新执行任务[所有字段,支持批量]
        /// </summary>
        /// <param name="_execTask">执行任务类</param>
        /// <returns></returns>
        [HttpPost("UpdateList")]
        public IActionResult UpdateList([FromBody]List<ExecTaskTable> _execTask)
        {
            try
            {
                //return Ok(_repository.UpdateList(_execTask));
                int count = _repository.UpdateList(_execTask);
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
        /// 删除指定Id执行任务
        /// </summary>
        /// <param name="id">执行任务ID</param>
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
        /// 批量删除执行任务[根据执行任务ID集合批量删除]
        /// </summary>
        /// <param name="_execTaskID">执行任务列表</param>
        /// <returns></returns>
        [HttpDelete("delids")]
        public IActionResult DelByIds([FromBody]List<int> _execTaskID)
        {
            try
            {
                //return Ok(_repository.Delete(p => _execTaskID.Contains(p.Id)));
                int count = _repository.Delete(p => _execTaskID.Contains(p.Id));
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
        /// 批量删除执行任务[根据执行任务集合批量删除]
        /// </summary>
        /// <param name="_execTask">执行任务列表</param>
        /// <returns></returns>
        [HttpDelete("batchdel")]
        public IActionResult Batchdel([FromBody]List<ExecTaskTable> _execTask)
        {
            try
            {
                //return Ok(_repository.DeleteList(_execTask));
                int count = _repository.DeleteList(_execTask);
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
        /// 根据执行任务ID查询执行任务
        /// </summary>
        /// <param name="id">执行任务ID</param>
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
        /// 查询所有执行任务
        /// </summary>
        /// <returns>返回所有执行任务</returns>
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
