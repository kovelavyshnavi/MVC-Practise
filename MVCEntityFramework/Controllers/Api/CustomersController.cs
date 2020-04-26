using AutoMapper;
using MVCEntityFramework.DTOs;
using MVCEntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;

namespace MVCEntityFramework.Controllers.Api
{
    public class CustomersController : ApiController
    {
		public ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/customers
        public IEnumerable<CustomerDTO> GetCustomers()
       {
            return _context.Customers.Include(c=>c.MembershipType).ToList().Select(Mapper.Map<Customers,CustomerDTO>);
        }

        //GET /api/customers/1
        public IHttpActionResult GetCustomers(int id)
        {
            var customers = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customers == null)
                return NotFound();
            return Ok(Mapper.Map<Customers, CustomerDTO>(customers));
        }

        //POST /api/customers
        [System.Web.Http.HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDTO customersDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var customers = Mapper.Map<CustomerDTO, Customers>(customersDTO);
            _context.Customers.Add(customers);
            _context.SaveChanges();

            customersDTO.Id = customers.Id;

            return Created(new Uri(Request.RequestUri + "/" + customers.Id), customersDTO);
        }


        //Befor AutoMapper code
        ////PUT /api/customers/1
        //[System.Web.Http.HttpPut]
        //public void UpdateCustomer(int id, Customers customers)
        //{
        //    if (!ModelState.IsValid)
        //        throw new HttpResponseException(HttpStatusCode.BadRequest);
        //    var customerInDB = _context.Customers.SingleOrDefault(c => c.Id == id);
        //    if (customerInDB == null)
        //        throw new HttpResponseException(HttpStatusCode.NotFound);
        //    customerInDB.Name = customers.Name;
        //    customerInDB.Birthdate = customers.Birthdate;
        //    customerInDB.IsSubscribedToNewsLetter = customers.IsSubscribedToNewsLetter;
        //    customerInDB.MembershipTypeId = customers.MembershipTypeId;
        //    _context.SaveChanges();
        //}


        //Using AutoMapper 
        //PUT /api/customers/1

        [System.Web.Http.HttpPut]
        public IHttpActionResult UpdateCustomerDTO(int id, CustomerDTO customerDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var customerInDB = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDB == null)
                return NotFound();
            Mapper.Map(customerDTO, customerInDB);
            _context.SaveChanges();
            return Ok();
        }

        //DELETE /api/customers/1
        [System.Web.Http.HttpDelete]
        public IHttpActionResult DeleteCustomers(int Id)
        {
            var customersInDB = _context.Customers.SingleOrDefault(c => c.Id == Id);
            if (customersInDB == null)
                return NotFound();
            _context.Customers.Remove(customersInDB);
            _context.SaveChanges();
            return Ok();
        }
    }
}

