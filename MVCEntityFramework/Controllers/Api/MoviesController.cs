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
    public class MoviesController : ApiController
    {
            public ApplicationDbContext _context;
            public MoviesController()
            {
                _context = new ApplicationDbContext();
            }

            //GET /api/movies
            public IEnumerable<MovieDTO> GetMovies()
            {
                return _context.Movies.Include(c=>c.Genre).ToList().Select(Mapper.Map<Movies, MovieDTO>);
            }

            //GET /api/movies/1
            public IHttpActionResult GetMovies(int id)
            {
                var movies = _context.Movies.SingleOrDefault(c => c.Id == id);
                if (movies == null)
                    return NotFound();
                return Ok(Mapper.Map<Movies, MovieDTO>(movies));
            }

            //POST /api/movies
            [System.Web.Http.HttpPost]
            public IHttpActionResult CreateMovie(MovieDTO movieDTO)
            {
                if (!ModelState.IsValid)
                    return BadRequest();
                var movies = Mapper.Map<MovieDTO, Movies>(movieDTO);
                _context.Movies.Add(movies);
                _context.SaveChanges();
                movieDTO.Id = movies.Id;
                return Created(new Uri(Request.RequestUri + "/" + movies.Id), movieDTO);
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
            public IHttpActionResult UpdateMovieDTO(int id, MovieDTO movieDTO)
            {
                if (!ModelState.IsValid)
                    return BadRequest();
                var movieInDB = _context.Movies.SingleOrDefault(c => c.Id == id);
                if (movieInDB == null)
                    return NotFound();
                Mapper.Map(movieDTO, movieInDB);

                _context.SaveChanges();

                return Ok();
            }

            //DELETE /api/movies/1
            [System.Web.Http.HttpDelete]
            public IHttpActionResult DeleteMovies(int Id)
            {
                var moviesInDB = _context.Movies.SingleOrDefault(c => c.Id == Id);
                if (moviesInDB == null)
                    return NotFound();
                _context.Movies.Remove(moviesInDB);
                _context.SaveChanges();
                return Ok();
            }
        }

    }
