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
    public class EfWriterDal : GenericRepository<Writer>, IWriterDal
    {
        private readonly BookStoreContext _context; 
        public EfWriterDal(BookStoreContext context) : base(context)
        {
            _context = context; 
        }

        public List<Writer> GetAllWriter()
        {
            var values = new BookStoreContext();
            var writer = values.Writers.ToList();
            return writer;  
        }
    }
}
