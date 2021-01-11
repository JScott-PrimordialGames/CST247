using Activity1Part3.Services.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Activity1Part3.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View("Login"); 
        }

        [HttpPost]
        public ActionResult Login(Models.UserModel model)
        {
            SecurityService service = new SecurityService();
            bool result = service.Authenticate(model);
            if (result)
                return View("LoginPassed");
            else
                return View("LoginFailed");
            
        }

    }
}