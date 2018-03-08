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
        public readonly IRepository<FireStationDataTable> _repository;
        ILog log = LogManager.GetLogger(Startup.Logrepository.Name, typeof(Startup));
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_db">注入数据仓库</param>
        public FireStationDataController(IRepository<FireStationDataTable> _db)
        {
            _repository = _db;
        }


        //[HttpPost("Page")]
        //public IActionResult SelectPage(int pageIndex, int pageSize, string code, string startdate, string enddate, string hour, string order, bool isAsc)
        //{
        //    //if (code.Trim()==string.Empty)
        //    //{
        //    //    return Json(new
        //    //    {
        //    //        state = "-1",
        //    //        msg = "编码不能为空！"
        //    //    });
        //    //}

        //    _repository.LoadListAll(p => p.Code == code && p.CatHour == hour && Convert.ToDateTime(p.CatDate) >= Convert.ToDateTime(startdate));
        //}


    }
}
