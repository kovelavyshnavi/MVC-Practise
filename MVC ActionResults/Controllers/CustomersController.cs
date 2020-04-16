using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_ActionResults.Models;

namespace MVC_ActionResults.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customer

        [Route("Customers")]
        public ViewResult Index()
        {
            var customers = GetCustomers();
            return View(customers);
        }
        
        public IEnumerable<Customers> GetCustomers()
        {
            return new List<Customers> {
                new Customers{Id=1, Name="Vaishnavi"},
                new Customers{Id=2, Name="Varnika"},
                new Customers{Id=3, Name="Yasaswini"},
                new Customers{Id=4, Name="Nithya"},
                new Customers{Id=5, Name="Kovela"},
                new Customers{Id=6, Name="Tiya"}
            };
        }

        public ActionResult Details(int? id)
        {
            var customer = GetCustomers().SingleOrDefault(c => c.Id == id);
            return View(customer);
        }



    }
}