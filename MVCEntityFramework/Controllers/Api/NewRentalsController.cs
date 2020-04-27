using MVCEntityFramework.DTOs;
using MVCEntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace MVCEntityFramework.Controllers.Api
{
    public class NewRentalsController : ApiController
    {
        public ApplicationDbContext _context;
        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }

        [System.Web.Http.HttpPost]
        public IHttpActionResult CreateNewRental(RentalDTO rentalDTO)
        {
            var customers = _context.Customers.Single(c => c.Id == rentalDTO.CustomerId);
            var movies = _context.Movies.Where(c => rentalDTO.MovieIds.Contains(c.Id)).ToList();
            foreach(var movie in movies)
            {

                if (movie.NumberAvailable == 0)
                    return BadRequest("Movie is not available");

                movie.NumberAvailable--;
                var rental = new Rental()
                {
                    Customers = customers,
                    Movies = movie,
                    DateRented = DateTime.Now
                };
                _context.Rentals.Add(rental);
            }
           
            _context.SaveChanges();

            return Ok();
        }
    }
}
