using RecordsBook.Models.ViewModels;
using RecordsBook.Repsitories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecordsBook.Models
{
    public class HomeService
    {
        private readonly IRepository<AccountBook> _recordRep;
        private readonly IUnitOfWork _unitOfWork;


        public HomeService(IUnitOfWork unitOfWork )
        {            
            _unitOfWork = unitOfWork;
            _recordRep = new Repository<AccountBook>( unitOfWork );
        }        

        public List<RecordDetailViewModel> GetRecordDetails( int? year, int? month )
        {

            var latestDate = GetLatestRecordDate( );
            year = ( year == null ? latestDate.Year : year );
            month = ( month == null ? latestDate.Month : month );

            var startDate = new DateTime( (int)year, ( int ) month, 1 );
            var endDate = startDate.AddMonths( 1 );

            var details = _recordRep
                .Query( m => m.Dateee >= startDate && m.Dateee < endDate )
                .OrderByDescending( m => m.Dateee )
                .Select( m => new RecordDetailViewModel
                {
                    GroupName = m.Categoryyy == 0 ? "支出" : "收入",
                    Money = m.Amounttt,
                    Date = m.Dateee
                } ).ToList( );

            return details;
        }

        public DateTime GetLatestRecordDate( )
        {
            var date = _recordRep.LookupAll()
                          .OrderByDescending( m => m.Dateee )
                          .Select( m => m.Dateee )
                          .FirstOrDefault( );
           
            return date;
        }

        public List<int> GetSearchYears( )
        {
            var years = new List<int>( );
            int start = 2016;
            int end = DateTime.Now.Year;
            for ( ; start <= end ; start++ )
            {
                years.Add( start );
            }

            return years.OrderByDescending( m => m ).ToList();
        }

    }
}