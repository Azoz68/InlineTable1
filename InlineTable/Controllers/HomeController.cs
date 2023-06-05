using InlineTable.Entities;
using InlineTable.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InlineTable.Controllers
{
    public class HomeController : Controller
    {
        private BookEntities1 db = new BookEntities1();
        public ActionResult Index()
        {
            var AutherName = db.Auther.ToList();
            var viewModel = new PostViewModel
            {
                authers = AutherName
            };
            return View(viewModel);
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