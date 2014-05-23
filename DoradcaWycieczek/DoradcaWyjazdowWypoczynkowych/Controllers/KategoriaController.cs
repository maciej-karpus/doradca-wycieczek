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
    public class KategoriaController : Controller
    {
        private DoradcaContext db = new DoradcaContext();

        //
        // GET: /Kategoria/

        public ActionResult Index()
        {
            return View(db.Kategoria.ToList());
        }

        //
        // GET: /Kategoria/Details/5

        public ActionResult Details(int id = 0)
        {
            Kategoria kategoria = db.Kategoria.Find(id);
            if (kategoria == null)
            {
                return HttpNotFound();
            }
            return View(kategoria);
        }

        //
        // GET: /Kategoria/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Kategoria/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Kategoria kategoria)
        {
            if (ModelState.IsValid)
            {
                db.Kategoria.Add(kategoria);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kategoria);
        }

        //
        // GET: /Kategoria/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Kategoria kategoria = db.Kategoria.Find(id);
            if (kategoria == null)
            {
                return HttpNotFound();
            }
            return View(kategoria);
        }

        //
        // POST: /Kategoria/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Kategoria kategoria)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kategoria).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kategoria);
        }

        //
        // GET: /Kategoria/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Kategoria kategoria = db.Kategoria.Find(id);
            if (kategoria == null)
            {
                return HttpNotFound();
            }
            return View(kategoria);
        }

        //
        // POST: /Kategoria/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kategoria kategoria = db.Kategoria.Find(id);
            db.Kategoria.Remove(kategoria);
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