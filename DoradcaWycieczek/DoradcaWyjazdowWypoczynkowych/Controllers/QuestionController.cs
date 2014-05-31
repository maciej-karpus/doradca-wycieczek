using DoradcaWyjazdowWypoczynkowych.DAL;
using DoradcaWyjazdowWypoczynkowych.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoradcaWyjazdowWypoczynkowych.Controllers
{
    public class QuestionController : Controller
    {
         private DoradcaContext db = new DoradcaContext();
         //
        // GET: /Question/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Search(DoradcaWyjazdowWypoczynkowych.Models.OcenaUzytkownika evals)
        {
             ViewData["recommendations"] = new Dictionary<Atrakcja, double>();
             var userMetric = new MetrykaKategorii(evals.Komfort, evals.Zwiedzanie, 
                  evals.Aktywnosc, evals.Imprezowosc, evals.BliskoNatury);
            var attractionList = db.Atrakcja.ToList();
            foreach (Atrakcja attraction in attractionList)
            {
                 int counter = 0;
                 Kategoria averagedCategory = new Kategoria();
                 foreach (AtrakcjaKategoria categoryConnection in attraction.AtrakcjaKategoria.ToList())
                 {
                      averagedCategory.Aktywnosc += categoryConnection.Kategoria.Aktywnosc;
                      averagedCategory.Zwiedzanie += categoryConnection.Kategoria.Zwiedzanie;
                      averagedCategory.BliskoNatury += categoryConnection.Kategoria.BliskoNatury;
                      averagedCategory.Komfort += categoryConnection.Kategoria.Komfort;
                      averagedCategory.Imprezowosc += categoryConnection.Kategoria.Imprezowosc;
                      counter++;
                 }
                 try
                 {
                      averagedCategory.Aktywnosc = (int)Math.Round((double)averagedCategory.Aktywnosc / counter);
                      averagedCategory.BliskoNatury = (int)Math.Round((double)averagedCategory.BliskoNatury / counter);
                      averagedCategory.Komfort = (int)Math.Round((double)averagedCategory.Komfort / counter);
                      averagedCategory.Imprezowosc = (int)Math.Round((double)averagedCategory.Imprezowosc / counter);
                      averagedCategory.Zwiedzanie = (int)Math.Round((double)averagedCategory.Zwiedzanie / counter);
                 }
                 catch (DivideByZeroException e) { throw new Exception("Nie ma żadnych przypisanych kategorii!"); }
                 var metric = new MetrykaKategorii(averagedCategory);
                 double magic = metric.PorownajDopasowanie(userMetric);
                 ((Dictionary<Atrakcja, double>)ViewData["recommendations"]).Add(attraction, magic);
            }
            return View();    
        }


    }
}
