using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.DAL;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult CustomersIndex()
        {
            List<Customer> list = CustomerTableHelper.GetAllCustomersList();
            return View(list);
        }

        public ActionResult CustomersNew()
        {
            return View(new Customer());
        }

        public ActionResult CustomersSave(Customer CustomerValus)
        {
            ViewBag.customerName = "";
            ViewBag.customerCategory = "";
            ViewBag.customerAge = "";
            bool CustomerExsitValid = CustomerTableHelper.CustomerExsit(CustomerValus.CustomersName);

            if (ModelState.IsValid)
            {
                if (CustomerExsitValid)
                {
                    ViewBag.messageExsit = "Inputs Exsit";
                    ViewBag.customerName = "notvalid";
                    return View("CustomersNew", CustomerValus);
                }
                else
                {
                    CustomerTableHelper.AddCustome(CustomerValus.CustomersName, CustomerValus.CustomersSubscription, CustomerValus.CustomersAge);
                    return RedirectToAction("CustomersIndex");
                }
            }
            else
            {
                if (CustomerValus.CustomersName == null)
                {
                    ViewBag.customerName = "notvalid";
                }
                if (CustomerValus.CustomersSubscription == null)
                {
                    ViewBag.customerSubscription = "notvalid";
                }
                if (CustomerValus.CustomersAge == 0)
                {
                    ViewBag.customerAge = "notvalid";
                }
                return View("CustomersNew", CustomerValus);
            }

        }
    }
}