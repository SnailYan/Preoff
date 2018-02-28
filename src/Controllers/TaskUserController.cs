﻿using log4net;
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
    /// 任务用户映射表控制器
    /// </summary>
    //[Authorize]
    [Produces("application/json")]
    [Route("TaskUser")]
    public class TaskUserController : Controller
    {
        /// <summary>
        /// 任务用户映射表仓库
        /// </summary>
        public readonly IRepository<TaskUserTable> _repository;
        ILog log = LogManager.GetLogger(Startup.Logrepository.Name, typeof(Startup));
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_db">注入数据仓库</param>
        public TaskUserController(IRepository<TaskUserTable> _db)
        {
            _repository = _db;
        }

        /// <summary>
        /// 添加任务用户映射表[支持批量]
        /// </summary>
        /// <param name="_taskUser">任务用户映射表类</param>
        /// <returns></returns>
        [HttpPost("addMul")]
        public IActionResult Add([FromBody]List<TaskUserTable> _taskUser)
        {
            try
            {
                int count=_repository.SaveList(_taskUser);
                return Json(new
                {
                    count,
                    state = "0",
                    msg = "操作成功！"
                });
                //return Ok(_repository.SaveList(_taskUser));
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
        /// 添加任务用户映射表返回任务用户映射表id
        /// </summary>
        /// <param name="_taskUser">任务用户映射表</param>
        /// <returns></returns>
        [HttpPost("addone")]
        public IActionResult Add([FromBody]TaskUserTable _taskUser)
        {
            try
            {
                //return Ok(_repository.SaveGetId(_taskUser));
                int id = _repository.SaveGetId(_taskUser);
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
        /// 更新任务用户映射表[所有字段,支持批量]
        /// </summary>
        /// <param name="_taskUser">任务用户映射表类</param>
        /// <returns></returns>
        [HttpPost("UpdateList")]
        public IActionResult UpdateList([FromBody]List<TaskUserTable> _taskUser)
        {
            try
            {
                //return Ok(_repository.UpdateList(_taskUser));
                int count = _repository.UpdateList(_taskUser);
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
        /// 删除指定Id任务用户映射表
        /// </summary>
        /// <param name="id">任务用户映射表ID</param>
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
        /// 批量删除任务用户映射表[根据任务用户映射表ID集合批量删除]
        /// </summary>
        /// <param name="_taskUserID">任务用户映射表列表</param>
        /// <returns></returns>
        [HttpDelete("delids")]
        public IActionResult DelByIds([FromBody]List<int> _taskUserID)
        {
            try
            {
                //return Ok(_repository.Delete(p => _taskUserID.Contains(p.Id)));
                int count = _repository.Delete(p => _taskUserID.Contains(p.Id));
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
        /// 批量删除任务用户映射表[根据任务用户映射表集合批量删除]
        /// </summary>
        /// <param name="_taskUser">任务用户映射表列表</param>
        /// <returns></returns>
        [HttpDelete("batchdel")]
        public IActionResult Batchdel([FromBody]List<TaskUserTable> _taskUser)
        {
            try
            {
                //return Ok(_repository.DeleteList(_taskUser));
                int count = _repository.DeleteList(_taskUser);
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
        /// 根据任务用户映射表ID查询任务用户映射表
        /// </summary>
        /// <param name="id">任务用户映射表ID</param>
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
        /// 查询所有任务用户映射表
        /// </summary>
        /// <returns>返回所有任务用户映射表</returns>
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
