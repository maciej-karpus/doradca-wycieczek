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
    public class OfertaGotowaController : Controller
    {
        private DoradcaContext db = new DoradcaContext();

        //
        // GET: /OfertaGotowa/

        public ActionResult Index()
        {
            return View(db.OfertaGotowa.ToList());
        }

        //
        // GET: /OfertaGotowa/Details/5

        public ActionResult Details(int id = 0)
        {
            OfertaGotowa ofertagotowa = db.OfertaGotowa.Find(id);
            if (ofertagotowa == null)
            {
                return HttpNotFound();
            }
            return View(ofertagotowa);
        }

        //
        // GET: /OfertaGotowa/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /OfertaGotowa/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OfertaGotowa ofertagotowa)
        {
            if (ModelState.IsValid)
            {
                db.OfertaGotowa.Add(ofertagotowa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ofertagotowa);
        }

        //
        // GET: /OfertaGotowa/Edit/5

        public ActionResult Edit(int id = 0)
        {
            OfertaGotowa ofertagotowa = db.OfertaGotowa.Find(id);
            if (ofertagotowa == null)
            {
                return HttpNotFound();
            }
            return View(ofertagotowa);
        }

        //
        // POST: /OfertaGotowa/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(OfertaGotowa ofertagotowa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ofertagotowa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ofertagotowa);
        }

        //
        // GET: /OfertaGotowa/Delete/5

        public ActionResult Delete(int id = 0)
        {
            OfertaGotowa ofertagotowa = db.OfertaGotowa.Find(id);
            if (ofertagotowa == null)
            {
                return HttpNotFound();
            }
            return View(ofertagotowa);
        }

        //
        // POST: /OfertaGotowa/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OfertaGotowa ofertagotowa = db.OfertaGotowa.Find(id);
            db.OfertaGotowa.Remove(ofertagotowa);
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