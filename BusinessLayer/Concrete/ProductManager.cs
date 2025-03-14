using BookStore.BusinessLayer.Abstract;
using BookStore.DataAccessLayer.Abstract;
using BookStore.DataAccessLayer.Context;
using BookStore.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BusinessLayer.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public Product TGetRandomProduct()
        {
            return _productDal.GetRandomProduct();
        }

        public void TAdd(Product entity)
        {
          
            _productDal.Add(entity);
        }

        public void TDelete(int id)
        {
            _productDal.Delete(id);
        }

        public List<Product> TGetAll()
        {
            
            return _productDal.GetAll();
        }

        public Product TGetById(int id)
        {
           return _productDal.GetById( id);
        }

        public int TGetProductCount()
        {
            return _productDal.GetProductCount();
        }

        //İnterface Metod

        public void TUpdate(Product entity)
        {
            _productDal.Update(entity);
        }

        public List<Product> GetAllProductsWithDetails()
        {

            return _productDal.GetAllProductsWithDetails();
        }
    }
}
