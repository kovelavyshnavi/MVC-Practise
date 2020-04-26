using MVCEntityFramework.Models;
using MVCEntityFramework.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;


namespace MVCEntityFramework.Controllers
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

        //Get all the customer details in pageload
        [Route("Customers")]
        public ViewResult Index()
        {

            //var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            //return View(customers);
            return View();
        }

        //Adding the customer details
        //For MemberShipType Dropdown
        public ActionResult CustomerForm()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var customerViewModel = new CustomerViewModel
            {
                Customers = new Customers(),
                MembershipTypes = membershipTypes
            };
            return View(customerViewModel);
        }


        //Adding and Updating the customer details into DB

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customers customers)
        {

            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                var viewmodel = new CustomerViewModel
                {
                    Customers = customers,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };

                return View("CustomerForm", viewmodel);
            }

            if (customers.Id == 0)
            {
                _context.Customers.Add(customers);
            }
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customers.Id);
                customerInDb.Name = customers.Name;
                customerInDb.Birthdate = customers.Birthdate;
                customerInDb.MembershipTypeId = customers.MembershipTypeId;
                customerInDb.IsSubscribedToNewsLetter = customers.IsSubscribedToNewsLetter;
            }
            _context.SaveChanges();

           // _context.Entry(customers).ReloadAsync();
            return RedirectToAction("Index", "Customers");
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
            if (customer == null)
                return HttpNotFound();
            return View(customer);
        }

        //Editing the Customer details
        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            var viewModel = new CustomerViewModel();
            {
                viewModel.Customers = customer;
                viewModel.MembershipTypes = _context.MembershipTypes.ToList();
            }

            return View("CustomerForm",viewModel);
        }

        
    }
}