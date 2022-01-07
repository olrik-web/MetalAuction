using EntityFrameworkModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EksamenWeb.Controllers
{
    public class HomeController : Controller
    {
        public class Parameters
        {
            public string email { get; set; }
        }

        private EksamenDatabaseEntities db = new EksamenDatabaseEntities();

        [HttpGet]
        public ActionResult Index()
        {
            foreach (Køber k in db.Køber)
            {
                System.Diagnostics.Debug.WriteLine(k.email);
            }
            Parameters p = new Parameters { email = null};
            return View(p);
        }

        [HttpPost]
        public ActionResult Index(Parameters p)
        {
            foreach(Køber k in db.Køber)
            {
                if (p.email == k.email)
                {
                    Session["email"] = p.email;
                    return RedirectToAction("Index", "Salgsudbuds");
                }
            }
            return RedirectToAction("Create", "Køber", new { email = p.email});
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