using BookStore.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BusinessLayer.Abstract
{
    public interface IProductService : IGenericService<Product>
    {
         public int TGetProductCount();
        Product TGetRandomProduct();
        List<Product> GetAllProductsWithDetails();
        public List<Product> TGetProductsWithCategories();

        List<Product> GetCategoryAndProduct();


    }


}
