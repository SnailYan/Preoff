﻿using DynamicExpresso;
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

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页数据条数</param>
        /// <param name="filter">过滤条件</param>
        /// <param name="order">排序字段</param>
        /// <param name="isAsc">是否升序</param>
        /// <returns></returns>
        [HttpPost("Page")]
        public IActionResult SelectPage(int pageIndex, int pageSize, [FromBody]List<FilterStr> filter, string order, bool isAsc)
        {
            try
            {
                string _order = string.Empty;
                Expression<Func<CameraTypeTable, string>> orderby = null;
                Expression<Func<CameraTypeTable, int>> orderbyint = null;
                Expression<Func<CameraTypeTable, bool>> where = null;

                getOrder(order, ref _order, ref orderby, ref orderbyint);
                if (filter != null && filter.Count > 0)
                {
                    string _filter = string.Empty;
                    foreach (FilterStr item in filter)
                    {
                        _filter += "p." + item.FieldName;
                        _filter = SwitchOper.SwitchOperation(_filter, item);
                        switch (item.Value.GetType().Name.ToString())
                        {
                            case "String":
                            case "string":
                                if (item.Operation == OperationStr.Like)
                                {
                                    _filter += item.Value;
                                    _filter += "\")";
                                }
                                else if (item.Operation == OperationStr.Equal || item.Operation == OperationStr.NotEqual)
                                {
                                    _filter += "\"";
                                    _filter += item.Value;
                                    _filter += "\"";
                                }
                                else
                                {
                                    return Json(new
                                    {
                                        state = "-1",
                                        msg = "条件无效！"
                                    });
                                }
                                break;
                            case "Int32":
                            case "Int64":
                            case "Int":
                            case "Double":
                                if (item.Operation == OperationStr.Like)
                                {
                                    return Json(new
                                    {
                                        state = "-1",
                                        msg = "条件无效！"
                                    });
                                }
                                else
                                {
                                    _filter += item.Value;
                                }
                                break;
                            case "DateTime":
                                if (item.Operation == OperationStr.Like)
                                {
                                    return Json(new
                                    {
                                        state = "-1",
                                        msg = "条件无效！"
                                    });
                                }
                                else
                                {
                                    _filter += "DateTime.Parse(\"";
                                    _filter += item.Value;
                                    _filter += "\")";
                                }
                                break;
                            default:
                                break;
                        }
                        _filter += "&&";
                    }
                    _filter = _filter.Substring(0, _filter.Length - 2);
                    where = new Interpreter().ParseAsExpression<Func<CameraTypeTable, bool>>(_filter, "p");
                }

                if (orderbyint == null)
                {
                    return Json(new
                    {
                        table = _repository.Query<CameraTypeTable, string>(pageIndex, pageSize, where, orderby, null, isAsc),
                        state = "0",
                        msg = "操作成功！"
                    });
                }
                else
                {
                    return Json(new
                    {
                        table = _repository.Query<CameraTypeTable, int>(pageIndex, pageSize, where, orderbyint, null, isAsc),
                        state = "0",
                        msg = "操作成功！"
                    });
                }
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


        private static void getOrder(string order, ref string _order, ref Expression<Func<CameraTypeTable, string>> orderby, ref Expression<Func<CameraTypeTable, int>> orderbyint)
        {
            if (order != null && order != string.Empty)
            {
                _order = "x." + order;
                try
                {
                    orderby = new Interpreter().ParseAsExpression<Func<CameraTypeTable, string>>(_order, "x");

                }
                catch (Exception ex)
                {
                    try
                    {

                    }
                    catch (Exception e)
                    {
                        orderbyint = new Interpreter().ParseAsExpression<Func<CameraTypeTable, int>>(_order, "x");
                    }

                }

            }
        }
    }
}