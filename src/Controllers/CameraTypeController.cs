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
    /// 摄像头类型控制器
    /// </summary>
    //[Authorize]
    [Produces("application/json")]
    [Route("CameraType")]
    public class CameraTypeController : Controller
    {
        /// <summary>
        /// 摄像头类型仓库
        /// </summary>
        public readonly IRepository<CameraTypeTable> _repository;
        ILog log = LogManager.GetLogger(Startup.Logrepository.Name, typeof(Startup));
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_db">注入数据仓库</param>
        public CameraTypeController(IRepository<CameraTypeTable> _db)
        {
            _repository = _db;
        }

        /// <summary>
        /// 添加摄像头类型[支持批量]
        /// </summary>
        /// <param name="_cameraType">摄像头类型</param>
        /// <returns></returns>
        [HttpPost("addMul")]
        public IActionResult Add([FromBody]List<CameraTypeTable> _cameraType)
        {
            try
            {
                int count=_repository.SaveList(_cameraType);
                return Json(new
                {
                    count,
                    state = "0",
                    msg = "操作成功！"
                });
                //return Ok(_repository.SaveList(_cameraType));
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
        /// 添加摄像头类型返回摄像头类型id
        /// </summary>
        /// <param name="_cameraType">摄像头类型</param>
        /// <returns></returns>
        [HttpPost("addone")]
        public IActionResult Add([FromBody]CameraTypeTable _cameraType)
        {
            try
            {
                //return Ok(_repository.SaveGetId(_cameraType));
                int id = _repository.SaveGetId(_cameraType);
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
        /// 更新摄像头类型[所有字段,支持批量]
        /// </summary>
        /// <param name="_cameraType">摄像头类型类</param>
        /// <returns></returns>
        [HttpPost("UpdateList")]
        public IActionResult UpdateList([FromBody]List<CameraTypeTable> _cameraType)
        {
            try
            {
                //return Ok(_repository.UpdateList(_cameraType));
                int count = _repository.UpdateList(_cameraType);
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
        /// 删除指定Id摄像头类型
        /// </summary>
        /// <param name="id">摄像头类型ID</param>
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
        /// 批量删除摄像头类型[根据摄像头类型ID集合批量删除]
        /// </summary>
        /// <param name="_cameraTypeID">摄像头类型列表</param>
        /// <returns></returns>
        [HttpDelete("delids")]
        public IActionResult DelByIds([FromBody]List<int> _cameraTypeID)
        {
            try
            {
                //return Ok(_repository.Delete(p => _cameraTypeID.Contains(p.Id)));
                int count = _repository.Delete(p => _cameraTypeID.Contains(p.Id));
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
        /// 批量删除摄像头类型[根据摄像头类型集合批量删除]
        /// </summary>
        /// <param name="_cameraType">摄像头类型列表</param>
        /// <returns></returns>
        [HttpDelete("batchdel")]
        public IActionResult Batchdel([FromBody]List<CameraTypeTable> _cameraType)
        {
            try
            {
                //return Ok(_repository.DeleteList(_cameraType));
                int count = _repository.DeleteList(_cameraType);
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
        /// 根据摄像头类型ID查询摄像头类型
        /// </summary>
        /// <param name="id">摄像头类型ID</param>
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
        /// 查询所有摄像头类型
        /// </summary>
        /// <returns>返回所有摄像头类型</returns>
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
