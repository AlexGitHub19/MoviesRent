using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MoviesRent.Models;

namespace MoviesRent.Controllers
{
    public class HomeController : Controller
    {
        List<Movie> movies = new List<Movie>();

        public ActionResult Index()
        {
            CreateMovies();

            CreateListOfMoviesNamesAndWriteItToViewBag();
            return View(movies);
        }

        [HttpPost]
        public ActionResult Index(string DropDawnListMovies, string NumberOfDays)
        {
            CreateMovies();

            CreateListOfMoviesNamesAndWriteItToViewBag();

            foreach (Movie m in movies)
            {
                if (m.Name == DropDawnListMovies)
                {
                    
                    string result = "It will cost: " +Convert.ToInt32(NumberOfDays)*m.Price;
                    ViewBag.OrderPrice = result;
                }
            }

            return View(movies);
        }

        void CreateMovies()
        {
            movies.Add(new Movie { Name = "Interstellar", Price = 20, ImagePath = "/Content/Interstellar2.jpg" });
            movies.Add(new Movie { Name = "Inception", Price = 10, ImagePath = Url.Content("~/Content/Inception2.jpg") });
            movies.Add(new Movie { Name = "Avengers", Price = 15, ImagePath = Url.Content("~/Content/Avengers2.jpg") });
        }

        void CreateListOfMoviesNamesAndWriteItToViewBag()
        {
            string[] moviesNames = new string[movies.Count];
            for (int i = 0; i < movies.Count; i++)
            {
                moviesNames[i] = movies[i].Name;
            }
            ViewBag.DropDawnListMovies = new SelectList(moviesNames);

        }
    }
}