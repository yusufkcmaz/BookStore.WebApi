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
            //int count = _context.Set<Product>().Count();
            //Random random = new Random();
            //int randomIndex = new Random().Next(1, count);
            //var values = _context.Set<Product>()
            //    .Skip(randomIndex)
            //    .Take(1)
            //    .FirstOrDefault();

            //return values;
            var product = _context.Set<Product>()
    .OrderBy(x => Guid.NewGuid())  // Rastgele sıralama
    .Take(1)
    .FirstOrDefault();
            return product;




            //int count = _context.Set<Product>().Count();



            //Random random = new Random();
            //int randomIndex = random.Next(0, count);

            //// Rastgele ürünü al
            //var product = _context.Set<Product>()
            //                      .Skip(randomIndex)
            //                      .Take(1)
            //                      .Include(p => p.Writer)   // Writer ile ilişkiyi dahil et
            //                      .Include(p => p.Category)  // Category ile ilişkiyi dahil et
            //                      .FirstOrDefault(); // Sadece 1 ürün al

            //return product;
        }





        public List<Product> GetAllProductsWithDetails()
        {
            //using var context = new BookStoreContext();
            return _context.Products
                .Include(p => p.Writer)  // Yazar tablosu ile ilişkilendirme
                .Include(p => p.Category) // Kategori tablosu ile ilişkilendirme
                .ToList();
        }

        public List<Product> GetProductsWithCategories()
        {
            return _context.Products
                .Include(p => p.Category)
                .Include(p => p.Writer)
                .ToList();
        }
    }




}