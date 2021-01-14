using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using MovieShop.Models;
using MovieShop.ViewModels;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace MovieShop.Controllers
{
    public class MoviesController : Controller
    {
        //1. By convention create private file DbContext named _context
        private ApplicationDbContext _context;

        //2.Constructor to initialize the _context
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        //3.Dispose the Disposable DbContext object
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult Index()
        {
            //var movies = _context.Movies;//Deferred execution or
            var movies = _context.Movies.Include(m => m.Genre).ToList();//By calling the ToList() method, the query is emediateli executed
            return View(movies);
        }

        public ActionResult Details(int id)
        {                                //Eager loading
            var movies = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);
            return View(movies);
        }

        public ActionResult New()
        {
            var genres = _context.Genres.ToList();

            var viewModel = new MovieFormViewModel
            {
                Genres = genres
            };
            return View("MovieForm", viewModel);
        }

        [HttpPost] //only be called when using HttpPost not HttpGet
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                //Return the view that returns the MovieForm
                var viewModel = new MovieFormViewModel(movie)
                {
                   // Movie = movie, //set Movie property to movie object
                    Genres = _context.Genres.ToList() //Genre from the context
                };
                return View("MovieForm", viewModel);

                //Otherwise add or updatate and redirect to:
            }

            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);

                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;
            };

            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);

            //After geting the movie from DB, check if that movie exists in the DB
            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel(movie)
            {
                Genres = _context.Genres.ToList()
            };
            return View("MovieForm", viewModel);
        }

        //Get: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };

            //list of customers - object initialization syntax
            var customers = new List<Customer>
            {
                new Customer { Name = "Customer 1" },
                new Customer { Name = "Customer 2" }
            };
            //create viewModel object
            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }
        //movies list of movies from the DB
        //public ActionResult Index(int? pageIndex, string sortBy)
        //{
        //    if (!pageIndex.HasValue)
        //        pageIndex = 1;
        //    if (String.IsNullOrWhiteSpace(sortBy))
        //        sortBy = "Name";
        //    return Content(string.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        //}

        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }


    }

}