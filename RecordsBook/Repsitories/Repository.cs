using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace RecordsBook.Repsitories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public IUnitOfWork UniOfWork { get; set; }

        private DbSet<T> _dbSet;

        private DbSet<T> dbSet
        {
            get {
                if ( _dbSet == null )
                {
                    _dbSet = UniOfWork.Context.Set<T>( );
                }
                return _dbSet;
            }
        }

        public Repository( IUnitOfWork unitOfWork)
        {
            UniOfWork = unitOfWork;
        }

        public IQueryable<T> LookupAll( )
        {
            return dbSet;
        }

        public IQueryable<T> Query( Expression<Func<T, bool>> filter )
        {
            return dbSet.Where( filter );
        }
    }
}