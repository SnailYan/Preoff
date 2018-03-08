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
                log.Warn($"{HttpContextExtension.GetUserIp(httpContext)}-{httpContext.Request.Path}-{time.ToString()}");
            }
            else
            {
                log.Info($"{HttpContextExtension.GetUserIp(httpContext)}-{httpContext.Request.Path}");
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
