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
    public class SalgsudbudsController : Controller
    {
        private EksamenDatabaseEntities db = new EksamenDatabaseEntities();

        // GET: Salgsudbuds
        public ActionResult Index()
        {
            return View(db.Salgsudbuds.ToList());
        }


        // GET: Salgsudbuds/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salgsudbud salgsudbud = db.Salgsudbuds.Find(id);
            if (salgsudbud == null)
            {
                return HttpNotFound();
            }
            Session["salgsudbudId"] = id;
            return View(salgsudbud);
        }

        // GET: Salgsudbuds/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Salgsudbuds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SalgsudbudId,metaltype,mængde,tidsfrist")] Salgsudbud salgsudbud)
        {
            if (ModelState.IsValid)
            {
                db.Salgsudbuds.Add(salgsudbud);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(salgsudbud);
        }

        // GET: Salgsudbuds/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salgsudbud salgsudbud = db.Salgsudbuds.Find(id);
            if (salgsudbud == null)
            {
                return HttpNotFound();
            }
            return View(salgsudbud);
        }

        // POST: Salgsudbuds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SalgsudbudId,metaltype,mængde,tidsfrist")] Salgsudbud salgsudbud)
        {
            if (ModelState.IsValid)
            {
                db.Entry(salgsudbud).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(salgsudbud);
        }

        // GET: Salgsudbuds/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salgsudbud salgsudbud = db.Salgsudbuds.Find(id);
            if (salgsudbud == null)
            {
                return HttpNotFound();
            }
            return View(salgsudbud);
        }

        // POST: Salgsudbuds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Salgsudbud salgsudbud = db.Salgsudbuds.Find(id);
            db.Salgsudbuds.Remove(salgsudbud);
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
