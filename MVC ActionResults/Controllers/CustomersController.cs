using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;

namespace MVC_ActionResults.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customer

        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [Route("Customers")]
        public ViewResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            return View(customers);
        }
        
        //public IEnumerable<Customers> GetCustomers()
        //{
        //    return new List<Customers> {
        //        new Customers{Id=1, Name="Vaishnavi"},
        //        new Customers{Id=2, Name="Varnika"},
        //        new Customers{Id=3, Name="Yasaswini"},
        //        new Customers{Id=4, Name="Nithya"},
        //        new Customers{Id=5, Name="Kovela"},
        //        new Customers{Id=6, Name="Tiya"}
        //    };
       // }

        public ActionResult Details(int? id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
            return View(customer);
        }

    }
}