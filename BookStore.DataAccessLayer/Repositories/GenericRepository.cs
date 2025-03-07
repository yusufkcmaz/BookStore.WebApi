﻿using BookStore.DataAccessLayer.Abstract;
using BookStore.DataAccessLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DataAccessLayer.Repositories
{
    //Design Pattern : Generic Repository Pattern
    //Generic Repository Pattern kullanır.

    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        private readonly BookStoreContext _context;

        public GenericRepository(BookStoreContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);  
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
           var value = _context.Set<T>().Find(id);
            _context.Set<T>().Remove(value);
            _context.SaveChanges(); 
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Update(T entity)
        {
           _context.Set<T>().Update(entity);
            _context.SaveChanges();
        }

        //Buraya da tanımlanabilir metod refaktör
    }
}
