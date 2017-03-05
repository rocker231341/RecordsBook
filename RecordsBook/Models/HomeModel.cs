using RecordsBook.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecordsBook.Models
{
    public class HomeModel
    {

        public List<DetailViewModel> GetDetails( )
        {
            var details = new List<DetailViewModel>( );
            for ( int i = 1 ; i <= 3 ; i++ )
            {
                var detail = new DetailViewModel
                {
                    GroupName = "支出",
                    Date = DateTime.Now.AddDays( i-1 ),
                    Money = i * 400
                };
                details.Add( detail );
            }

            return details;
        }

    }
}