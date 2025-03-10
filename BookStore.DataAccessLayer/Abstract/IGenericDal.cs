﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DataAccessLayer.Abstract
{
    //Generic Repository Pattern.
    //Ortak bir veri erişim katmanı.
    public interface IGenericDal<T> where T : class
    {
        void Add(T entity); 
        void Delete(int id);
        void Update(T entity);
        List<T> GetAll();
        T GetById(int id);
        //
        //List<T> GetByPage(int pageNumber, int pageSize);

    }
}
