using DoradcaWyjazdowWypoczynkowych.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace DoradcaWyjazdowWypoczynkowych
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();



            //Pliki output i kategorie.txt musza byc w C:\Dane... poki co
            Controllers.DataReaderController c = new Controllers.DataReaderController();
            DoradcaContext db = new DoradcaContext();
            db.Database.ExecuteSqlCommand("TRUNCATE TABLE [Atrakcja]");
            db.Database.ExecuteSqlCommand("DELETE FROM [OfertaGotowa]");
            db.Database.ExecuteSqlCommand("DELETE FROM [Kategoria]");
            c.ReadOfertaGotowaData();
            c.ReadKategoriaData();
            c.ReadAtrakcjaData();
        }
    }
}