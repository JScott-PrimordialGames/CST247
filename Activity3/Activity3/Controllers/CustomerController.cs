using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using CustomerModel = Activity3.Models.CustomerModel;

using static System.Tuple;

namespace Activity3.Controllers
{
    public class CustomerController : Controller
    {
        private List<CustomerModel> customers { get; set; }

        public CustomerController()
        {
            CustomerModel Customer1 = new CustomerModel(1, "Tony Stark", 53);
            CustomerModel Customer2 = new CustomerModel(2, "Wanda Maximoff ", 44);
            CustomerModel Customer3 = new CustomerModel(3, "Stephen Strange", 49);

            customers = new List<CustomerModel>();

            customers.Add(Customer1);
            customers.Add(Customer2);
            customers.Add(Customer3);
        }

        // GET: Customer
        public ActionResult Index()
        {

            Tuple<List<CustomerModel>, CustomerModel> tuple = new Tuple<List<CustomerModel>, CustomerModel>(customers, customers[0]);

            return View(tuple);
        }

        [HttpPost]
        public ActionResult OnSelectCustomer(string Customer)
        {
            int id = int.Parse(Customer);
            CustomerModel cust = customers.Where(i => i.Id == id).First();

            Tuple<List<CustomerModel>, CustomerModel> tuple = new Tuple<List<CustomerModel>, CustomerModel>(this.customers, cust);

            return PartialView("_CustomerDetails", tuple.Item2);
        }
    }
}