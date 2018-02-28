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
    /// 无人机载荷控制器
    /// </summary>
    //[Authorize]
    [Produces("application/json")]
    [Route("AirLoad")]
    public class AirLoadController : Controller
    {
        /// <summary>
        /// 无人机载荷仓库
        /// </summary>
        public readonly IRepository<AirLoadTable> _repository;
        ILog log = LogManager.GetLogger(Startup.Logrepository.Name, typeof(Startup));
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_db">注入数据仓库</param>
        public AirLoadController(IRepository<AirLoadTable> _db)
        {
            _repository = _db;
        }

        /// <summary>
        /// 添加无人机载荷[支持批量]
        /// </summary>
        /// <param name="_aircLoad">无人机载荷类</param>
        /// <returns></returns>
        [HttpPost("addMul")]
        public IActionResult Add([FromBody]List<AirLoadTable> _aircLoad)
        {
            try
            {
                int count=_repository.SaveList(_aircLoad);
                return Json(new
                {
                    count,
                    state = "0",
                    msg = "操作成功！"
                });
                //return Ok(_repository.SaveList(_aircLoad));
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
        /// 添加无人机载荷返回无人机载荷id
        /// </summary>
        /// <param name="_aircLoad">无人机载荷</param>
        /// <returns></returns>
        [HttpPost("addone")]
        public IActionResult Add([FromBody]AirLoadTable _aircLoad)
        {
            try
            {
                //return Ok(_repository.SaveGetId(_aircLoad));
                int id = _repository.SaveGetId(_aircLoad);
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
        /// 更新无人机载荷[所有字段,支持批量]
        /// </summary>
        /// <param name="_aircLoad">无人机载荷类</param>
        /// <returns></returns>
        [HttpPost("UpdateList")]
        public IActionResult UpdateList([FromBody]List<AirLoadTable> _aircLoad)
        {
            try
            {
                //return Ok(_repository.UpdateList(_aircLoad));
                int count = _repository.UpdateList(_aircLoad);
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
        /// 删除指定Id无人机载荷
        /// </summary>
        /// <param name="id">无人机载荷ID</param>
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
        /// 批量删除无人机载荷[根据无人机载荷ID集合批量删除]
        /// </summary>
        /// <param name="_aircLoadID">无人机载荷列表</param>
        /// <returns></returns>
        [HttpDelete("delids")]
        public IActionResult DelByIds([FromBody]List<int> _aircLoadID)
        {
            try
            {
                //return Ok(_repository.Delete(p => _aircLoadID.Contains(p.Id)));
                int count = _repository.Delete(p => _aircLoadID.Contains(p.Id));
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
        /// 批量删除无人机载荷[根据无人机载荷集合批量删除]
        /// </summary>
        /// <param name="_aircLoad">无人机载荷列表</param>
        /// <returns></returns>
        [HttpDelete("batchdel")]
        public IActionResult Batchdel([FromBody]List<AirLoadTable> _aircLoad)
        {
            try
            {
                //return Ok(_repository.DeleteList(_aircLoad));
                int count = _repository.DeleteList(_aircLoad);
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
        /// 根据无人机载荷ID查询无人机载荷
        /// </summary>
        /// <param name="id">无人机载荷ID</param>
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
        /// 查询所有无人机载荷
        /// </summary>
        /// <returns>返回所有无人机载荷</returns>
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
