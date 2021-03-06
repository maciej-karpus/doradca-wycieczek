﻿using DoradcaWyjazdowWypoczynkowych.DAL;
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

          public ActionResult Feedback()
          {
               //Jakieś instancje klas Marka...
               return View();
          }

          public ActionResult Search(DoradcaWyjazdowWypoczynkowych.Models.OcenaUzytkownika evals)
          {
               //ViewData["recommendations"] = new List<KeyValuePair<Kategoria, double>>();
               var userMetric = new MetrykaKategorii(evals.Komfort, evals.Zwiedzanie,
                    evals.Aktywnosc, evals.Imprezowosc, evals.BliskoNatury);
               var metricList = getUserToCategoryMetric(userMetric);
               metricList.Sort((x, y) => x.Value.CompareTo(y.Value));
               //TOP7 kategorii dla danego użytkownika
               var categoriesTop = metricList.Take(7);
               ViewData["top_categories"] = new List<KeyValuePair<Kategoria, double>>(categoriesTop);
               ViewData["cat1"] = categoriesTop.ElementAt(0).Key.KategoriaNazwa;
               ViewData["cat2"] = categoriesTop.ElementAt(1).Key.KategoriaNazwa;
               ViewData["cat3"] = categoriesTop.ElementAt(2).Key.KategoriaNazwa;
               ViewData["cat4"] = categoriesTop.ElementAt(3).Key.KategoriaNazwa;
               ViewData["cat5"] = categoriesTop.ElementAt(4).Key.KategoriaNazwa;
               ViewData["cat6"] = categoriesTop.ElementAt(5).Key.KategoriaNazwa;
               ViewData["cat7"] = categoriesTop.ElementAt(6).Key.KategoriaNazwa;

               var attractionCategoryRelations = db.AtrakcjaKategoria.ToList();
               var distinctLocalisations = db.Atrakcja.Select(q => q.Lokalizacja).Distinct().ToList();
               //Słownik: lokalizacja, atrakcje z TOP kategorii z przypisanymi kategoriami, na podstawie których zostały wybrane
               var topCategoryAttractionsInLocalisations = new Dictionary<string,List<KeyValuePair<Atrakcja, string>>>();
               //Inicjalizacja słownika
               foreach (string distinctLocalisation in distinctLocalisations)
               {
                    topCategoryAttractionsInLocalisations.Add(distinctLocalisation.ToString(), 
                         new List<KeyValuePair<Atrakcja, string>>() );
               }

               foreach (var category in categoriesTop)
               {
                    //Pobranie wszystkich atrakcji, które są w kategorii TOP1, TOP2, ..., TOP7 wyboru dla danego użytkownika
                    var attractions = attractionCategoryRelations.Where(
                         q => q.Kategoria.KategoriaID == category.Key.KategoriaID).ToList();
                    foreach (var attraction in attractions)
                    {
                         string localisation = attraction.Atrakcja.Lokalizacja.ToString();
                         topCategoryAttractionsInLocalisations[localisation].Add(
                              new KeyValuePair<Atrakcja, string>(attraction.Atrakcja, category.Key.KategoriaNazwa));
                    }
               }

               var topRecommendations = topCategoryAttractionsInLocalisations.ToList();
               topRecommendations.Sort((x, y) => x.Value.Count().CompareTo(y.Value.Count()));
               topRecommendations.Reverse();
               //topRecommendations.Take(7);
               ViewData["top_recommendations"] = new List<KeyValuePair<string, List<KeyValuePair<Atrakcja, string>>>>
               (topRecommendations.Take(7));
               return View(ChartData.GetData(userMetric, new MetrykaKategorii(categoriesTop.ElementAt(0).Key),
                                                        new MetrykaKategorii(categoriesTop.ElementAt(1).Key),
                                                        new MetrykaKategorii(categoriesTop.ElementAt(2).Key),
                                                        new MetrykaKategorii(categoriesTop.ElementAt(3).Key),
                                                        new MetrykaKategorii(categoriesTop.ElementAt(4).Key),
                                                        new MetrykaKategorii(categoriesTop.ElementAt(5).Key),
                                                        new MetrykaKategorii(categoriesTop.ElementAt(6).Key)));
          }

          private List<KeyValuePair<Kategoria, double>> getUserToCategoryMetric(MetrykaKategorii userMetric)
          {
               var categoryList = db.Kategoria.ToList();
               var resultList = new List<KeyValuePair<Kategoria, double>>();
               foreach (Kategoria category in categoryList)
               {
                    var categoryMetric = new MetrykaKategorii(category);
                    double comparisionResult = userMetric.PorownajDopasowanie(categoryMetric);
                    resultList.Add(new KeyValuePair<Kategoria, double>(category, comparisionResult));
               }
               return resultList;
          }
     }
}


//  foreach (AtrakcjaKategoria categoryConnection in attraction.AtrakcjaKategoria.ToList())
//{
//     averagedCategory.Aktywnosc += categoryConnection.Kategoria.Aktywnosc;
//     averagedCategory.Zwiedzanie += categoryConnection.Kategoria.Zwiedzanie;
//     averagedCategory.BliskoNatury += categoryConnection.Kategoria.BliskoNatury;
//     averagedCategory.Komfort += categoryConnection.Kategoria.Komfort;
//     averagedCategory.Imprezowosc += categoryConnection.Kategoria.Imprezowosc;
//     counter++;
//}
//         try
//{
//     averagedCategory.Aktywnosc = (int)Math.Round((double)averagedCategory.Aktywnosc / counter);
//     averagedCategory.BliskoNatury = (int)Math.Round((double)averagedCategory.BliskoNatury / counter);
//     averagedCategory.Komfort = (int)Math.Round((double)averagedCategory.Komfort / counter);
//     averagedCategory.Imprezowosc = (int)Math.Round((double)averagedCategory.Imprezowosc / counter);
//     averagedCategory.Zwiedzanie = (int)Math.Round((double)averagedCategory.Zwiedzanie / counter);
//}
//catch (DivideByZeroException e) { throw new Exception("Nie ma żadnych przypisanych kategorii!"); }
//var metric = new MetrykaKategorii(averagedCategory);
//double magic = metric.PorownajDopasowanie(userMetric);
//((Dictionary<Atrakcja, double>)ViewData["recommendations"]).Add(attraction, magic);