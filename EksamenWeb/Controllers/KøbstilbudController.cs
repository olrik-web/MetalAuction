using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EntityFrameworkModel;

namespace EksamenWeb.Controllers
{
    public class KøbstilbudController : Controller
    {
        private EksamenDatabaseEntities db = new EksamenDatabaseEntities();

        // GET: Købstilbud
        public ActionResult Index()
        {
            var købstilbud = db.Købstilbud.Include(k => k.Køber).Include(k => k.Salgsudbud);
            return View(købstilbud.ToList());
        }

        // GET: Købstilbud/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Købstilbud købstilbud = db.Købstilbud.Find(id);
            if (købstilbud == null)
            {
                return HttpNotFound();
            }
            return View(købstilbud);
        }

        // GET: Købstilbud/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Købstilbud/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "KøbstilbudId,pris,køberId,salgsudbudId")] Købstilbud købstilbud)
        {
            if (ModelState.IsValid)
            {
                købstilbud.salgsudbudId = int.Parse(Session["salgsudbudId"].ToString());
                decimal højestePris = 0;
                foreach(Købstilbud k in db.Købstilbud)
                {
                    if(k.salgsudbudId == købstilbud.salgsudbudId)
                    {
                        if (k.pris > højestePris)
                        {
                            højestePris = k.pris;
                        }
                    }
                }
                if (købstilbud.pris > højestePris)
                {
                    var email = Session["email"].ToString();
                    var id = (from k in db.Køber where k.email == email select k.KøberId).FirstOrDefault();
                    købstilbud.køberId = id;
                    købstilbud.KøbstilbudId = db.Købstilbud.Count() + 1;
                    db.Købstilbud.Add(købstilbud);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Salgsudbuds");
                } else
                {
                    System.Diagnostics.Debug.WriteLine("Angivet pris skal være højere end: " + højestePris);
                }
            }
            return View(købstilbud);
        }

        // GET: Købstilbud/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Købstilbud købstilbud = db.Købstilbud.Find(id);
            if (købstilbud == null)
            {
                return HttpNotFound();
            }
            ViewBag.køberId = new SelectList(db.Køber, "KøberId", "navn", købstilbud.køberId);
            ViewBag.salgsudbudId = new SelectList(db.Salgsudbuds, "SalgsudbudId", "metaltype", købstilbud.salgsudbudId);
            return View(købstilbud);
        }

        // POST: Købstilbud/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "KøbstilbudId,pris,køberId,salgsudbudId")] Købstilbud købstilbud)
        {
            if (ModelState.IsValid)
            {
                db.Entry(købstilbud).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.køberId = new SelectList(db.Køber, "KøberId", "navn", købstilbud.køberId);
            ViewBag.salgsudbudId = new SelectList(db.Salgsudbuds, "SalgsudbudId", "metaltype", købstilbud.salgsudbudId);
            return View(købstilbud);
        }

        // GET: Købstilbud/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Købstilbud købstilbud = db.Købstilbud.Find(id);
            if (købstilbud == null)
            {
                return HttpNotFound();
            }
            return View(købstilbud);
        }

        // POST: Købstilbud/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Købstilbud købstilbud = db.Købstilbud.Find(id);
            db.Købstilbud.Remove(købstilbud);
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
