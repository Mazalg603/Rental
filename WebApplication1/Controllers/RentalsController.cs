using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.DAL;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class RentalsController : Controller
    {
        // GET: Rentals
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RentalsNew()
        {
            return View(new Rental());
        }

        [HttpPost]
        public ActionResult CreateNewRentals(Rental RentalValus)
        {
            bool TrueOrFalseMassege = true;
            string RentalMessges = "Movie rental successfully added";
            if (ModelState.IsValid)
            {
                bool RentalCustomerExsit = CustomerTableHelper.CustomerExsit(RentalValus.CostomerName);
                bool RentalMovieExsit = MoviesTableHelper.MovieExsit(RentalValus.MovieName);
                bool IsTheFilmRented = RentalsTableHelper.IsTheFilmRented(RentalValus.MovieName);

                if (RentalCustomerExsit)
                {
                    if (RentalMovieExsit)
                    {
                        if (IsTheFilmRented)
                        {
                            TrueOrFalseMassege = false;
                            RentalMessges = "The film is rented";
                        }
                        else
                        {
                            RentalsTableHelper.AddRentals(RentalValus.CostomerName, RentalValus.MovieName);
                            TrueOrFalseMassege = true;
                            RentalMessges = "Movie rental successfully added";
                        }
                    }
                    else
                    {
                        TrueOrFalseMassege = false;
                        RentalMessges = "Movie not Exsit";
                    }
                }
                else
                {
                    TrueOrFalseMassege = false;
                    RentalMessges = "Customer not Exsit";
                    if (RentalMovieExsit != true) RentalMessges += " Movie not found";
                }
            }
            else
            {
                TrueOrFalseMassege = false;
                ViewBag.succass = "succass";
                RentalMessges = "Movie rental successfully added";
            }
            var obj = new { RentalMessge = RentalMessges, MassegeBool = TrueOrFalseMassege };
            return Json(obj, JsonRequestBehavior.AllowGet);
        }
    }
}