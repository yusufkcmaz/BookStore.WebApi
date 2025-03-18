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
    public class EfQuoteDal : GenericRepository<Quote>, IQuoteDal
    {
        private readonly BookStoreContext _context;
        public EfQuoteDal(BookStoreContext context) : base(context)
        {
            _context = context;
        }

        public List<Quote> GetAllQuotes()
        {
            return _context.Quotes.ToList();
        }

        public Quote GetRandomQuote()
        {
            var quote = _context.Set<Quote>()
                .OrderBy(x => Guid.NewGuid())  
                .Take(1)  
                .FirstOrDefault();  

            return quote; 
        }
    }
}
