using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoradcaWyjazdowWypoczynkowych.Controllers
{
    public class QuestionController : Controller
    {
        //
        // GET: /Question/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Search(DoradcaWyjazdowWypoczynkowych.Models.OcenaUzytkownika model)
        {
            ViewBag.Message = model.BliskoNatury.ToString();
            return View();    
        }


    }
}
