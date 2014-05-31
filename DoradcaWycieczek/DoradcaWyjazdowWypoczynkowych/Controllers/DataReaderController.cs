using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoradcaWyjazdowWypoczynkowych.Models;
using DoradcaWyjazdowWypoczynkowych.DAL;
using System.Globalization;

namespace DoradcaWyjazdowWypoczynkowych.Controllers
{
    public class DataReaderController : Controller
    {

        private DoradcaContext db = new DoradcaContext();

        //
        // GET: /DataReader/

        public ActionResult Index()
        {
            return View();
        }



        public void ReadAtrakcjaData()
        {
             System.IO.StreamReader file = new System.IO.StreamReader(@"c:\Dane\atrakcje.txt");
             string city, attractionStr;

             while ((attractionStr = file.ReadLine()) != null)
             {
                  if (attractionStr.Length == 0) throw new Exception("Błąd importu danych");
                  var attractionFields = attractionStr.Split('\t');
                  int i = 0;
                  var attraction = new Atrakcja();
                  foreach (string attractionField in attractionFields)
                  {
                       if (i == 0) attraction.Lokalizacja = attractionField;
                       else if (i == 1) attraction.AtrakcjaNazwa = attractionField;
                       else if (i < attractionFields.Length - 1)
                       {
                            string categoryName = attractionField;
                            var matchedCategory = db.Kategoria.Where(q => q.KategoriaNazwa.Equals(attractionField)).ToList();
                            if (matchedCategory.Count != 1) continue;
                            else
                            {
                                 var attractionCategoryPair = new AtrakcjaKategoria();
                                 attractionCategoryPair.Atrakcja = attraction;
                                 attractionCategoryPair.Kategoria = matchedCategory[0];
                                 db.AtrakcjaKategoria.Add(attractionCategoryPair);
                                 if (attraction.AtrakcjaKategoria == null)
                                      attraction.AtrakcjaKategoria = new List<AtrakcjaKategoria>();
                                 attraction.AtrakcjaKategoria.Add(attractionCategoryPair);
                            }
                       }
                       else if (attractionField.Substring(0, 4).Equals("http"))
                       {
                            ;
                       }
                       i++;
                  }
                  db.Atrakcja.Add(attraction);
                  //Atrakcja atr = new Atrakcja();
                  //atr.Lokalizacja = city;
                  //atr.AtrakcjaNazwa = attraction;
                  //db.Atrakcja.Add(atr);
                  //db.SaveChanges();
             }
             db.SaveChanges();
        }


        public void ReadKategoriaData()
        {

            System.IO.StreamReader file = new System.IO.StreamReader(@"c:\Dane\kategorie.csv");
            string line, substr;
            file.ReadLine();
            while ((line = file.ReadLine()) != null)
            {
                Kategoria kategoria = new Kategoria();

                //Lp.
                substr = line.Substring(0, line.IndexOf(','));
                line = line.Substring(substr.Length + 1);
                kategoria.KategoriaID = Int32.Parse(substr);

                //Nazwa
                substr = line.Substring(0, line.IndexOf(','));
                line = line.Substring(substr.Length + 1);
                kategoria.KategoriaNazwa = substr;

                //Zwiedzanie
                substr = line.Substring(0, line.IndexOf(','));
                line = line.Substring(substr.Length + 1);
                kategoria.Zwiedzanie = Int32.Parse(substr);

                //Aktywnosc
                substr = line.Substring(0, line.IndexOf(','));
                line = line.Substring(substr.Length + 1);
                kategoria.Aktywnosc = Int32.Parse(substr);

                //Komfort
                substr = line.Substring(0, line.IndexOf(','));
                line = line.Substring(substr.Length + 1);
                kategoria.Komfort = Int32.Parse(substr);

                //Blisko natury i Imprezowosc
                substr = line.Substring(0, line.IndexOf(','));
                line = line.Substring(substr.Length + 1);
                kategoria.BliskoNatury = Int32.Parse(substr);
                kategoria.Imprezowosc = Int32.Parse(line);

                db.Kategoria.Add(kategoria);
                db.SaveChanges();
            }
        }


        public void ReadOfertaGotowaData()
        {
            List<string> files = new List<string>();
            string line;

            for (int i = 1; i < 11; i++)
            {
                files.Add(@"c:\Dane\output" + i + ".txt");
            }

            foreach (string path in files)
            {
                OfertaGotowa oferta = new OfertaGotowa();
                System.IO.StreamReader file = new System.IO.StreamReader(path);
                while ((line = file.ReadLine()) != null)
                {
                    int result = ProcessLine(oferta, line);
                    if (result == 2)
                    {
                        line = file.ReadLine();
                        string date = line.Substring(0, line.IndexOf(' '));
                        oferta.Data = DateTime.Parse(date);
                    }
                    if (result == 3)
                    {
                        string opis = "";
                        while ((line = file.ReadLine()) != null)
                        {
                            if (line.StartsWith("________"))
                            {
                                oferta.Opis = opis;
                                break;
                            }

                            opis += line;
                        }
                        if (oferta.Opis == null)
                            oferta.Opis = opis;

                        if (oferta.Data == DateTime.MinValue) oferta.Data = new DateTime(1999, 1, 1);

                        db.OfertaGotowa.Add(oferta);
                        db.SaveChanges();
                        oferta = new OfertaGotowa();
                    }

                }



            }
        }

        private int ProcessLine(OfertaGotowa oferta, string line)
        {
            if (line.StartsWith("Nazwa: "))
                oferta.Nazwa = line.Substring(line.IndexOf(' ') + 1);
            else if(line.StartsWith("Kod: "))
                oferta.Kod = line.Substring(5);
            else if (line.StartsWith("Transport: "))
                oferta.Transport = line.Substring(line.IndexOf(' ') + 1);
            else if (line.StartsWith("Cena:"))
                oferta.Koszt = Double.Parse(line.Substring(line.IndexOf(':') + 1), CultureInfo.InvariantCulture);
            else if (line.StartsWith("Liczba osób: "))
                oferta.LiczbaOsob = Int32.Parse(line.Substring(line.LastIndexOf(' ') + 1));
            else if (line.StartsWith("Czas trwania: "))
                oferta.CzasTrwania = Int32.Parse(line.Substring(line.LastIndexOf(' ') + 1));
            else if (line.StartsWith("Wyjazd dostępny w miesiącach:"))
                return 2;
            else if (line.StartsWith("Opis wycieczki:"))
                return 3;
            return 1;
        }

    }
}
