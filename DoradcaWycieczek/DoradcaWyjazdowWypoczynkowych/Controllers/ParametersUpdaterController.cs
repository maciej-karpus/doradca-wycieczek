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

        public void AddRating(int ocena, int komfort, int zwiedzanie, int aktywnosc, int imprezowosc, int BliskoNatury, OfertaGotowa oG)
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

        private void UpdateParameters(OfertaGotowa oG)
        {
            int komfort = 0, zwiedzanie = 0, aktywnosc = 0, imprezowosc = 0, bliskoNatury = 0;
            int i = 0;
            int ratingSum = 0;

            foreach (OcenaUzytkownika oU in oG.OcenaUzytkownikow)
            {
                int r = -(oU.GlownaOcena - 5); //Waga parametrów - im niższa ocena tym wieksza waga
                komfort += oU.Komfort * r;
                zwiedzanie += oU.Zwiedzanie * r;
                aktywnosc += oU.Aktywnosc * r;
                imprezowosc += oU.Imprezowosc * r;
                bliskoNatury += oU.BliskoNatury * r;
                ratingSum += r;
                i++;
            }

            oG.Komfort = WeightAvg(komfort, ratingSum);
            oG.Zwiedzanie = WeightAvg(zwiedzanie, ratingSum);
            oG.Aktywnosc = WeightAvg(aktywnosc, ratingSum);
            oG.Imprezowosc = WeightAvg(imprezowosc, ratingSum);
            oG.BliskoNatury = WeightAvg(bliskoNatury, ratingSum);


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
