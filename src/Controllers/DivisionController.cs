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
    /// 行政区控制器
    /// </summary>
    //[Authorize]
    [Produces("application/json")]
    [Route("Division")]
    public class DivisionController : Controller
    {
        /// <summary>
        /// 行政区仓库
        /// </summary>
        public readonly IDivisionRepository _repository;
        ILog log = LogManager.GetLogger(Startup.Logrepository.Name, typeof(Startup));
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_db">注入数据仓库</param>
        public DivisionController(IDivisionRepository _db)
        {
            _repository = _db;
        }
        /// <summary>
        /// 获取省
        /// </summary>
        /// <returns>返回省</returns>
        [HttpGet("selectfirst")]
        public IActionResult Seletfirst()
        {
            try
            {
                return Ok(_repository.Get(p => p.PId == "000000000000"));
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
        /// 根据父节点ID查询下一级子节点
        /// </summary>
        /// <param name="id">区域ID</param>
        /// <returns></returns>
        [HttpGet("selectsub/{id}")]
        public IActionResult Select(string id)
        {
            try
            {
                return Ok(_repository.LoadAll(p => p.PId == id));
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
        /// 根据子节点ID查询父节点
        /// </summary>
        /// <returns>父节点ID</returns>
        [HttpGet("selectparent/{id}")]
        public IActionResult SelectAll(string id)
        {
            try
            {
                return Ok(_repository.GetParent(id));
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
