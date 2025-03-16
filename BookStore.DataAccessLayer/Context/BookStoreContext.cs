using BookStore.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DataAccessLayer.Context
{
    public class BookStoreContext :DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=IŞ\\SQLEXPRESS;initial catalog=APIBookDb;integrated security=true;");

        }

        public DbSet<Category> Categories { get; set; }  
        public DbSet<Product> Products { get; set; }  
        public DbSet<Feature> Features { get; set; }    
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<Subscribe> Subscribes  { get; set; }
        public DbSet<Billboard> Billboards { get; set; }

    }
}
