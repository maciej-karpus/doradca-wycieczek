using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sample.Models;

namespace sample_razor.Controllers
{
    public class ChartController : Controller
    {
        //
        // GET: /Chart/

        public ActionResult DataSourceBinding()
        {
            return View(ChartData.GetData());
        }

    }
}
