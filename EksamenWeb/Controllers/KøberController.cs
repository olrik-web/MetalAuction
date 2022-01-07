using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EntityFrameworkModel;

namespace EksamenWeb.Controllers
{
    public class KøberController : Controller
    {
        private EksamenDatabaseEntities db = new EksamenDatabaseEntities();

        // GET: Køber
        public ActionResult Index()
        {
            return View(db.Køber.ToList());
        }

        // GET: Køber/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Køber køber = db.Køber.Find(id);
            if (køber == null)
            {
                return HttpNotFound();
            }
            return View(køber);
        }

        // GET: Køber/Create
        public ActionResult Create(string email)
        {
            Køber k = new Køber();
            k.email = email;
            return View();
        }

        // POST: Køber/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "KøberId,navn,tlf,email")] Køber køber)
        {
            if (ModelState.IsValid)
            {
                køber.KøberId = db.Køber.Count() + 1;
                db.Køber.Add(køber);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            return View(køber);
        }

        // GET: Køber/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Køber køber = db.Køber.Find(id);
            if (køber == null)
            {
                return HttpNotFound();
            }
            return View(køber);
        }

        // POST: Køber/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "KøberId,navn,tlf,email")] Køber køber)
        {
            if (ModelState.IsValid)
            {
                db.Entry(køber).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(køber);
        }

        // GET: Køber/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Køber køber = db.Køber.Find(id);
            if (køber == null)
            {
                return HttpNotFound();
            }
            return View(køber);
        }

        // POST: Køber/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Køber køber = db.Køber.Find(id);
            db.Køber.Remove(køber);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
