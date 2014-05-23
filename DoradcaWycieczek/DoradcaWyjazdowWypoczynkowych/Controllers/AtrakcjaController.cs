using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoradcaWyjazdowWypoczynkowych.Models;
using DoradcaWyjazdowWypoczynkowych.DAL;

namespace DoradcaWyjazdowWypoczynkowych.Controllers
{
    public class AtrakcjaController : Controller
    {
        private DoradcaContext db = new DoradcaContext();

        //
        // GET: /Atrakcja/

        public ActionResult Index()
        {
            return View(db.Atrakcja.ToList());
        }

        //
        // GET: /Atrakcja/Details/5

        public ActionResult Details(int id = 0)
        {
            Atrakcja atrakcja = db.Atrakcja.Find(id);
            if (atrakcja == null)
            {
                return HttpNotFound();
            }
            return View(atrakcja);
        }

        //
        // GET: /Atrakcja/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Atrakcja/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Atrakcja atrakcja)
        {
            if (ModelState.IsValid)
            {
                db.Atrakcja.Add(atrakcja);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(atrakcja);
        }

        //
        // GET: /Atrakcja/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Atrakcja atrakcja = db.Atrakcja.Find(id);
            if (atrakcja == null)
            {
                return HttpNotFound();
            }
            return View(atrakcja);
        }

        //
        // POST: /Atrakcja/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Atrakcja atrakcja)
        {
            if (ModelState.IsValid)
            {
                db.Entry(atrakcja).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(atrakcja);
        }

        //
        // GET: /Atrakcja/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Atrakcja atrakcja = db.Atrakcja.Find(id);
            if (atrakcja == null)
            {
                return HttpNotFound();
            }
            return View(atrakcja);
        }

        //
        // POST: /Atrakcja/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Atrakcja atrakcja = db.Atrakcja.Find(id);
            db.Atrakcja.Remove(atrakcja);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}