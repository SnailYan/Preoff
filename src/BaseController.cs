using log4net;
using Microsoft.ApplicationInsights.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Preoff
{
    /// <summary>
    /// 
    /// </summary>
    public class BaseController : Controller
    {
        //public override void OnActionExecuting(ActionExecutingContext filterContext)
        //{

        //    String name = filterContext.HttpContext.Request.Path;
        //    if (name == null)
        //    {
        //        //重定向到登录页面  
        //        HttpContext.Response.Redirect("Home/Login");
        //        return;
        //    }
        //    base.OnActionExecuting(filterContext);
        //}
        ILog log = LogManager.GetLogger(Startup.Logrepository.Name, typeof(Startup));
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            var httpContext = context.HttpContext;
            var stopwach = httpContext.Items["costtime"] as Stopwatch;
            stopwach.Stop();
            var time = stopwach.Elapsed;
            if (time.TotalSeconds > 5)
            {
                log.Warn($"{httpContext.Request.Path}-{time.ToString()}-{HttpContextExtension.GetUserIp(httpContext)}");
            }
            else
            {
                log.Info($"{httpContext.Request.Path}-{HttpContextExtension.GetUserIp(httpContext)}");
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var stopwach = new Stopwatch();
            stopwach.Start();
            context.HttpContext.Items.Add("costtime", stopwach);
        }
    }
}
