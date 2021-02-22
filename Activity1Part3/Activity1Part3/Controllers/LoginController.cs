using Activity1Part3.Services.Business;
using Activity2Part3.Services.Utility;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Activity1Part3.Controllers
{
    public class LoginController : Controller
    {

        private static MyLogger logger = MyLogger.GetInstance().Value;

        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View("Login");
        }

        [HttpPost]
        public ActionResult Login(Activity1Part3.Models.UserModel model)
        {
            try
            {

                logger.Info("Entering LoginController.DoLogin()");

                if (!ModelState.IsValid)
                    return View("Login");
                Services.Business.SecurityService service = new Services.Business.SecurityService();

                logger.Info("Parameters are: " + new JavaScriptSerializer().Serialize(model));
                bool authenticated = service.Authenticate(model);

                if (authenticated)
                {
                    logger.Info("Exiting DoLogin() with pass");
                    return View("LoginPassed", model);
                }
                else
                {
                    logger.Info("Exiting DoLogin() with Login failed");
                    return View("LoginFailed");
                }
            } catch (Exception e)
            {
                logger.Error("Exception LoginController.DoLogin() " + e.Message);
            }
            return View("LoginFailed");
        }

        [HttpGet]
        [CustomAuthorization]
        public string Protected()
        {
            return "Test";
        }
        
    }
}