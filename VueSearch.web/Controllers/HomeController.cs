using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VueSearch.data;

namespace VueSearch.web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetSearchResults(string searchTerm)
        {
            var repo = new NorthwindRepository(Properties.Settings.Default.ConStr);
            return (Json(repo.SearchProductName(searchTerm), JsonRequestBehavior.AllowGet));
        }

        public ActionResult AmountToShow(string searchTerm, int num)
        {
            var repo = new NorthwindRepository(Properties.Settings.Default.ConStr);
            var products = repo.SearchProductName(searchTerm);
            if (num == 0)
            {
                num = products.Count();
            }
            return (Json(products.Take(num), JsonRequestBehavior.AllowGet));
        }

    }
}