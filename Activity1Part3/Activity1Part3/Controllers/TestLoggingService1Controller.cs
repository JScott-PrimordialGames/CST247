﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using ILogger = Activity2Part3.Services.Utility.ILogger;

namespace Activity1Part3.Controllers
{
    public class TestLoggingService1Controller : Controller
    {
        private readonly ILogger logger;

        public TestLoggingService1Controller(ILogger logger)
        {
            this.logger = logger;
        }


        // GET: TestLoggingService1
        public string Index()
        {
            this.logger.Info("TestLoggingService1 Controller");

            return "TestLoggingService1 Controller";
        }
    }
}