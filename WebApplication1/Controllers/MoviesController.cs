using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.DAL;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class MoviesController : Controller
    {   // GET: Movies
        public ActionResult MoviesIndex()
        {
            // Action takes a list from a class where the list of movies is built
            List<Movie> list = MoviesTableHelper.GetAllMovieList();
            // מעביר בוויו את הרשימה
            return View(list);
        }

        public ActionResult MoviesNew()
        {
            return View(new Movie());
        }

        [HttpPost]
        public ActionResult MoviesSave(Movie MoviesValus)
        {
            // Boolean variable that holds the result if the movie exists or not
            // המשתנה מקבל ניימספייס של קלאס בו בנוייה הפונקציה שמקבלת שם של סרט ומחזירה תוצאה בערך בוליאני
            bool MovieExsitValid = MoviesTableHelper.MovieExsit(MoviesValus.MovieName);

            ViewBag.MovieClass = "";
            ViewBag.CategoryClass = "";

            if (ModelState.IsValid)
            {
                if (MovieExsitValid)
                {
                    ViewBag.messageExsit = "The Movie Name Inputs Exsit";
                    ViewBag.MovieClass = "notvalid";
                    return View("MoviesNew", MoviesValus);
                }
                else
                {
                    MoviesTableHelper.AddMovie(MoviesValus.MovieName, MoviesValus.MovieCategory);
                    return RedirectToAction("MoviesIndex");
                }
            }
            else
            {
                if (MoviesValus.MovieName == null)
                {
                    ViewBag.MovieClass = "notvalid";
                }
                if (MoviesValus.MovieCategory == null)
                {
                    ViewBag.CategoryClass = "notvalid";
                }
                return View("MoviesNew", MoviesValus);
            }
        }
    }
}