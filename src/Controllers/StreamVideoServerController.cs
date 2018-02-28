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
    /// 流媒体服务器控制器
    /// </summary>
    //[Authorize]
    [Produces("application/json")]
    [Route("StreamVideoServer")]
    public class StreamVideoServerController : Controller
    {
        /// <summary>
        /// 流媒体服务器仓库
        /// </summary>
        public readonly IRepository<StreamVideoServerTable> _repository;
        ILog log = LogManager.GetLogger(Startup.Logrepository.Name, typeof(Startup));
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_db">注入数据仓库</param>
        public StreamVideoServerController(IRepository<StreamVideoServerTable> _db)
        {
            _repository = _db;
        }

        /// <summary>
        /// 添加流媒体服务器[支持批量]
        /// </summary>
        /// <param name="_streamServer">流媒体服务器类</param>
        /// <returns></returns>
        [HttpPost("addMul")]
        public IActionResult Add([FromBody]List<StreamVideoServerTable> _streamServer)
        {
            try
            {
                int count=_repository.SaveList(_streamServer);
                return Json(new
                {
                    count,
                    state = "0",
                    msg = "操作成功！"
                });
                //return Ok(_repository.SaveList(_streamServer));
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
        /// 添加流媒体服务器返回流媒体服务器id
        /// </summary>
        /// <param name="_streamServer">流媒体服务器</param>
        /// <returns></returns>
        [HttpPost("addone")]
        public IActionResult Add([FromBody]StreamVideoServerTable _streamServer)
        {
            try
            {
                //return Ok(_repository.SaveGetId(_streamServer));
                int id = _repository.SaveGetId(_streamServer);
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
        /// 更新流媒体服务器[所有字段,支持批量]
        /// </summary>
        /// <param name="_streamServer">流媒体服务器类</param>
        /// <returns></returns>
        [HttpPost("UpdateList")]
        public IActionResult UpdateList([FromBody]List<StreamVideoServerTable> _streamServer)
        {
            try
            {
                //return Ok(_repository.UpdateList(_streamServer));
                int count = _repository.UpdateList(_streamServer);
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
        /// 删除指定Id流媒体服务器
        /// </summary>
        /// <param name="id">流媒体服务器ID</param>
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
        /// 批量删除流媒体服务器[根据流媒体服务器ID集合批量删除]
        /// </summary>
        /// <param name="_streamServerID">流媒体服务器列表</param>
        /// <returns></returns>
        [HttpDelete("delids")]
        public IActionResult DelByIds([FromBody]List<int> _streamServerID)
        {
            try
            {
                //return Ok(_repository.Delete(p => _streamServerID.Contains(p.Id)));
                int count = _repository.Delete(p => _streamServerID.Contains(p.Id));
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
        /// 批量删除流媒体服务器[根据流媒体服务器集合批量删除]
        /// </summary>
        /// <param name="_streamServer">流媒体服务器列表</param>
        /// <returns></returns>
        [HttpDelete("batchdel")]
        public IActionResult Batchdel([FromBody]List<StreamVideoServerTable> _streamServer)
        {
            try
            {
                //return Ok(_repository.DeleteList(_streamServer));
                int count = _repository.DeleteList(_streamServer);
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
        /// 根据流媒体服务器ID查询流媒体服务器
        /// </summary>
        /// <param name="id">流媒体服务器ID</param>
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
        /// 查询所有流媒体服务器
        /// </summary>
        /// <returns>返回所有流媒体服务器</returns>
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
