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
    [Route("EventImg")]
    public class EventImgController : Controller
    {
        /// <summary>
        /// 事件类型仓库
        /// </summary>
        public readonly IRepository<EventImgTable> _repository;
        ILog log = LogManager.GetLogger(Startup.Logrepository.Name, typeof(Startup));
        private IHostingEnvironment hostingEnv;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_db">注入数据仓库</param>
        public EventImgController(IRepository<EventImgTable> _db, IHostingEnvironment env)
        {
            _repository = _db;
            hostingEnv = env;
        }
        /// <summary>
        /// 上传图片[限制大小10M]
        /// </summary>
        /// <param name="id">事件id</param>
        /// <param name="_files">图片文件</param>
        /// <returns></returns>
        [HttpPost("Upload")]
        public IActionResult Post(int id, IFormFileCollection _files)
        {
            try
            {
                var files = Request.Form.Files[0];
                var fileExtension = Path.GetExtension(files.FileName);
                string fileFilt = ".gif|.jpg|.bmp|.png|.jpeg|.png";


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
                        msg = "上传的文件不是图片格式!"
                    });
                }


                long size = files.Length;
                var now = DateTime.Now;
                var filePathExt = now.ToString("yyyyMMdd");
                if (size > 10485760)
                {
                    return Json(new
                    {
                        state = "-1",
                        msg = "文件大小不应超过10M！"
                    });
                }


                var fileName = ContentDispositionHeaderValue.Parse(files.ContentDisposition).FileName.Trim('"');

                string filePath = $@"E:\corewebapi\Upload\Img\";

                if (!Directory.Exists(filePath + filePathExt))
                {
                    Directory.CreateDirectory(filePath + filePathExt);
                }

                fileName = Guid.NewGuid() + "." + fileName.Split('.')[1];

                string fileFullName = filePath + filePathExt+@"\" + fileName;

                using (FileStream fs = System.IO.File.Create(fileFullName))
                {
                    files.CopyTo(fs);
                    fs.Flush();
                }
                string message = $"上传成功!";
                EventImgTable _img = new EventImgTable
                {
                    EventTableId = id,
                    ImgPath = $@"\Upload\Img\{filePathExt}\{fileName}"
                };
                _repository.Save(_img);
                return Json(new
                {
                    state = "0",
                    msg = message
                });
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
