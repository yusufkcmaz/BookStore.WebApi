﻿using BookStore.DataAccessLayer.Abstract;
using BookStore.DataAccessLayer.Context;
using BookStore.DataAccessLayer.Repositories;
using BookStore.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DataAccessLayer.EntityFramework
{
    public class EfWriterDal : GenericRepository<Writer>, IWriterDal
    {
        public EfWriterDal(BookStoreContext context) : base(context)
        {
        }
    }
}
