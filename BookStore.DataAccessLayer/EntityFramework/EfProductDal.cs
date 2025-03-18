using BookStore.DataAccessLayer.Abstract;
using BookStore.DataAccessLayer.Context;
using BookStore.DataAccessLayer.Repositories;
using BookStore.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DataAccessLayer.EntityFramework
{
    public class EfProductDal : GenericRepository<Product>, IProductDal
    {
        private readonly BookStoreContext _context;
        public EfProductDal(BookStoreContext context) : base(context)
        {
            _context = context;
        }

        public int GetProductCount()
        {
            //->2
            var context = new BookStoreContext();
            int value = context.Products.Count();
            return value;
        }
        public Product GetRandomProduct()
        {
           

            //return values;
            var product = _context.Set<Product>()
    .OrderBy(x => Guid.NewGuid())  // Rastgele sıralama
    .Take(1)
    .FirstOrDefault();
            return product;




        }





        public List<Product> GetAllProductsWithDetails()
        {
            //using var context = new BookStoreContext();
            return _context.Products
                  // Yazar tablosu ile ilişkilendirme
                .Include(p => p.Category) // Kategori tablosu ile ilişkilendirme
                
                .ToList();
        }

        public List<Product> GetProductsWithCategories()
        {
            return _context.Products
                .Include(p => p.Category)
              
                
                
                .ToList();
        }
    }




}