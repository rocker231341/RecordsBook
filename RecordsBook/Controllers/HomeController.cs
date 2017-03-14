using RecordsBook.Models;
using RecordsBook.Repsitories;
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
        public ActionResult Index( )
        {
            return View( );
        }

        public ActionResult RecordDetails( int? year, int? month )
        {
            var unitOfWork = new EFUnitOfWork( );
            var homeService = new HomeService( unitOfWork );           

            var details = homeService.GetRecordDetails( year, month );
            return PartialView( details );
        }

        [ChildActionOnly]
        public ActionResult SearchRecord( )
        {
            var unitOfWork = new EFUnitOfWork( );
            var homeService = new HomeService( unitOfWork );
            var latestDate = homeService.GetLatestRecordDate( );
            var yeas = homeService.GetSearchYears( );

            ViewBag.LatestDate = latestDate;
            ViewData [ "years" ] = yeas;

            return PartialView( );
        }

    }
}