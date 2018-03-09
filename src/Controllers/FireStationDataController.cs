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
    [Route("Weather")]
    public class FireStationDataController : BaseController
    {
        /// <summary>
        /// 无人机仓库
        /// </summary>
        public readonly IFireStationDataRepository _repository;
        ILog log = LogManager.GetLogger(Startup.Logrepository.Name, typeof(Startup));
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_db">注入数据仓库</param>
        public FireStationDataController(IFireStationDataRepository _db)
        {
            _repository = _db;
        }

        /// <summary>
        /// 根据日期和时间获取火险等级
        /// </summary>
        /// <param name="date">日期20180309</param>
        /// <param name="hour">小时08</param>
        /// <returns></returns>
        [HttpPost("GetList")]
        public IActionResult SelectPage(string date,string hour)
        {
            if (date.Length!=8)
            {
                return Json(new
                {
                    status = '0',
                    msg = "日期不合法日期格式(yyyymmdd)!"
                });
            }
            if (hour.Length<2)
            {
                hour = "0" + hour;
            }
            return Json(new
            {
                 table = _repository.GetEntity(date, hour),
                status = '0',
                msg = "操作成功!"
            });
        }


    }
}
