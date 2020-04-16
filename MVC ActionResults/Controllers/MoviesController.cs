using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_ActionResults.Models;
using MVC_ActionResults.ViewModels;

namespace MVC_ActionResults.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movie
        
            [Route("Movies")]
        public ViewResult Index()
        {
            var movies = GetMovies();
            return View(movies);
        }


        public IEnumerable<Movie> GetMovies()
        {
            return new List<Movie> {
                new Movie{Id=1, Name="Titanic"},
                new Movie{Id=2, Name="Captain Marvel"},
                new Movie{Id=3, Name="Avengers"},
            };
        }


        public ActionResult Vidly()
        {
            return View();
        }

        [Route("movies/released/{year}/{month:regex(\\d{4}):range(1,12)}")]
        public ActionResult ByReleasedDate(int year, int month)
        {
            return Content(year + "/" + month); 

        }
    }
}