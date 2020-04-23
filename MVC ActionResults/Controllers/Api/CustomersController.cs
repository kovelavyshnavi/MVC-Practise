using MVC_ActionResults.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using Vidly.Models;

namespace MVC_ActionResults.Controllers.Api
{
    public class CustomersController : ApiController
    {
        public ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/customers
        public IEnumerable<Customers> GetCustomers()
        {
            return _context.Customers.ToList();
        }

        //GET /api/customers/1
        public Customers GetCustomers(int id)
        {
            var customers = _context.Customers.SingleOrDefault(c => c.Id == id);
            if(customers==null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return customers;
        }

        //POST /api/customers
        [System.Web.Http.HttpPost]
        public Customers CreateCustomer(Customers customers)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            _context.Customers.Add(customers);
            _context.SaveChanges();
            return customers;
        }

        //PUT /api/customers/1
        [System.Web.Http.HttpPut]
        public void UpdateCustomer(int id, Customers customers)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var customerInDB = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            customerInDB.Name = customers.Name;
            customerInDB.Birthdate = customers.Birthdate;
            customerInDB.IsSubscribedToNewsLetter = customers.IsSubscribedToNewsLetter;
            customerInDB.MembershipTypeId = customers.MembershipTypeId;
            _context.SaveChanges();
        }

        //DELETE /api/customers/1
        [System.Web.Http.HttpDelete]
        public void DeleteCustomers(int Id)
        {
            var customersInDB = _context.Customers.SingleOrDefault(c => c.Id == Id);
            if (customersInDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Customers.Remove(customersInDB);
            _context.SaveChanges();
        }
    }
}
