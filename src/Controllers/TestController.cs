using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using log4net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Preoff.Data;
using Preoff.Entity;

namespace Preoff.Controllers
{
    [Produces("application/json")]
    [Route("Test")]
    public class TestController : Controller
    {
        public readonly IUserRepository _userRepository;
        ILog log = LogManager.GetLogger(Startup.Logrepository.Name, typeof(Startup));
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userRepository">用户仓储</param>
        public TestController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        ///// <summary>
        ///// 添加用户[支持批量]
        ///// </summary>
        ///// <param name="_user">用户类</param>
        ///// <returns>执行成功则返回添加成功记录条数，失败返回0</returns>
        //[HttpPost("add")]
        //public IActionResult Add([FromBody]Tuser _user)
        //{
        //    Tuser _tuser= _userRepository.Create(_user);
        //    if (_tuser is null)
        //    {
        //        return Ok("0");
        //    }
        //    else
        //    {
        //        return Ok(_tuser);
        //    }
        //}
        [HttpGet("all")]
        public IActionResult all()
        {
            _userRepository.BatchUpdateUserBirthday();
           return Ok(_userRepository.GetAll());
        }

        [HttpPost("add")]
        public IActionResult Add([FromBody] UserTable _user)
        {
            _userRepository.Create(_user);
            return Ok();
        }
    }
}