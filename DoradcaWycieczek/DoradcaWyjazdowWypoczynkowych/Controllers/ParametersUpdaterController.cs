using DoradcaWyjazdowWypoczynkowych.DAL;
using DoradcaWyjazdowWypoczynkowych.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoradcaWyjazdowWypoczynkowych.Controllers
{
    public class ParametersUpdaterController : Controller
    {
        private DoradcaContext db = new DoradcaContext();

        //
        // GET: /ParametersUpdater/


        public ActionResult Index()
        {
            return View();
        }
        public void AddRatings(OcenaUzytkownika[] oceny)
        {
            for (int i = 0; i < oceny.Count(); i++ )
            {
                OcenaUzytkownika oU = new OcenaUzytkownika();
                OcenaUzytkownika propozycja = oceny[i];
                oU.GlownaOcena = propozycja.GlownaOcena;
                oU.Komfort = propozycja.Komfort;
                oU.Zwiedzanie = propozycja.Zwiedzanie;
                oU.Aktywnosc = propozycja.Aktywnosc;
                oU.Imprezowosc = propozycja.Imprezowosc;
                oU.BliskoNatury = propozycja.BliskoNatury;
                oU.Kategoria = propozycja.Kategoria;

                db.OcenaUzytkownika.Add(oU);
                db.SaveChanges();

                //Ile ocen dla tej kategorii
                List<OcenaUzytkownika> ocenione = db.OcenaUzytkownika.Where(o => o.Kategoria.KategoriaID == propozycja.Kategoria.KategoriaID).ToList();

                if (ocenione.Count() == 10)
                {
                    UpdateParameters(propozycja.Kategoria, ocenione);

                    //Usun wykorzystane oceny
                    foreach(OcenaUzytkownika o in ocenione)  db.OcenaUzytkownika.Remove(o);
                    db.SaveChanges();
                }

            }
        }

        /*public void AddRating(int ocena, int komfort, int zwiedzanie, int aktywnosc, int imprezowosc, int BliskoNatury, OfertaGotowa oG)
        {
            OcenaUzytkownika oU = new OcenaUzytkownika();
            oU.GlownaOcena = ocena;
            oU.Komfort = komfort;
            oU.Zwiedzanie = zwiedzanie;
            oU.Aktywnosc = aktywnosc;
            oU.Imprezowosc = imprezowosc;
            oU.BliskoNatury = BliskoNatury;
            oG.OcenaUzytkownikow.Add(oU);

            if (oG.OcenaUzytkownikow.Count == 10)
            {
                UpdateParameters(oG);
                oG.OcenaUzytkownikow.Clear(); //Ewentualny backup ocen
            }

            db.SaveChanges();
        }
        */


        private void UpdateParameters(Kategoria kat, List<OcenaUzytkownika> oU)
        {
            int komfort = 0, zwiedzanie = 0, aktywnosc = 0, imprezowosc = 0, bliskoNatury = 0;
            int i = 0;
            int ratingSum = 0;

            foreach (OcenaUzytkownika o in oU)
            {
                int r = -(o.GlownaOcena - 5); //Waga parametrów - im niższa ocena tym wieksza waga
                komfort += o.Komfort * r;
                zwiedzanie += o.Zwiedzanie * r;
                aktywnosc += o.Aktywnosc * r;
                imprezowosc += o.Imprezowosc * r;
                bliskoNatury += o.BliskoNatury * r;
                ratingSum += r;
                i++;
            }

            kat.Komfort = WeightAvg(komfort, ratingSum);
            kat.Zwiedzanie = WeightAvg(zwiedzanie, ratingSum);
            kat.Aktywnosc = WeightAvg(aktywnosc, ratingSum);
            kat.Imprezowosc = WeightAvg(imprezowosc, ratingSum);
            kat.BliskoNatury = WeightAvg(bliskoNatury, ratingSum);

        }

        private int WeightAvg(int data, int sum)
        {
            double ratio = (double)(data / sum);
            double point = ratio - (int)(data / sum);
            if (point >= 0.5) ratio++;

            return (int)ratio;
        }
    }
}
