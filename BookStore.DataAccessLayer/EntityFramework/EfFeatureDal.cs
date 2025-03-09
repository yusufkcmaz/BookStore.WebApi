using BookStore.DataAccessLayer.Abstract;
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
    public class EfFeatureDal : GenericRepository<Feature>, IFeatureDal
    { 
        private readonly BookStoreContext _context;

        public EfFeatureDal(BookStoreContext context) :base(context) 
        {
            _context = context;
        }

        public int GetFeatureCount()
        {
            return _context.Features.Count();
        }
    }
}
