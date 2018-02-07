﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Preoff.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using log4net;

namespace Preoff.Controllers
{
    /// <summary>
    /// 用户类控制器
    /// </summary>
    //[Authorize]
    [Produces("application/json")]
    [Route("Area")]
    public class AreaController : Controller
    {
        private JwtSettings _jwtSettings;
        private PreoffContext _dbContext;
        ILog log = LogManager.GetLogger(Startup.Logrepository.Name, typeof(Startup));
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_jwtSettingsAccesser">注入Jwt认证</param>
        /// <param name="_db">注入数据库配置</param>
        public AreaController(IOptions<JwtSettings> _jwtSettingsAccesser,PreoffContext _db)
        {
            _jwtSettings = _jwtSettingsAccesser.Value;
            _dbContext = _db;
        }

        /// <summary>
        /// 查询所有省份
        /// </summary>
        /// <returns>返回所有用户</returns>
        [HttpGet("Province")]
        public IActionResult Province()
        {
            var user = _dbContext.Province.ToList();
            return Ok(user);
        }

        /// <summary>
        /// 查询所有市
        /// </summary>
        /// <returns>返回所有市</returns>
        [HttpGet("City/{id}")]
        public IActionResult City(string id)
        {
            if (id.Length == 12)
            {
                id = id.Substring(0, 2);
            }
            var user = _dbContext.City.Where(c => c.Areacode.Substring(0, 2) == id);
            return Ok(user);
        }

        /// <summary>
        /// 查询所有县（区）
        /// </summary>
        /// <returns>返回所有县（区）</returns>
        [HttpGet("County/{id}")]
        public IActionResult County(string id)
        {
            if (id.Length == 12)
            {
                id = id.Substring(0, 4);
            }
            var user = _dbContext.County.Where(c => c.Areacode.Substring(0, 4) == id);
            return Ok(user);
        }


        /// <summary>
        /// 查询所有镇（街道）
        /// </summary>
        /// <returns>返回所有镇（街道）</returns>
        [HttpGet("Town/{id}")]
        public IActionResult Town(string id)
        {
            if (id.Length == 12)
            {
                id = id.Substring(0, 6);
            }
            var user = _dbContext.Town.Where(c => c.Areacode.Substring(0, 6) == id);
            return Ok(user);
        }

        /// <summary>
        /// 查询所有村
        /// </summary>
        /// <returns>返回所村</returns>
        [HttpGet("Village/{id}")]
        public IActionResult Village(string id)
        {
            if (id.Length == 12)
            {
                id = id.Substring(0, 9);
            }
            var user = _dbContext.Village.Where(c => c.Areacode.Substring(0, 9) == id);
            return Ok(user);
        }

        /// <summary>
        /// 查询详细地址
        /// </summary>
        /// <returns>返回详细地址</returns>
        [HttpGet("Address/{id}")]
        public IActionResult Address(string id)
        {
            if (id.Length != 12)
            {
                return BadRequest();
            }

            var query = from s in _dbContext.Village
                        join c in _dbContext.Town on s.Areacode.Substring(0,9) equals c.Areacode.Substring(0,9)
                        join d in _dbContext.County on s.Areacode.Substring(0, 6) equals d.Areacode.Substring(0, 6)
                        join e in _dbContext.City on s.Areacode.Substring(0, 4) equals e.Areacode.Substring(0, 4)
                        join f in _dbContext.Province on s.Areacode.Substring(0, 2) equals f.Areacode.Substring(0, 2)
                        where s.Areacode == id
                        select f.Areaname+e.Areaname+d.Areaname+c.Areaname+s.Areaname;


            return Ok(query);
            //Province _province = _dbContext.Province.FirstOrDefault(c => c.Areacode == id.Substring(0,2).PadRight(12,'0'));
            //City _city = _dbContext.City.FirstOrDefault(c => c.Areacode == id.Substring(0, 4).PadRight(12, '0'));
            //County _county = _dbContext.County.FirstOrDefault(c => c.Areacode == id.Substring(0, 6).PadRight(12, '0'));
            //Town _town = _dbContext.Town.FirstOrDefault(c => c.Areacode == id.Substring(0, 9).PadRight(12, '0'));
            //Village _village = _dbContext.Village.FirstOrDefault(c => c.Areacode == id);
            //string xxxx=_city == null ? "" : _city.Areaname;
            //return Ok((_province==null?"":_province.Areaname)+ 
            //    (_city == null ? "" : _city.Areaname)+                 
            //    (_county == null ? "" : _county.Areaname)+
            //    (_town == null ? "" : _town.Areaname)+
            //    (_village == null ? "" :_village.Areaname));
        }
    }
}

