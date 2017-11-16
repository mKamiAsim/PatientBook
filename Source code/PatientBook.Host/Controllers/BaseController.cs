using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientBook.Host.Controllers
{
    public class BaseController : Controller
    {
        private ILogger logger;

        public ILogger Logger
        {
            get
            {
                if (logger == null)
                {
                    var logFactory = HttpContext.RequestServices.GetService(typeof(ILoggerFactory)) as ILoggerFactory;

                    string name = this.GetType().FullName;

                    logger = logFactory.CreateLogger(name);
                }
                return logger;
            }
        }
      

    }
}
