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
    [Route("EventType")]
    public class EventTypeController : Controller
    {
        /// <summary>
        /// 事件类型仓库
        /// </summary>
        public readonly IRepository<EventTypeTable> _repository;
        ILog log = LogManager.GetLogger(Startup.Logrepository.Name, typeof(Startup));
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_db">注入数据仓库</param>
        public EventTypeController(IRepository<EventTypeTable> _db)
        {
            _repository = _db;
        }

        /// <summary>
        /// 获取事件类型
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult EventType()
        {
            try
            {
                return Json(new
                {
                    table=_repository.LoadListAll(),
                    state = "0",
                    msg = "操作成功!"
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

    }
}
