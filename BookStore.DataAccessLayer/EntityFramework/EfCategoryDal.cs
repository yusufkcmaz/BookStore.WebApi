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
   
    public class EfCategoryDal : GenericRepository<Category>, ICategoryDal
    {
        public EfCategoryDal(BookStoreContext context) : base(context)
        {
            
        }

        public List<Product> GetCategoriesWithProducts()
        {
            var  context = new BookStoreContext();
            return context.Products
                       .Include(x => x.Category) // Kategorilerle ilişkili ürünleri de getir
                       .ToList();
        }
    }
}
