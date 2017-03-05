using RecordsBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RecordsBook.Controllers
{
    public class HomeController : Controller
    {
        // GET: Homt
        public ActionResult Index()
        {
            return View();
        }        

        public ActionResult Detail( )
        {
            var homeModel = new HomeModel( );
            var details = homeModel.GetDetails( );

            return PartialView( details );
        }

    }
}