using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Activity2Part1.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {

            List<Activity2Part1.Models.UserModel> users = new List<Activity2Part1.Models.UserModel>();

            Activity2Part1.Models.UserModel user = new Models.UserModel("John 117", "MasterChief@Xbox.com", "(123) 456-7890");
            Activity2Part1.Models.UserModel user2 = new Models.UserModel("Ikora Ray", "Warlock@Destiny.com", "(234) 567-8901");
            Activity2Part1.Models.UserModel user3 = new Models.UserModel("Samus Aran", "Huntress@chozo.com", "(345) 678-9123");
            Activity2Part1.Models.UserModel user4 = new Models.UserModel("Johnny Silverhand", "Rebel@Samurai.com", "(456) 789-0123");

            users.Add(user);
            users.Add(user2);
            users.Add(user3);
            users.Add(user4);


            return View("Test", users);
        }
    }
}