using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using Unity;

using ILogger = Activity1Part3.Services.Utility.ILogger;

namespace Activity1Part3.Controllers
{
    public class TestLoggingService2Controller : Controller
    {
        [Dependency]
        public ILogger logger { get; set; }

        // GET: TestLoggingService2
        public string Index()
        {
            this.logger.Info("TestLogginService2Controller");

            return "TestLogginService2Controller";
        }
    }
}