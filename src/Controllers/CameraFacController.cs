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
    /// 摄像头厂商控制器
    /// </summary>
    //[Authorize]
    [Produces("application/json")]
    [Route("CameraFac")]
    public class CameraFacController : Controller
    {
        /// <summary>
        /// 摄像头厂商仓库
        /// </summary>
        public readonly IRepository<CameraFacTable> _repository;
        ILog log = LogManager.GetLogger(Startup.Logrepository.Name, typeof(Startup));
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_db">注入数据仓库</param>
        public CameraFacController(IRepository<CameraFacTable> _db)
        {
            _repository = _db;
        }

        /// <summary>
        /// 添加摄像头厂商[支持批量]
        /// </summary>
        /// <param name="_cameraFac">摄像头厂商类</param>
        /// <returns></returns>
        [HttpPost("addMul")]
        public IActionResult Add([FromBody]List<CameraFacTable> _cameraFac)
        {
            try
            {
                int count=_repository.SaveList(_cameraFac);
                return Json(new
                {
                    count,
                    state = "0",
                    msg = "操作成功！"
                });
                //return Ok(_repository.SaveList(_cameraFac));
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
        /// 添加摄像头厂商返回摄像头厂商id
        /// </summary>
        /// <param name="_cameraFac">摄像头厂商</param>
        /// <returns></returns>
        [HttpPost("addone")]
        public IActionResult Add([FromBody]CameraFacTable _cameraFac)
        {
            try
            {
                //return Ok(_repository.SaveGetId(_cameraFac));
                int id = _repository.SaveGetId(_cameraFac);
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
        /// 更新摄像头厂商[所有字段,支持批量]
        /// </summary>
        /// <param name="_cameraFac">摄像头厂商类</param>
        /// <returns></returns>
        [HttpPost("UpdateList")]
        public IActionResult UpdateList([FromBody]List<CameraFacTable> _cameraFac)
        {
            try
            {
                //return Ok(_repository.UpdateList(_cameraFac));
                int count = _repository.UpdateList(_cameraFac);
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
        /// 删除指定Id摄像头厂商
        /// </summary>
        /// <param name="id">摄像头厂商ID</param>
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
        /// 批量删除摄像头厂商[根据摄像头厂商ID集合批量删除]
        /// </summary>
        /// <param name="_cameraFacID">摄像头厂商列表</param>
        /// <returns></returns>
        [HttpDelete("delids")]
        public IActionResult DelByIds([FromBody]List<int> _cameraFacID)
        {
            try
            {
                //return Ok(_repository.Delete(p => _cameraFacID.Contains(p.Id)));
                int count = _repository.Delete(p => _cameraFacID.Contains(p.Id));
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
        /// 批量删除摄像头厂商[根据摄像头厂商集合批量删除]
        /// </summary>
        /// <param name="_cameraFac">摄像头厂商列表</param>
        /// <returns></returns>
        [HttpDelete("batchdel")]
        public IActionResult Batchdel([FromBody]List<CameraFacTable> _cameraFac)
        {
            try
            {
                //return Ok(_repository.DeleteList(_cameraFac));
                int count = _repository.DeleteList(_cameraFac);
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
        /// 根据摄像头厂商ID查询摄像头厂商
        /// </summary>
        /// <param name="id">摄像头厂商ID</param>
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
        /// 查询所有摄像头厂商
        /// </summary>
        /// <returns>返回所有摄像头厂商</returns>
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
