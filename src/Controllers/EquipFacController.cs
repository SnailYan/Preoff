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
    /// 载荷厂商控制器
    /// </summary>
    //[Authorize]
    [Produces("application/json")]
    [Route("EquipFac")]
    public class EquipFacController : Controller
    {
        /// <summary>
        /// 载荷厂商仓库
        /// </summary>
        public readonly IRepository<EquipFacTable> _repository;
        ILog log = LogManager.GetLogger(Startup.Logrepository.Name, typeof(Startup));
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_db">注入数据仓库</param>
        public EquipFacController(IRepository<EquipFacTable> _db)
        {
            _repository = _db;
        }

        /// <summary>
        /// 添加载荷厂商[支持批量]
        /// </summary>
        /// <param name="_equipFac">载荷厂商类</param>
        /// <returns></returns>
        [HttpPost("addMul")]
        public IActionResult Add([FromBody]List<EquipFacTable> _equipFac)
        {
            try
            {
                int count=_repository.SaveList(_equipFac);
                return Json(new
                {
                    count,
                    state = "0",
                    msg = "操作成功！"
                });
                //return Ok(_repository.SaveList(_equipFac));
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
        /// 添加载荷厂商返回载荷厂商id
        /// </summary>
        /// <param name="_equipFac">载荷厂商</param>
        /// <returns></returns>
        [HttpPost("addone")]
        public IActionResult Add([FromBody]EquipFacTable _equipFac)
        {
            try
            {
                //return Ok(_repository.SaveGetId(_equipFac));
                int id = _repository.SaveGetId(_equipFac);
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
        /// 更新载荷厂商[所有字段,支持批量]
        /// </summary>
        /// <param name="_equipFac">载荷厂商类</param>
        /// <returns></returns>
        [HttpPost("UpdateList")]
        public IActionResult UpdateList([FromBody]List<EquipFacTable> _equipFac)
        {
            try
            {
                //return Ok(_repository.UpdateList(_equipFac));
                int count = _repository.UpdateList(_equipFac);
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
        /// 删除指定Id载荷厂商
        /// </summary>
        /// <param name="id">载荷厂商ID</param>
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
        /// 批量删除载荷厂商[根据载荷厂商ID集合批量删除]
        /// </summary>
        /// <param name="_equipFacID">载荷厂商列表</param>
        /// <returns></returns>
        [HttpDelete("delids")]
        public IActionResult DelByIds([FromBody]List<int> _equipFacID)
        {
            try
            {
                //return Ok(_repository.Delete(p => _equipFacID.Contains(p.Id)));
                int count = _repository.Delete(p => _equipFacID.Contains(p.Id));
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
        /// 批量删除载荷厂商[根据载荷厂商集合批量删除]
        /// </summary>
        /// <param name="_equipFac">载荷厂商列表</param>
        /// <returns></returns>
        [HttpDelete("batchdel")]
        public IActionResult Batchdel([FromBody]List<EquipFacTable> _equipFac)
        {
            try
            {
                //return Ok(_repository.DeleteList(_equipFac));
                int count = _repository.DeleteList(_equipFac);
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
        /// 根据载荷厂商ID查询载荷厂商
        /// </summary>
        /// <param name="id">载荷厂商ID</param>
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
        /// 查询所有载荷厂商
        /// </summary>
        /// <returns>返回所有载荷厂商</returns>
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
