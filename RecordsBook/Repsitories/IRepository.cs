using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RecordsBook.Repsitories
{
    public interface IRepository<T> where T : class
    {
        IUnitOfWork UniOfWork { get; set; }

        IQueryable<T> LookupAll();

        IQueryable<T> Query( Expression<Func<T, bool>> filter );

    }
}
