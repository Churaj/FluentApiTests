using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FluentApiTests.DB;

namespace FluentApiTests.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (var dbContext = new SchoolDbContext())
            {
                var test = dbContext.Students.ToList();
            }

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}