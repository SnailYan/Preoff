using log4net;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Preoff.Entity;
using Preoff.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Preoff.Controllers
{
    /// <summary>
    /// 任务控制器
    /// </summary>
    //[Authorize]
    [EnableCors("AllowSpecificOrigin")]
    [Route("EventVideo")]
    public class EventVideoController : Controller
    {
        /// <summary>
        /// 事件类型仓库
        /// </summary>
        public readonly IRepository<EventVideoTable> _repository;
        ILog log = LogManager.GetLogger(Startup.Logrepository.Name, typeof(Startup));
        private IHostingEnvironment hostingEnv;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_db">注入数据仓库</param>
        /// <param name="env">环境</param>
        public EventVideoController(IRepository<EventVideoTable> _db, IHostingEnvironment env)
        {
            _repository = _db;
            hostingEnv = env;
        }
        /// <summary>
        /// 上传视频[限制大小20M]
        /// </summary>
        /// <param name="id">事件id</param>
        /// <param name="_files">视频文件</param>
        /// <returns></returns>
        [HttpPost("Upload")]
        public IActionResult Post(int id, IFormFileCollection _files)
        {
            try
            {
                var files = Request.Form.Files[0];
                var fileExtension = Path.GetExtension(files.FileName);
                string fileFilt = ".mp4|.swf|.mpg|.avi";


                if (fileExtension == null)
                {
                    return Json(new
                    {
                        state = "-1",
                        msg = "上传的文件没有后缀!"
                    });
                }
                if (fileFilt.IndexOf(fileExtension.ToLower(), StringComparison.Ordinal) <= -1)
                {
                    return Json(new
                    {
                        state = "-1",
                        msg = "上传的文件不是视频格式!"
                    });
                }


                long size = files.Length;
                var now = DateTime.Now;
                var filePathExt = now.ToString("yyyyMMdd");
                if (size > 20971420)
                {
                    return Json(new
                    {
                        state = "-1",
                        msg = "文件大小不应超过20M！"
                    });
                }


                var fileName = ContentDispositionHeaderValue.Parse(files.ContentDisposition).FileName.Trim('"');

                string filePath = $@"E:\corewebapi\Upload\Video\";

                if (!Directory.Exists(filePath + filePathExt))
                {
                    Directory.CreateDirectory(filePath + filePathExt);
                }

                fileName = Guid.NewGuid() + "." + fileName.Split('.')[1];

                string fileFullName = filePath + filePathExt + @"\" + fileName;

                using (FileStream fs = System.IO.File.Create(fileFullName))
                {
                    files.CopyTo(fs);
                    fs.Flush();
                }
                string message = $"上传成功!";
                EventVideoTable _video = new EventVideoTable
                {
                    EventTableId = id,
                    VideoPath = $@"\Upload\Video\{filePathExt}\{fileName}"
                };
                if (_repository.Save(_video))
                {
                    return Json(new
                    {
                        state = "0",
                        msg = message
                    });
                }
                else
                {
                    return Json(new
                    {
                        state = "-1",
                        msg = "上传失败!"
                    });
                }
            }

            catch (Exception ex)
            {
                return Json(new
                {
                    state = "-1",
                    msg = "上传失败!"
                });
            }
        }
    }
}
