using DynamicExpresso;
using log4net;
using Microsoft.AspNetCore.Mvc;
using Preoff.Comm;
using Preoff.Entity;
using Preoff.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Preoff.Controllers
{
    /// <summary>
    /// 无人机控制器
    /// </summary>
    //[Authorize]
    [Produces("application/json")]
    [Route("HotsPots")]
    public class HotsPotsController : BaseController
    {
        /// <summary>
        /// 无人机仓库
        /// </summary>
        public readonly IHotsPotsRepository _repository;
        ILog log = LogManager.GetLogger(Startup.Logrepository.Name, typeof(Startup));
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_db">注入数据仓库</param>
        public HotsPotsController(IHotsPotsRepository _db)
        {
            _repository = _db;
        }

        /// <summary>
        /// 根据日期和时间获取火险等级
        /// </summary>
        /// <param name="date">日期(20180309)</param>
        /// <param name="hour">小时(08)</param>
        /// <returns></returns>
        [HttpGet("GetList")]
        public IActionResult SelectPage(string date)
        {
            try
            {
                return Json(new
                {
                    table = _repository.GetEntity(date),
                    status = "0",
                    msg = "操作成功!"
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {                    
                    status = "-1",
                    msg = "日期不合法!"
                });
            }

        }


    }
}
