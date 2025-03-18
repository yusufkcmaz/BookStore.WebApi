using BookStore.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DataAccessLayer.Abstract
{
    public interface ICategoryDal:IGenericDal<Category>
    {
        // Kategoriye özel metod-en son eklenen kategorileri
        //List<Category> GetLatestCategories(int count);

        List<Product> GetCategoriesWithProducts();

    }
}
