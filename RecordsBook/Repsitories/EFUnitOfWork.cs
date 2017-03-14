﻿using RecordsBook.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RecordsBook.Repsitories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        public DbContext Context { get; set; }

        public EFUnitOfWork( )
        {
            Context = new SkillTreeHomeworkEntities( );
        }

        public void Dispose( )
        {
            throw new NotImplementedException( );
        }
    }
}