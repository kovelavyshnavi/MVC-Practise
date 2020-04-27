using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using MVCEntityFramework.Models;
using MVCEntityFramework.ViewModels;


namespace MVCEntityFramework.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movie


        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();   
        }

        [Route("Movies")]
        public ViewResult Index()
        {
            //var movies = _context.Movies.Include(a=>a.Genre).ToList();
            if (User.IsInRole(RoleName.CanManageMovies))
                return View("Index_old");

            return View("ReadOnlyList");
        }

        //Getting Genres from Db and binding to dropdown through viewmodel
        [Authorize(Roles =RoleName.CanManageMovies)]
        public ActionResult MoviesForm()
        {
            var genres = _context.Genres.ToList();

            var movieViewModel = new MovieViewModel();
            {
                movieViewModel.Genres = genres;
            }
            return View(movieViewModel);
        }


        //Used  this method for both add & edit movie records
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Save(Movies movies)
        {
            if(!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                var viewModels = new MovieViewModel(movies)
                {
                    Id=movies.Id,
                    Name=movies.Name,
                    ReleaseDate=movies.ReleaseDate,
                    GenreId=movies.GenreId,
                    NumberInStock=movies.NumberInStock,
                    Genres = _context.Genres.ToList()
                };
                return View("MoviesForm", viewModels);
            }

            if (movies.Id == 0)
            {
                movies.DateAdded = DateTime.Now;
                _context.Movies.Add(movies);
            }
            else
            {
               var moviesinDB= _context.Movies.Single(c => c.Id == movies.Id);
                moviesinDB.Name=movies.Name;
                moviesinDB.GenreId=movies.GenreId;
                moviesinDB.ReleaseDate=movies.ReleaseDate ;
                moviesinDB.DateAdded=movies.DateAdded ;
                moviesinDB.NumberInStock=movies.NumberInStock ;
            }
            _context.SaveChanges();
            return RedirectToAction("Index","Movies");
        }

        //public IEnumerable<Movies> GetMovies()
        //{
        //    return new List<Movies> {
        //        new Movies{Id=1, Name="Titanic"},
        //        new Movies{Id=2, Name="Captain Marvel"},
        //        new Movies{Id=3, Name="Avengers"},
        //    };
        //}


        public ActionResult Vidly()
        {
            return View();
        }

        public ActionResult Details(int? id)
        {
            var movie = _context.Movies.Include(c => c.Genre).SingleOrDefault(c => c.Id == id);
            if (movie == null)
                return HttpNotFound();
            return View(movie);
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Edit(int id)
        {
            var movies = _context.Movies.SingleOrDefault(c => c.Id == id);
            var viewmodel = new MovieViewModel(movies);
            {
                //viewmodel.Movies = movies;
                viewmodel.Genres = _context.Genres.ToList();
            }
            return View("MoviesForm",viewmodel);
        }
    }
}